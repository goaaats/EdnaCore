using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    public class ChoiceListeEntry
    {
        [Key]
        public Guid Id { get; set; }
        public int ChoiceId { get; set; }
        public int AuswahlNummer { get; set; }
        public bool Aktiv { get; set; }
        public string AuswahlText { get; set; }
        public int SkriptId { get; set; }
    }
}
