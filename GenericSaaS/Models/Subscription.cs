using System;
using System.Collections.Generic;

namespace GenericSaaS.Models
{
	public class Subscription
	{
		/// <summary>
		/// "ID": "User subscription for 870f902f-ac4a-4789-963c-e01896f6106e",
		/// </summary>
		public string ID { get; set; }
		
		/// <summary>
		/// "UserCap": 100,
		/// </summary>
		public int UserCap { get; set; }
		
		/// <summary>
		/// "AvailableSeats": 98,
		/// </summary>
		public int AvailableSeats { get; set; }
		
		/// <summary>
		/// "MeteringType": "PerAssignedUser",
		/// </summary>
		public string MeteringType { get; set; } // 
		
		/// <summary>
		/// "Created": "2009-06-15T13:45:30",
		/// </summary>
		public DateTime Created { get; set; }

		/// <summary>
		///  "Type": {
		///         "ID": "example_subscription_id",
		///         "Name": "Example user subscription"
		/// },
		/// </summary>
		public SubscriptionType Type { get; set; }

		/// <summary>
		///  "UserIds": [
		/// "john.doe@snowsoftware.com",
		/// "jane.doe@snowsoftware.com"
		/// ]
		/// </summary>
		public List<string> UserIds { get; set; }

		public Subscription(int numberdOfUsers)
		{
			ID = $"User subscription for {Guid.NewGuid().ToString()}";
			MeteringType = "PerAssignedUser";
			Created = DateTime.Now;
			UserCap = numberdOfUsers;
			AvailableSeats = numberdOfUsers;
			Type = new SubscriptionType();

			AddUsers(numberdOfUsers);
		}

		private void AddUsers(int numberdOfUsers)
		{
			UserIds = new List<string>();
			for (int i = 0; i < numberdOfUsers; i++)
			{
				UserIds.Add($"{Guid.NewGuid().ToString()}@snowsoftware.com");
			}
		}
	}
}
