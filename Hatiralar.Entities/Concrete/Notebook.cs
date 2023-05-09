using Hatiralar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.Entities.Concrete
{
    public class Notebook:IEntity
    {
        public Notebook()
        {
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int CityId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual City City { get; set; }
        public virtual AppUser AppUser { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
