using LINQDataContext;

DataContext dc = new DataContext();

//ex 1
/*Student? jdepp = (from student in dc.Students
                  where student.Login == "jdepp"
                  select student).SingleOrDefault();*/


//ex 1 avec méthodes
/*Student? jdepp = dc.Students.SingleOrDefault(student => student.Login == "jdepp");*/

/*if (jdepp != null)
{
    Console.WriteLine(jdepp.First_Name + " " + jdepp.Last_Name);
}*/




//ex 2.2
/*var QueryResult = from Student s in dc.Students
                  select new { 
                      Nom = s.Last_Name + " " + s.First_Name, 
                      Id = s.Student_ID, 
                      BirthDate = s.BirthDate
                  };*/


//ex 2.2 avec méthodes
/*var QueryResult = dc.Students.Select(s => 
    new {
        Nom = s.Last_Name + " " + s.First_Name,
        Id = s.Student_ID,
        BirthDate = s.BirthDate
    });*/

/*foreach (var student in QueryResult)
{
    Console.WriteLine($"{student.Nom}\nID: {student.Id}\nBirth date: {student.BirthDate}\n");
}*/




//ex 3.1
/*var QueryResult = from Student s in dc.Students
                  where s.BirthDate.Year < 1955
                  select new {
                    Nom = s.First_Name,
                    Result = s.Year_Result,
                    Statut = s.Year_Result >= 12 ? "OK" : "KO" 
                  };*/


//ex 3.1 avec méthodes
/*var QueryResult = dc.Students
    .Where(s => s.BirthDate.Year < 1955)
    .Select(s => new {
        Nom = s.First_Name,
        Result = s.Year_Result,
        Statut = s.Year_Result >= 12 ? "OK" : "KO"
    });*/

/*foreach (var student in QueryResult)
{
    Console.WriteLine($"{student.Nom}\nResult: {student.Result}\nStatut: {student.Statut}\n");
}*/




//ex 3.4
/*var QueryResult = from Student s in dc.Students
                    orderby s.Year_Result descending
                    select new
                    {
                        Nom = s.First_Name,
                        Result = s.Year_Result
                    };*/


//ex 3.4 avec méthodes
/*var QueryResult = dc.Students
    .OrderByDescending(s => s.Year_Result)
    .Select(s => new {
        Nom = s.First_Name,
        Result = s.Year_Result
    });*/

/*foreach (var student in QueryResult)
{
    Console.WriteLine($"{student.Nom}\nResult: {student.Result}\n");
}*/




//ex 4.1
/*var average = (from Student s in dc.Students
               select s.Year_Result).Average();*/


//ex 4.1 avec méthodes
/*var average = dc.Students.Average(s => s.Year_Result);*/

/*Console.WriteLine(average);*/




//ex 4.5
/*var nbLines = (from Student s in dc.Students
               select s).Count();*/


//ex 4.5 avec méthodes
/*var nbLines = dc.Students.Count();*/

/*Console.WriteLine(nbLines);*/




//ex 5.1
var QueryResult = from Student s in dc.Students
                  group s by s.Section_ID into grouped
                  select new
                  {
                      SectionID = grouped.Key,
                      MaxYearResult = grouped.Max(s => s.Year_Result)
                  };


//ex 5.1 avec méthodes
/*var QueryResult = dc.Students.GroupBy(s => s.Year_Result).Select(s => new { SectionID = s.Key, MaxYearResult = s.Max(s => s.Year_Result) });*/

foreach (var student in QueryResult)
{
    Console.WriteLine($"Section : {student.SectionID}\nMaxResult: {student.MaxYearResult}\n");
}