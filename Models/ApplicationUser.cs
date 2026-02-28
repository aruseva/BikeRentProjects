

using Microsoft.AspNetCore.Identity;

namespace BikeRentProjects.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<RentalRequest> RentalRequests { get; set; }
    }
}
