using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    public class Timer
    {
        [Key]
        public int Id { get; set; }
        public int SkriptId { get; set; }
        public int Dauer { get; set; }
        public bool Aktiv { get; set; }
    }
}
