using CarShowRoom.Models.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowRoom.DL.Interfaces
{
    public interface IBuyerRepository
    {
            Buyer Create(Buyer buyer);
            Buyer Update(Buyer buyer);
            Buyer Delete(int id);
            Buyer GetById(int id);
            IEnumerable<Buyer> GetAll();
        }
    }

