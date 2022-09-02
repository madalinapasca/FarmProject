using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProject.Shared
{
    public class Barn
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Optiunile de animale pentru patrupede sunt: porci, cai, oi, bovine.")]
        
        public string Name { get; set; }
        [Required(ErrorMessage ="cantitatea nu poate fi un numar negativ.")]
        public int Quantity { get; set; }
    }
}
