using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    public class Raum
    {
        [Key]
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public string BildDatei { get; set; }
        public string MusikDatei { get; set; }
        public WalkableAreaMap WalkableAreaMap { get; set; }
        public double VSpeed { get; set; }
        public double HSpeed { get; set; }
        public double BaseYatZeroScale { get; set; }
        public double BaseYatFullScale { get; set; }
        public int GuiId { get; set; }
        public int CharacterAnimationSetId { get; set; }
        public Timer Timer { get; set; }
    }
}
