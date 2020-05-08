using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    public class CharacterAnimationSet
    {
        [Key]
        public Guid Id { get; set; }
        public int SetId { get; set; }
        public int AktionsmodusId { get; set; }
        public string Bezeichnung { get; set; }
        public Bildfolge LinksBildfolge { get; set; }
        public Bildfolge RechtsBildfolge { get; set; }
        public Bildfolge VorneBildfolge { get; set; }
        public Bildfolge HintenBildfolge { get; set; }
    }
}
