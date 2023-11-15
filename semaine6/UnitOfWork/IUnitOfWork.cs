using semaine6.Models;
using semaine6.Repository;

namespace semaine6.UnitOfWork
{
    interface IUnitOfWork
    {
        IRepository<Employee> EmployeeRepository { get; }

        IRepository<Order> OrderRepository { get; }
    }
}
