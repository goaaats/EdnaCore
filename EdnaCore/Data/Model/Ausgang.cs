using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    public class Ausgang
    {
        [Key]
        public int Id { get; set; }
        public RaumObjektInteraktion RaumObjektInteraktion { get; set; }
        public Raum ZielRaum { get; set; }
        public int WalkInPointX { get; set; }
        public int WalkInPointY { get; set; }
        public string CharakterBlickRichtung { get; set; }
    }
}
