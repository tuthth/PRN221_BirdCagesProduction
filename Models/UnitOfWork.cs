using Models.Models;
using Models.Repo.Implementations;
using Models.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UnitOfWork
    {
        public UnitOfWork(BirdCageManagementsContext context) {
            _context = context;
        }
        private readonly BirdCageManagementsContext _context;
        private ICustomerRepo customerRepo = null!;
        private IExpenseRepo expenseRepo = null!;
        private IOrderRepo orderRepo = null!;
        private IIventoryRepo inventoryRepo = null!;
        private IMaterialRepo materialRepo = null!;
        private IOrderItemRepo orderItemRepo = null!;
        private IProductionStepRepo productionStepRepo = null!;
        private IProductRepo productRepo = null!;
        private IStaffRepo staffRepo = null!;
        private IWorkOnRepo workOnRepo = null!;
        public ICustomerRepo Customers => customerRepo ??= new CustomerRepo(_context);
        public IExpenseRepo Expenses => expenseRepo ??= new ExpenseRepo(_context);
        public IOrderRepo Orders => orderRepo ??= new OrderRepo(_context);
        public IOrderItemRepo OrderItems => orderItemRepo ??= new OrderItemRepo(_context);
        public IIventoryRepo Inventories => inventoryRepo ??= new InventoryRepo(_context);
        public IMaterialRepo Materials => materialRepo ??= new MaterialRepo(_context);
        public IProductionStepRepo ProductionSteps => productionStepRepo ??= new ProductionStepRepo(_context);
        public IProductRepo Products => productRepo ??= new ProductRepo(_context);
        public IStaffRepo Staffs => staffRepo ??= new StaffRepo(_context);
        public IWorkOnRepo WorkOns => workOnRepo ??= new WorkOnRepo(_context);

        public async Task<int> SaveChanges() => await _context.SaveChangesAsync();
    }
}
