using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC
{
    public interface IRolService
    {
        Rol Create(Rol rol);
        Rol RetrieveByID(int rolId);
        bool Update(Rol rolToUpdate);
        bool Delete(int rolId);
    }
}