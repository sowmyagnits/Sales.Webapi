using System;

namespace Order.Business.DataContract
{
    public class UserDataContract
    {
        /// <summary>
        /// The userId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The users email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The users first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The users surname
        /// </summary>
        public string LastName { get; set; }

        public string AccessToken { get; set; }

        //Included to show all the available properties

        public string TokenType { get; set; }

        public uint ExpiresIn { get; set; }

        public DateTimeOffset Issued { get; set; }

        public DateTimeOffset Expires { get; set; }
    }
}