using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.Xna.Framework;

namespace EdnaCore.Data.Model
{
    public class RaumObjektDarstellung
    {
        [Key]
        public int Id { get; set; }
        public RaumObjekt RaumObjekt { get; set; }
        public Bildfolge Bildfolge { get; set; }
        public int BaselineStartX { get; set; }
        public int BaselineStartY { get; set; }
        public int BaselineEndX { get; set; }
        public int BaselineEndY { get; set; }
    }
}
