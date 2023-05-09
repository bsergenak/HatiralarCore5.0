﻿using Hatiralar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.Entities.Dtos
{
    public class LoginDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
