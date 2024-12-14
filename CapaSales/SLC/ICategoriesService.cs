using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC
{
    public interface ICategoriesService
    {
        Categories Create(Categories category);
        Categories RetrieveByID(int categoryId);
        bool Update(Categories categoryToUpdate);
        bool Delete(int categoryId);
    }
}