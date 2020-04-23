using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using StreetBroker.Common;

namespace StreetBroker.Models
{
    [Table(name:"repo_order",Schema ="repo")]
    public class RepoOrder: BaseOrder
    {
        public RepoOrder()
        {
            OrderStatus = OrderStatus.New;
        }

        [Key]
        [Column(name:"id", Order =1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Column(name: "net_interest_rate", TypeName = "numeric(5,2)", Order = 3)]
        [Required]
        public decimal InterestRate { get; set; }
        [Column(name: "gross_interest_rate", TypeName = "numeric(5,2)", Order =4)]
        [Required]
        public decimal GrossInterestRate { get; set; }
        [Column(name: "amount", TypeName ="numeric(18,2)", Order =2)]
        [Required]
        public decimal Amount { get; set; }
        [Column(name: "net_interest_amount", TypeName = "numeric(18,2)")]
        [Required]
        public decimal NetInterestAmount { get; set; }
        [Column(name: "gross_interest_amount", TypeName = "numeric(18,2)")]
        [Required]
        public decimal GrossInterestAmount { get; set; }
        [Column(name: "return_net_interest_amount", TypeName = "numeric(18,2)")]
        [Required]
        public decimal ReturnNetInterestAmount { get; set; }
        [Column(name: "return_gross_interest_amount", TypeName = "numeric(18,2)")]
        [Required]
        public decimal ReturnGrossInterestAmount { get; set; }
        [Column(name: "tax_amount", TypeName = "numeric(18,2)")]
        [Required]
        public decimal TaxAmount { get; set; }
        [Column(name: "maturity", TypeName = "Date")]
        [Required]
        public DateTime Maturity { get; set; }
        [Column(name: "start_date", TypeName = "Date")]
        [Required]
        public DateTime StartDate { get; set; }
        [Column(name: "order_status")]
        [Required]
        public OrderStatus OrderStatus { get; set; }
    }
}
