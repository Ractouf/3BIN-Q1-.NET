using School.Repository;
using semaine4.Models;
using System.Linq.Expressions;

namespace semaine4.Repository
{
    class SectionRepositoryMem : IRepository<Section>
    {
        private List<Section> _sections;

        public SectionRepositoryMem()
        {
            _sections = new List<Section>();
            _sections.Add(new Section { Name = "2BIN2" });
            _sections.Add(new Section { Name = "3BIN2" });
        }

        public void Delete(Section entity)
        {
            throw new NotImplementedException();
        }

        public IList<Section> GetAll()
        {
            return _sections;
        }

        public Section GetById(int id)
        {
            return _sections[id];
        }

        public void Insert(Section entity)
        {
            _sections.Add(entity);
        }

        public bool Save(Section entity, Expression<Func<Section, bool>> predicate)
        {
            Section findSection = (SearchFor(predicate)).FirstOrDefault();

            if (findSection == null)
            {
                Insert(entity);
                return true;
            }
            return false;
        }

        public IList<Section> SearchFor(Expression<Func<Section, bool>> predicate)
        {
            return _sections.AsQueryable().Where(predicate).ToList();
        }
    }
}
