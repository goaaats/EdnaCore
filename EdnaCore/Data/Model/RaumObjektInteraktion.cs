using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    public class RaumObjektInteraktion
    {
        [Key]
        public int Id { get; set; }
        public RaumObjekt RaumObjekt { get; set; }
        public string BezeichnungOMO { get; set; }
        public int WalkToX { get; set; }
        public int WalkToY { get; set; }
        public string StandByBlickrichtung { get; set; }
        public string DefaultAktion { get; set; }
        public int AnsehenSkriptId { get; set; }
        public int BenutzenSkriptId { get; set; }
        public int NehmenSkriptId { get; set; }
        public int RedenMitSkriptId { get; set; }
    }
}
