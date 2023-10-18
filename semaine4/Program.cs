using semaine4.Models;
using semaine4.Repository;

SchoolContext context = new SchoolContext();

BaseRepositorySQL<Student> repo = new BaseRepositorySQL<Student>(context);

Student studentAdd = new Student();
studentAdd.Name = "Lapinski";
studentAdd.Firstname = "Damien";
studentAdd.YearResult = 1;

repo.Insert(studentAdd);

IList<Student> result = repo.GetAll();

foreach (Student student in result) {
    Console.WriteLine(student.Name);
}
