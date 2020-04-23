using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using StreetBroker.Common;

namespace StreetBroker.Models
{
    [Table(name: "dealer", Schema = "cor")]
    public class Dealer: BaseEntity
    {

        [Key]
        [Column(name: "id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Column(name: "first_name", Order = 2)]
        [MaxLength(500)]
        [Required]
        public string FirstName { get; set; }
        [Column(name: "last_name", Order = 3)]
        [MaxLength(250)]
        public string LastName { get; set; }
        [Required]
        [Column(name: "email", Order = 4)]
        [MaxLength(500)]
        public string Email { get; set; }
        [Phone]
        [Column(name: "phone_number", Order = 5)]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
