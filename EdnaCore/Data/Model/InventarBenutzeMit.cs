using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    public class InventarBenutzeMit
    {
        [Key]
        public Guid Id { get; set; }
        public InventarObjekt InventarObjekt1 { get; set; }
        public InventarObjekt InventarObjekt2 { get; set; }
        public int SkriptId { get; set; }
    }
}
