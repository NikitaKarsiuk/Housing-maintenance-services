using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerHaCS.Models
{
    [Table("PaymentForService")]
    public partial class PaymentForService
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int ServiceId { get; set; }
        public double ActuallySpent { get; set; }
        public DateTime DateOfPayment { get; set; }
        public int PaymentId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual Service Service { get; set; }
        public virtual Payment Payment {get; set;}
    }
}
