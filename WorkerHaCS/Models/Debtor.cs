using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerHaCS.Models
{
    class Debtor
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int ServiceId { get; set; }
        public double ActuallySpent { get; set; }
        public double Rate { get; set; }
        public double Debt { get; set; }
        public DateTime DateOfPayment { get; set; }
        public int PaymentId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual Service Service { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
