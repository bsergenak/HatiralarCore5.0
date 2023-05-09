using Hatiralar.Core.DataAccess.EntityFramework;
using Hatiralar.DataAccess.Abstract;
using Hatiralar.DataAccess.Concrete.EntityFramework.Context;
using Hatiralar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.DataAccess.Concrete.EntityFramework
{
    public class CityDal :RepositoryBase<City>, ICityDal
    {
        public CityDal(HatiralarContext context):base(context)
        {

        }
       
    }
}
