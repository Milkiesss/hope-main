﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User : BaseEntity
    {
        public string Address { get; set; }
        public virtual ICollection<Order> OrderHistory { get; set; }
    }
}
