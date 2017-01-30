namespace Order.Business.DataContract
{
    public class LoginDataContract
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}