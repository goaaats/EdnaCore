using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdnaCore.Data.Model
{
    public class WalkableAreaMap
    {
        [Key]
        public int Id { get; set; }
        public string WamFile { get; set; } //?
    }
}
