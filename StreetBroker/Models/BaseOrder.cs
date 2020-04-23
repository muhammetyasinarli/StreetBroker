using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using StreetBroker.Common;

namespace StreetBroker.Models
{
    public class BaseOrder: BaseEntity
    {
        [Column(name: "dealer_id")]
        [Required]
        public long DealerId { get; set; }
        [Column(name: "customer_id")]
        [Required]
        public long CustomerId { get; set; }
    }
}
