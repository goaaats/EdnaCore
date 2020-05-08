using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    public class InventarObjekt
    {
        [Key]
        public int Id { get; set; }
        public int GuiId { get; set; }
        public string Bezeichnung { get; set; }
        public string IconDatei { get; set; }
        public int InventarPosition { get; set; }
        public string DefaultAktion { get; set; }
        public int AnsehenSkriptId { get; set; }
        public int BenutzenSkriptId { get; set; }
        public int RedenMitSkriptId { get; set; }
    }
}
