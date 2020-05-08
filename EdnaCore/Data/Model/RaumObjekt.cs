using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    public class RaumObjekt
    {
        [Key]
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public Raum Raum { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int PosZ { get; set; }
        public string BildDatei { get; set; }
        public bool Aktiv { get; set; }
    }
}
