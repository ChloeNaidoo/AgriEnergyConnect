using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect.Models
{
    public class Farmer
    {
        public int FarmerId { get; set; }

        [Required]
<<<<<<< HEAD
        public string Name { get; set; }
=======
        public string FullName { get; set; }
>>>>>>> 006fc78 (css)

        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Location { get; set; }

        public ICollection<Product> Products { get; set; }
    }


}
