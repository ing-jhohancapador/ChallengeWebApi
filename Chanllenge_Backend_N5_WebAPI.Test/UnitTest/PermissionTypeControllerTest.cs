namespace Chanllenge_Backend_N5_WebAPI.Test.UnitTest
{
    public class PermissionTypeControllerTest
    {
        private readonly Mock<IMediator> mockMediator;

        public PermissionTypeControllerTest()
        {
            mockMediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task Test_RequestPermissionType()
        {
            mockMediator.Reset();
            mockMediator.Setup(m => m.Send(It.IsAny<RequestPermissionTypeCommand>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(new RequestPermissionTypeResponse())
                        .Verifiable("Notification was not sent.");

            RequestPermissionTypeCommand permissionType = new();

            PermissionTypeController permissionTypeController = new(mockMediator.Object);

            await permissionTypeController.Post(permissionType);

            mockMediator.Verify(x => x.Send(It.IsAny<RequestPermissionTypeCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Test_GetPermissionType()
        {
            mockMediator.Reset();
            mockMediator.Setup(m => m.Send(It.IsAny<GetPermissionTypeQuery>(), It.IsAny<CancellationToken>()))
                      .ReturnsAsync(new List<GetPermissionTypeQueryResponse>())
                      .Verifiable("Notification was not sent.");


            PermissionTypeController permissionTypeController = new(mockMediator.Object); ;

            var types = await permissionTypeController.Get();

            mockMediator.Verify(m => m.Send(It.IsAny<GetPermissionTypeQuery>(), It.IsAny<CancellationToken>()), Times.Once());
            Assert.IsType<List<GetPermissionTypeQueryResponse>>(types);
        }
    }
}
