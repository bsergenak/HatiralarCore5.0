using Hatiralar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.Entities.Concrete
{
    public class City:IEntity
    {
        public City()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Notebook> Notebooks { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
