using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using StreetBroker.Common;

namespace StreetBroker.Models
{
    public class IBaseEntity
    {
        [Column(name: "record_status")]
        [Required]
        public RecordStatus RecordStatus { get; set; }
        [Column(name: "create_date")]
        [Required]
        public DateTime CreateDate { get; set; }
        [Column(name: "update_date")]
        [Required]
        public DateTime UpdateDate { get; set; }
    }
}
