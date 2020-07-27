using System.Collections.Generic;

namespace GenericSaaS.Models
{
	public class GenericSaasFile
	{
		public List<Subscription> Subscriptions { get; set; }
		public List<User> Users { get; set; }

		public GenericSaasFile()
		{
			Subscriptions = new List<Subscription>();
			Users = new List<User>();
		}
	}
}
