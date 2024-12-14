using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC
{
    public interface IPersonaService
    {
        Persona Create(Persona persona);
        Persona RetrieveByID(int personaId);
        bool Update(Persona personaToUpdate);
        bool Delete(int personaId);


    }
}
