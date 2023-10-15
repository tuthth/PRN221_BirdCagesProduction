using Models.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IUnitOfWork
    {
        public ICustomerRepo CustomerRepo { get; }
        public IExpenseRepo ExpenseRepo { get; }
        public IOrderRepo OrderRepo { get; }
        public IIventoryRepo InventoryRepo { get; }
        public IProductRepo ProductRepo { get; }
        public IMaterialRepo MaterialRepo { get; }
        public IOrderItemRepo OrderItemRepo { get; }
        public IProductionStepRepo ProductionStepRepo { get; }
        public IStaffRepo StaffRepo { get; }
        public IWorkOnRepo WorkOnRepo { get; }
        Task<int> SaveChanges();
    }
}
