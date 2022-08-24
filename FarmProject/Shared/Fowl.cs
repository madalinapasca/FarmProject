using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProject.Shared
{
    public class Fowl
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        public double? Corn { get; set; }

        public double? Hey { get; set; }
    }
}
