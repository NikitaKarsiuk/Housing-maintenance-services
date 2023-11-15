using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerHaCS.Models
{
    [Table("RentApartment")]
    public partial class RentApartment
    {
        public RentApartment() 
        {
            //HouseInformation = new HashSet<HouseInformation>();
            //Tenant = new HashSet<Tenant>();
        }
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int NumberOfResidents { get; set; }
        public double Square { get; set; }
        public int HouseInformationId { get; set; }
        public int ApartmentNumber { get; set; }
        public virtual HouseInformation HouseInformation { get; set; }
        public virtual Tenant Tenant { get; set; }

        //public virtual ICollection<HouseInformation> HouseInformation { get; set; }
        //public virtual ICollection<Tenant> Tenant { get; set; }
    }
}
