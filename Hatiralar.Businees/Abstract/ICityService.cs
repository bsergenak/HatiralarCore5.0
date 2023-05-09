using Hatiralar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.Businees.Abstract
{
    public interface ICityService
    {
        Task<City> Get(int id);
        Task<List<City>> GetAll();
        Task<List<City>> GetAll(string nameContent);
        Task<string> Add(City city);
        Task<string> Update(City city);
        Task<string> Delete(int id);
    }
}
