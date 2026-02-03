using APW.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APW.Data.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
       Product? GetById(int id);
        void Add(Product product);
        void Update(Product product);   
        void Delete(int Id);
        void Save();


    }
}
