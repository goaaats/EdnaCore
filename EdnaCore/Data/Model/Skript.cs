using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    public class Skript
    {
        [Key]
        public Guid Id { get; set; }
        public int SkriptId { get; set; }
        public int Zeilennummer { get; set; }
        public string SkriptAktion { get; set; }
        public string Kommentar { get; set; }
    }
}
