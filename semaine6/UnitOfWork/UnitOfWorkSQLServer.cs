using semaine6.Models;
using semaine6.Repository;

namespace semaine6.UnitOfWork
{
    public class UnitOfWorkSQLServer : IUnitOfWork
    {
        private readonly NorthwindContext _context;

        private BaseRepositorySQL<Employee> _employeeRepository;
        private BaseRepositorySQL<Order> _orderRepository;

        public UnitOfWorkSQLServer(NorthwindContext context)
        {
            this._context = context;

            this._employeeRepository = new BaseRepositorySQL<Employee>(context);
            this._orderRepository = new BaseRepositorySQL<Order>(context);
        }

        public IRepository<Employee> EmployeeRepository
        {
            get { return this._employeeRepository; }
        }

        public IRepository<Order> OrderRepository
        {
            get { return this._orderRepository; }
        }
    }
}
