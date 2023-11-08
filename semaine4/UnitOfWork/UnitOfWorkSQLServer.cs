using School.Repository;
using semaine4.Models;
using semaine4.Repository;

namespace semaine4.UnitOfWork
{
    class UnitOfWorkSQLServer : IUnitOfWork
    {
        private readonly SchoolContext _context;

        private BaseRepositorySQL<Student> _studentRepository;
        private BaseRepositorySQL<Section> _sectionRepository;

        public UnitOfWorkSQLServer(SchoolContext context)
        {
            this._context = context;

            this._studentRepository = new BaseRepositorySQL<Student>(context);
            this._sectionRepository = new BaseRepositorySQL<Section>(context);
        }

        public IRepository<Student> StudentRepository
        {
            get { return this._studentRepository; }
        }

        public IRepository<Section> SectionRepository
        {
            get { return this._sectionRepository; }
        }
    }
}
