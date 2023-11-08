using School.Repository;
using semaine4.Models;
using semaine4.Repository;

namespace semaine4.UnitOfWork
{
    class UnitOfWorkMem : IUnitOfWork
    {
        private StudentRepositoryMem _studentRepository;
        private SectionRepositoryMem _sectionRepository;

        public UnitOfWorkMem()
        {
            this._studentRepository = new StudentRepositoryMem();
            this._sectionRepository = new SectionRepositoryMem();
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
