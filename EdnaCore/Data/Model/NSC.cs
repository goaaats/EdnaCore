using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    // "Nicht-Spieler-Character" btw
    public class NSC
    {
        [Key]
        public int Id { get; set; }
        public RaumObjekt RaumObjekt { get; set; }
        public CharacterAnimationSet CharacterAnimationSet { get; set; }
        public string Bezeichnung { get; set; }
        public string Font { get; set; }
        public double VSpeed { get; set; }
        public double HSpeed { get; set; }
        public double BaseYatZeroScale { get; set; }
        public double BaseYatFullScale { get; set; }
    }
}
