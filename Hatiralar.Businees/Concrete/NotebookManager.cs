using Hatiralar.Businees.Abstract;
using Hatiralar.DataAccess.Abstract;
using Hatiralar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.Businees.Concrete
{
    public class NotebookManager : INotebookService
    {
        private readonly INotebookDal _notebookDal;

        public NotebookManager(INotebookDal notebookDal)
        {
            _notebookDal = notebookDal;
        }

        public async Task<string> Add(Notebook notebook)
        {
            await _notebookDal.Add(notebook);
            return "Hatıra başarıyla eklendi";

        }

        public async Task<string> Delete(int id)
        {
            Notebook noteBook = await Get(id);
            await  _notebookDal.Delete(noteBook);
            return "Silme işlemi başarılı";
        }

        public Task<Notebook> Get(int id)
        {
            return _notebookDal.GetT(x=>x.Id == id);
        }

        public Task<List<Notebook>> GetAll()
        {
            return _notebookDal.GetAll();
        }

        public async Task<List<Notebook>> GetAll(string nameContent)
        {
            return await _notebookDal.GetAll(x=>x.Title == nameContent);
        }

        public async Task<string> Update(Notebook notebook)
        {
           await _notebookDal.Update(notebook);
            return "Güncelleme işlemi başarılı";
        }
    }
}
