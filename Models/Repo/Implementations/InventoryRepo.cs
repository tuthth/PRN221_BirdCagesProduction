using Models.Models;
using Models.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repo.Implementations
{
    public class InventoryRepo : Repository<Inventory>, IIventoryRepo
    {
        public InventoryRepo(BirdCageManagementsContext context) : base(context)
        {
        }
    }
}
