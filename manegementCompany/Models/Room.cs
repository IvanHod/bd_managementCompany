using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
	[Table("room")]
	public class Room
	{
		public Room ()
		{
		}

		public Room(int num, int fl, int count_room)
		{
			number = num;
			floor = fl;
			countRoom = count_room;
			countPeople = 1;
			owner = 0;
			services = "";
		}

		[Column("id")]
		public int id { set; get; }

		[Column("number")]
		public int number { set; get; }

		[Column("floor")]
		public int floor { get; set; }

		[Column("count_room")]
		public int countRoom { set; get; }

		[Column("count_people")]
		public int countPeople { set; get; }

		[Column("owner")]
		public int owner { set; get; }

		[Column("services")]
		public string services { set; get; }
	}
}

