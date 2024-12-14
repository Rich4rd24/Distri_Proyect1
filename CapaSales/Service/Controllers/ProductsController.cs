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
    public class ProductsController : ApiController, IProductService
    {
        [HttpPost]
        public Products Create(Products products)
        {
            var productLogic = new ProductLogic();
            var product = productLogic.Create(products);
            return product;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var productLogic = new ProductLogic();
            var product = productLogic.Delete(id);
            return product;
        }
        [HttpGet]
        public Products RetrieveByID(int id)
        {
            var productLogic = new ProductLogic();
            var product = productLogic.RetriveByID(id);
            return product;
        }

        [HttpPut]
        public bool Update(Products productToUpdate)
        {
            var productLogic = new ProductLogic();
            var result = productLogic.Update(productToUpdate);
            return result;
        }


    }
}