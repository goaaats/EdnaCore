using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    public class Bildfolge
    {
        [Key]
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public int Anzeigedauer { get; set; }
        public bool Loop { get; set; }
    }
}
