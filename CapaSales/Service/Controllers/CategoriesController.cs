using BLL;
using Entities;
using SLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers
{
    public class CategoriesController : ApiController, ICategoriesService
    {
        [HttpPost]
        public Categories Create(Categories categories)
        {
            var categoryLogic = new CategoriesLogic();
            var category = categoryLogic.Create(categories);
            return category;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var categoryLogic = new CategoriesLogic();
            var category = categoryLogic.Delete(id);
            return category;
        }

        [HttpGet]
        public Categories RetrieveByID(int id)
        {
            var categoryLogic = new CategoriesLogic();
            var category = categoryLogic.RetrieveByID(id);
            return category;
        }

        [HttpPut]
        public bool Update(Categories categoryToUpdate)
        {
            var categoryLogic = new CategoriesLogic();
            var result = categoryLogic.Update(categoryToUpdate);
            return result;
        }
    }
}