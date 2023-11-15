using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerHaCS.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext"){ }
        public virtual DbSet<HouseInformation> HouseInformation { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentForService> PaymentForService { get; set; }
        public virtual DbSet<RentApartment> RentApartment { get; set;}
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Street> Street { get; set; }
        public virtual DbSet<Tenant> Tenant { get; set; }
    }
}
