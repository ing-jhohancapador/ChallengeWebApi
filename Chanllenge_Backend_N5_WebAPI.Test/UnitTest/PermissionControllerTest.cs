namespace Chanllenge_Backend_N5_WebAPI.Test.UnitTest
{
    public class PermissionControllerTest
    {
        private readonly Mock<IMediator> mockMediator;

        public PermissionControllerTest()
        {
            mockMediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task Test_RequestPermission()
        {
            mockMediator.Reset();
            mockMediator.Setup(m => m.Send(It.IsAny<RequestPermissionCommand>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(new RequestPermissionResponse())
                        .Verifiable("Notification was not sent.");

            RequestPermissionCommand permission = new();

            PermissionController permissionController = new(mockMediator.Object);

            await permissionController.Post(permission);

            mockMediator.Verify(x => x.Send(It.IsAny<RequestPermissionCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Test_ModifyPermission()
        {
            mockMediator.Reset();
            mockMediator.Setup(m => m.Send(It.IsAny<ModifyPermissionCommand>(), It.IsAny<CancellationToken>()))
                       .ReturnsAsync(new ModifyPermissionResponse())
                       .Verifiable("Notification was not sent.");
            ModifyPermissionCommand permission = new();

            PermissionController permissionController = new(mockMediator.Object); ;

            await permissionController.Put(1, permission);


            mockMediator.Verify(x => x.Send(It.IsAny<ModifyPermissionCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Test_GetPermissions()
        {
            mockMediator.Reset();
            mockMediator.Setup(m => m.Send(It.IsAny<GetPermissionsQuery>(), It.IsAny<CancellationToken>()))
                      .ReturnsAsync(new List<GetPermissionsQueryResponse>())
                      .Verifiable("Notification was not sent.");


            PermissionController permissionController = new(mockMediator.Object); ;

            var types = await permissionController.Get();

            mockMediator.Verify(m => m.Send(It.IsAny<GetPermissionsQuery>(), It.IsAny<CancellationToken>()), Times.Once());
            Assert.IsType<List<GetPermissionsQueryResponse>>(types);
        }

        [Fact]
        public async Task Test_GetPermissionsById()
        {
            mockMediator.Reset();
            mockMediator.Setup(m => m.Send(It.IsAny<GetPermissionsByIdQuery>(), It.IsAny<CancellationToken>()))
                      .ReturnsAsync(new GetPermissionsByIdQueryResponse())
                      .Verifiable("Notification was not sent.");


            PermissionController permissionController = new(mockMediator.Object);

            var types = await permissionController.Get(1);

            mockMediator.Verify(m => m.Send(It.IsAny<GetPermissionsByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
            Assert.IsType<GetPermissionsByIdQueryResponse>(types);
        }


    }
}
