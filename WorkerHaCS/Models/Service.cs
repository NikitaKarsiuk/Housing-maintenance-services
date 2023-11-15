using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerHaCS.Models
{
    [Table("Service")]
    public partial class Service
    {
        public int Id { get; set; }
        public int Code { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Unit { get; set; }
        public double Rate { get; set; }
    }
}
