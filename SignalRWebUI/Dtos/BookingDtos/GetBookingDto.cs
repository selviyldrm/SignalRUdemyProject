﻿namespace SignalRWebUI.Dtos.BookingDtos
{
	public class GetBookingDto
	{
		public int BookingID { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Mail { get; set; }
		public string PersonCount { get; set; }
		public DateTime Date { get; set; }
	}
}