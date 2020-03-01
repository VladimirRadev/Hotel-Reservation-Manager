namespace HotelReservationManager.Data.Models
{
    public class Room
    {
        public string Id { get; set; }
        public string Capacity { get; set; }
        public string TypeId { get; set; }
        public bool isFree { get; set; }
        public string PriceForBedAsAdult { get; set; }
        public string PriceForBedAsChild { get; set; }
        public string Number { get; set; }
    }
}
