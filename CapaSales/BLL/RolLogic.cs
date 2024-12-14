using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RolLogic
    {
        public Rol Create(Rol newRol)
        {
            Rol result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Rol res = r.Retrieve<Rol>(t => t.nombre == newRol.nombre);
                if (res == null)
                {
                    result = r.Create(newRol);
                }
                else
                {
                    throw new Exception("Rol already exists");
                }
                return result;
            }
        }

        public Rol RetrieveByID(int ID)
        {
            Rol result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Retrieve<Rol>(t => t.id == ID);
                return result;
            }
        }

        public bool Update(Rol rolToUpdate)
        {
            bool res = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Rol temp = r.Retrieve<Rol>(t => t.nombre == rolToUpdate.nombre
                    && t.id != rolToUpdate.id);
                if (temp == null)
                {
                    res = r.Update(rolToUpdate);
                }
                return res;
            }
        }

        public bool Delete(int ID)
        {
            bool res = false;
            var rol = RetrieveByID(ID);
            if (rol != null)
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    res = r.Delete(rol);
                }
            }
            return res;
        }

        public List<Rol> GetAll()
        {
            List<Rol> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Filter<Rol>(t => true);
            }
            return result;
        }
    }
}
