using School.Repository;
using semaine4.Models;

namespace semaine4.UnitOfWork
{
    interface IUnitOfWork
    {
        IRepository<Student> StudentRepository { get; }

        IRepository<Section> SectionRepository { get; }
    }
}
