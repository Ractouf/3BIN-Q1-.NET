using LINQDataContext;

DataContext dc = new DataContext();

Student? jdepp = (from student in dc.Students
                  where student.Login == "jdepp"
                  select student).SingleOrDefault();

if (jdepp != null)
{
    Console.WriteLine(jdepp.First_Name + " " + jdepp.Last_Name);
}


//ex 2.2
var QueryResult22 = from Student s in dc.Students
                  select new { 
                      Nom = s.Last_Name + " " + s.First_Name, 
                      Id = s.Student_ID, 
                      BirthDate = s.BirthDate
                  };

//ex 2.2 avec Méthodes
/*var QueryResult = dc.Students.Select(s => 
    new {
        Nom = s.Last_Name + " " + s.First_Name,
        Id = s.Student_ID,
        BirthDate = s.BirthDate
    });*/

foreach (var student in QueryResult22)
{
    Console.WriteLine($"{student.Nom}\nID: {student.Id}\nBirth date: {student.BirthDate}\n");
}

//ex 3.1
var QueryResult31 = from Student s in dc.Students
                  where s.BirthDate.Year < 1955
                  select new {
                    Nom = s.First_Name,
                    Result = s.Year_Result,
                    Statut = s.Year_Result >= 12 ? "OK" : "KO" 
                  };

/*var QueryResult = dc.Students
    .Where(s => s.BirthDate.Year < 1955)
    .Select(s => {
        new {
            Nom = s.First_Name,
            Result = s.Year_Result,
            Statut = s.Year_Result >= 12 ? "OK" : "KO"
        }
    });*/

foreach (var student in QueryResult31)
{
    Console.WriteLine($"{student.Nom}\nResult: {student.Result}\nStatut: {student.Statut}\n");
}