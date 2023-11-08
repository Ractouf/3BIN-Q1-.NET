using School.Repository;
using semaine4.Models;
using System.Linq.Expressions;

namespace semaine4.Repository
{
    class StudentRepositoryMem : IRepository<Student>
    {
        private List<Student> _students;

        public StudentRepositoryMem()
        {
            _students = new List<Student>();
            _students.Add(new Student { Name = "Łapiński", Firstname = "Damian" });
            _students.Add(new Student { Name = "山本", Firstname = "Guillherme" });
        }

        public void Delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public IList<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            return _students[id];
        }

        public void Insert(Student entity)
        {
            _students.Add(entity);
        }

        public bool Save(Student entity, Expression<Func<Student, bool>> predicate)
        {
            Student findStudent = (SearchFor(predicate)).FirstOrDefault();

            if (findStudent == null)
            {
                Insert(entity);
                return true;
            }
            return false;
        }

        public IList<Student> SearchFor(Expression<Func<Student, bool>> predicate)
        {
            return _students.AsQueryable().Where(predicate).ToList();
        }
    }
}
