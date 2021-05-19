using System;

namespace GenericSaaS.Models
{
	public class User
    {
        /// <summary>
        /// "Id": "john.doe@snowsoftware.com",
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// "Email": "john.doe@snowsoftware.com",
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// "UserName": "johndoe",
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// "Name": "John Doe",
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// "Status": "Active",
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// "FirstActivity": "2017-08-22T17:22:17",
        /// </summary>
        public DateTime FirstActivity { get; set; }

        /// <summary>
        /// "LastActivity": "2019-09-16T17:22:17",
        /// </summary>
        public DateTime LastActivity { get; set; }

        /// <summary>
        /// "Registration": "2017-08-22T17:22:17"
        /// </summary>
        public DateTime Registration { get; set; }

        public User(string email, int lastActivity)
        {
            var name = email.Split('@')[0];

            Id = email;
            Email = email;
            UserName = name;
            Name = name;
            Status = "Active";
            FirstActivity = DateTime.Now.AddYears(-3);
            LastActivity = DateTime.Now.AddDays((-1) * lastActivity);
            Registration = FirstActivity;
        }
    }
}
