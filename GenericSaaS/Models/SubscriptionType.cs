using System;

namespace GenericSaaS.Models
{
	public class SubscriptionType
	{
		public Guid ID { get; set; }
		public string Name { get; set; }
		
		public SubscriptionType()
		{
			ID = Guid.NewGuid();
			Name = ID.ToString();
		}
	}
}
