namespace BikeRentProjects.Models
{
    public class Bike:BaseEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int  TypeBikeID { get; set; }
        public virtual TypeOfBike? TypeBike { get; set; }
        public string Location  { get; set; }
        public string Description { get; set; }
        public decimal PriceForHour { get; set; }
        public string Image { get; set; }

        public virtual ICollection<RentalRequest>? RentalRequests { get; set; }
    }
}
