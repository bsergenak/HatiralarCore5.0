using Hatiralar.Core.DataAccess.EntityFramework;
using Hatiralar.DataAccess.Abstract;
using Hatiralar.DataAccess.Concrete.EntityFramework.Context;
using Hatiralar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.DataAccess.Concrete.EntityFramework
{
    public class NotebookDal:RepositoryBase<Notebook>,INotebookDal
    {
        public NotebookDal(HatiralarContext context) : base(context)
        {
        }
    }
}
