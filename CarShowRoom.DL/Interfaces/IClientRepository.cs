using CarShowRoom.Models.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

