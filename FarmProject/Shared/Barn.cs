﻿using System;
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
        
        public string Name { get; set; }
        [Required]
        [Range(0, 100000, ErrorMessage ="cantitatea nu poate fi un numar negativ.")]
        public int Quantity { get; set; }
    }
}
