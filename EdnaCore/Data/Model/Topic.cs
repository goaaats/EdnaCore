using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        public RaumObjekt RaumObjekt { get; set; }
        public string Bezeichnung { get; set; }
        public string IconDatei { get; set; }
        public int InventarPosition { get; set; }
        public int TopicLeistenPosition { get; set; }
        public int SkriptId { get; set; }
    }
}
