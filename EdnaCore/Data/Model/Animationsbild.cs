using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    public class Animationsbild
    {
        [Key]
        public int Id { get; set; }
        public Bildfolge Bildfolge { get; set; }
        public string BildDatei { get; set; }
        public int AbweichendeAnzeigeDauer { get; set; }
    }
}
