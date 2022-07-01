using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("rates")]
    public class Rate
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("code")]
        public string Code { get; set; }
        [Required]
        [Column("effective_date")]
        public string EffectiveDate { get; set; }
        [Required]
        [Column("mid")]
        public double Mid { get; set; }
    
    }
}
