﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.Core.Entities
{
    public interface IEntity
    {
        public DateTime CreateDate { get; set; }
    }
}
