using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerHaCS.Models
{
    [Table("Tenant")]
    public partial class Tenant
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required]
        [StringLength(50)]
        public string Patronymic { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get;set; }
        [Required]
        [StringLength(50)]
        public string BankBook { get; set; }
    }
}
