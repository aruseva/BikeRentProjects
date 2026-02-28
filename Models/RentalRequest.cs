namespace BikeRentProjects.Models
{
    public class RentalRequest:BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public RentalStatus Status { get; set; }
        public int BikeID { get; set; }
        public virtual Bike? Bike { get; set; }
        public int UserID { get; set; }
        public virtual ApplicationUser? User { get; set; }

    }
}