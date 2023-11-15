using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerHaCS.Models
{
    [Table("HouseInformation")]
    public partial class HouseInformation
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string HouseNumber { get; set; }
        public int NumberOfApartments { get; set; }
        public int StreetId { get; set; }
       public virtual Street Street { get; set; }
    }
}
