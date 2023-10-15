using Models.Models;
using Models.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repo.Implementations
{
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        public ProductRepo(BirdCageManagementsContext context) : base(context)
        {
        }
    }
}
