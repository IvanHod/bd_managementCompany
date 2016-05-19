using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace web.Models
{
	[Table("house")]
	public class House
	{
		public House ()
		{
		}

		public House(MHouse house)
		{
			number = house.number;
			countFloor = house.countFloor;
			countPorch = house.countPorch;
			countRoom = house.countRoom;
			services = string.Join(",", house.services);
			address = house.address;
		}

		public House(MHouse house, int addressId)
		{
			number = house.number;
			countFloor = house.countFloor;
			countPorch = house.countPorch;
			countRoom = house.countRoom;
			services = string.Join(",", house.services);
			address = addressId;
			organization = house.organization;
		}

		[Column("id")]
		public int id { set; get; }

		[Column("number")]
		public string number  { set; get; }

		[Column("count_floor")]
		public int countFloor { set; get; }

		[Column("count_porch")]
		public int countPorch { set; get; }

		[Column("count_room")]
		public int countRoom { set; get; }

		[Column("services")]
		public string services { set; get; }

		[Column("address")]
		public int address { set; get; }

		[Column("rooms")]
		public string rooms { set; get; }

		[Column("organization")]
		public int organization { set; get; }
	}

	public class MHouse
	{
		public MHouse() {}

		public MHouse(House house)
		{
			id = house.id;
			number = house.number;
			countFloor = house.countFloor;
			countPorch = house.countPorch;
			countRoom = house.countRoom;
			string[] arrayServices = house.services.Split (',');
			services = new List<int> { };
			foreach (string str in arrayServices ) {
				services.Add (Int16.Parse(str));
			}
			organization = house.organization;
			Address addr = new Address (house.address);
			region = addr.region;
			city = addr.city;
			street = addr.street;
		}

		public int id { set; get; }

		public string number  { set; get; }

		public int countFloor { set; get; }

		public int countPorch { set; get; }

		public int countRoom { set; get; }

		public string region { set; get; }

		public string city { set; get; }

		public string street { set; get; }

		public List<int> services { set; get; }

		public int address { set; get; }

		public int organization { set; get; }
	}
}

