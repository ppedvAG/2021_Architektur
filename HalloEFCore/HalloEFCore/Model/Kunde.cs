﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalloEFCore.Model
{
    class Kunde : Person
    {
        [Required]
        [Column("CustomerNumber")]
        public string KdNummer { get; set; }

        public Mitarbeiter Mitarbeiter { get; set; }
    }
}
