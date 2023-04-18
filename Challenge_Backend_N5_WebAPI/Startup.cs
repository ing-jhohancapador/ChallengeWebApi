using Challenge_Backend_N5_WebAPI.Domain.Repositories;
using Challenge_Backend_N5_WebAPI.Domain.UnitOfWork;
using Challenge_Backend_N5_WebAPI.Domain.ValueObjects;
using Challenge_Backend_N5_WebAPI.Infrastructure.Context;
using Challenge_Backend_N5_WebAPI.Infrastructure.Repositories;
using Challenge_Backend_N5_WebAPI.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SlimMessageBus;
using SlimMessageBus.Host.AspNetCore;
using SlimMessageBus.Host.Config;
using SlimMessageBus.Host.Kafka;
using SlimMessageBus.Host.Serialization.Json;


namespace Challenge_Backend_N5_WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_ChallengeN5WebAPI";


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            string conexion = Configuration.GetConnectionString("cadena-conexion-n5").ToString() ?? "";
            services.AddDbContext<DbContextChallengeN5>(opt => opt.UseSqlServer(conexion, x => x.MigrationsAssembly("Challenge_Backend_N5_WebAPI.Infrastructure")));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
                                  });
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddSingleton(BuildMessageBus);
            services.AddSingleton<IRequestResponseBus>(svp => svp.GetService<IMessageBus>());
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var assemblyApi = typeof(Startup).Assembly;

            var assemblyApplication = AppDomain.CurrentDomain.Load("Challenge_Backend_N5_WebAPI.Application");
            var assemblyDomain = AppDomain.CurrentDomain.Load("Challenge_Backend_N5_WebAPI.Domain");


            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(assemblyApi);
                cfg.RegisterServicesFromAssembly(assemblyApplication);
                cfg.RegisterServicesFromAssembly(assemblyDomain);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private IMessageBus BuildMessageBus(IServiceProvider serviceProvider)
        {
            return MessageBusBuilder
                .Create()
                .WithSerializer(new JsonMessageSerializer())
                .WithProviderKafka(new KafkaMessageBusSettings(Configuration.GetSection("kafka").GetSection("brokerUrl").Value)
                {
                    ProducerConfig = (config) =>
                    {
                        config.LingerMs = 5; // 5ms
                        config.SocketNagleDisable = true;
                    },
                    ConsumerConfig = (config) =>
                    {
                        config.FetchErrorBackoffMs = 1;
                        config.SocketNagleDisable = true;
                    }
                })
                .Produce<StructureKafka>(producerBuilder =>
                {
                    _ = producerBuilder.DefaultTopic(Configuration.GetSection("kafka").GetSection("topic").Value);

                })
                .WithDependencyResolver(new AspNetCoreMessageBusDependencyResolver(serviceProvider))
                .Build();
        }

    }
}
