namespace BikeRentProjects.Models
{
    public class TypeOfBike:BaseEntity
    {
        public string TypeBike { get; set; }
        public virtual ICollection<Bike> Bikes { get; set; }
    }
}
