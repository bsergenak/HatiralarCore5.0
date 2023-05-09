using Hatiralar.Businees.Abstract;
using Hatiralar.DataAccess.Abstract;
using Hatiralar.DataAccess.Concrete.EntityFramework;
using Hatiralar.DataAccess.Concrete.EntityFramework.Context;
using Hatiralar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.Businees.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public async Task<string> Add(City city)
        {
            await _cityDal.Add(city);
            return "Ekleme İşlemi Başarılı";
        }

        public async Task<string> Delete(int id)
        {
            City city = await Get(id);
            await _cityDal.Delete(city);
            return "Silme İşlemi Başarılı";
        }

        public async Task<City> Get(int id)
        {
           return await _cityDal.GetT(x=>x.Id == id);
        }

        public async Task<List<City>> GetAll()
        {
            return await _cityDal.GetAll();
        }

        public async Task<List<City>> GetAll(string nameContent)
        {
            return await _cityDal.GetAll(x=>x.Name.Contains(nameContent));
        }

        public async Task<string> Update(City city)
        {
            await _cityDal.Update(city);
            return "Güncelleme Başarılı";
            
        }
    }
}
