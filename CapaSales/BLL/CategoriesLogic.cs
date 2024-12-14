using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriesLogic
    {
        public Categories Create(Categories newCategory)
        {
            Categories result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Categories res = r.Retrieve<Categories>(c => c.CategoryName == newCategory.CategoryName);
                if (res == null)
                {
                    result = r.Create(newCategory);
                }
                else
                {
                    throw new Exception("Category already exists");
                }
                return result;
            }
        }

        public Categories RetrieveByID(int ID)
        {
            Categories result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Retrieve<Categories>(c => c.CategoryID == ID);
                return result;
            }
        }

        public bool Update(Categories categoryToUpdate)
        {
            bool res = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Categories temp = r.Retrieve<Categories>(c => c.CategoryName == categoryToUpdate.CategoryName
                    && c.CategoryID != categoryToUpdate.CategoryID);
                if (temp == null)
                {
                    res = r.Update(categoryToUpdate);
                }
                return res;
            }
        }

        public bool Delete(int ID)
        {
            bool res = false;
            var category = RetrieveByID(ID);
            if (category != null)
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    res = r.Delete(category);
                }
            }
            return res;
        }

        public List<Categories> FilterByCategoryID(int categoryID)
        {
            List<Categories> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Filter<Categories>(c => c.CategoryID == categoryID);
            }
            return result;
        }
    }
}
