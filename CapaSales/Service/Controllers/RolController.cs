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
    public class RolController : ApiController, IRolService
    {
        [HttpPost]
        public Rol Create(Rol rol)
        {
            var rolLogic = new RolLogic();
            var createdRol = rolLogic.Create(rol);
            return createdRol;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var rolLogic = new RolLogic();
            var result = rolLogic.Delete(id);
            return result;
        }

        [HttpGet]
        public Rol RetrieveByID(int id)
        {
            var rolLogic = new RolLogic();
            var rol = rolLogic.RetrieveByID(id);
            return rol;
        }

        [HttpPut]
        public bool Update(Rol rolToUpdate)
        {
            var rolLogic = new RolLogic();
            var result = rolLogic.Update(rolToUpdate);
            return result;
        }
    }
}