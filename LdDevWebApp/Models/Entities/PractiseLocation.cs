﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.Models.Entities
{
    public class PractiseLocation
    {
        [Key]
        public Guid practiseLocationId { get; set; }

        public String practiseDescription { get; set; }
    }
}
