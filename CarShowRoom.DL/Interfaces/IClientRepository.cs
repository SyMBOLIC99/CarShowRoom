using CarShowRoom.Models.DTO.Models;
using System.Collections.Generic;

namespace CarShowRoom.DL.Interfaces
{
    public interface IClientRepository
    {
            Client Create(Client client);
            Client Update(Client client);
            Client Delete(int id);
            Client GetById(int id);
            IEnumerable<Client> GetAll();
        }
    }

