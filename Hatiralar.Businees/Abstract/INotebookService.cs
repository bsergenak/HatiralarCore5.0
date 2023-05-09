using Hatiralar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.Businees.Abstract
{
    public interface INotebookService
    {
        Task<Notebook> Get(int id);
        Task<List<Notebook>> GetAll();
        Task<List<Notebook>> GetAll(string nameContent);
        Task<string> Add(Notebook notebook);
        Task<string> Update(Notebook notebook);
        Task<string> Delete(int id);
    }
}
