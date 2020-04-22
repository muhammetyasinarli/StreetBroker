using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StreetBroker.Models
{
    [Table(name: "customer", Schema = "cor")]
    public class Customer: IBaseEntity
    {
        [Key]
        [Column(name: "id", Order = 1)]
        [Required]
        public int Id { get; set; }
        [Column(name: "first_name", Order = 2)]
        [Required]
        [MaxLength(500)]
        public string FirstName { get; set; }
        [Column(name: "last_name", Order = 3)]
        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }
        [Column(name: "email", Order = 4)]
        [EmailAddress]
        [Required]
        [MaxLength(500)]
        public string Email { get; set; }
        [Column(name: "address", Order = 5)]
        [MaxLength(700)]
        public string Address { get; set; }
        [Column(name: "city", Order = 6)]
        [MaxLength(250)]
        public string City { get; set; }
        [Column(name: "country", Order = 7)]
        [MaxLength(250)]
        public string Country { get; set; }
        [Column(name: "zip", Order = 8)]
        public int Zip { get; set; }
        [Column(name: "gender", Order = 9)]
        [MaxLength(10)]
        public string Gender { get; set; }
        [Phone]
        [Column(name: "phone_number", Order = 10)]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
