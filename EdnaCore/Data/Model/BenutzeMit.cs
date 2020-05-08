using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    public class BenutzeMit
    {
        [Key]
        public Guid Id { get; set; }
        public InventarObjekt InventarObjekt { get; set; }
        public RaumObjekt RaumObjekt { get; set; }
        public int SkriptId { get; set; }
    }
}
