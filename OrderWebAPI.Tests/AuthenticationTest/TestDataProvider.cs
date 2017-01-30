using Order.Business.DataContract;

namespace OrderWebAPI.Tests
{
    public static class TestDataProvider
    {
        public static LoginDataContract GetLoginUserModel()
        {
            return new LoginDataContract()
            {
                Email = "test@siriusiq.com",
                PasswordHash = "VGVzdDEyMyQ="
            };
        }
    }
}