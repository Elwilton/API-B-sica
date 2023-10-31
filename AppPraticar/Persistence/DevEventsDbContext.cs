using System;
using AppPraticar.Entitys;

namespace AppPraticar.Persistence
{
	public class DevEventsDbContext
	{
		public List<DevEvent> DevEvents { get; set; }

		public DevEventsDbContext()
		{
			DevEvents = new List<DevEvent>();
		}
	}
}

