using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using StreetBroker.Common;

namespace StreetBroker.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            RecordStatus = RecordStatus.Active;
        }

        [Column(name: "record_status")]
        [Required]
        public RecordStatus RecordStatus { get; set; }
        [Column(name: "created_date")]
        [Required]
        public DateTime CreatedDate { get; set; }
        [Column(name: "modified_date")]
        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}
