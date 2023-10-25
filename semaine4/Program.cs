using semaine4.Models;
using semaine4.Repository;

SchoolContext context = new SchoolContext();

BaseRepositorySQL<Section> sectionRepo = new BaseRepositorySQL<Section>(context);
BaseRepositorySQL<Student> studentRepo = new BaseRepositorySQL<Student>(context);

int sections = 0;
while (sections < 2) 
{
    Console.WriteLine("Veuillez entrer le nom de la section :");
    String name = Console.ReadLine();

    Section section = new()
    {
        Name = name
    };

    bool result = sectionRepo.Save(section, section => section.Name.Equals(name));

    if (!result) 
    {
        Console.WriteLine("Cette section existe déjà");
        continue;
    }

    Console.WriteLine("La section a été ajoutée");
    sections++;
}

int students = 0;
while (students < 3)
{
    Console.WriteLine("Veuillez entrer le firstname de l'étudant :");
    String firstname = Console.ReadLine();
    Console.WriteLine("Veuillez entrer le lastname de l'étudiant :");
    String lastname = Console.ReadLine();
    Console.WriteLine("Veuillez entrer le year result de l'étudiant :");
    String yearResult = Console.ReadLine();
    Console.WriteLine("Veuillez entrer la section de l'étudiant");
    String sectionName = Console.ReadLine();

    Section section = (from s in sectionRepo.GetAll()
                      where s.Name == sectionName
                      select s).SingleOrDefault();

    if (section == null)
    {
        Console.WriteLine("Cette section n'existe pas");
        continue;
    }

    Student student = new()
    {
        Firstname = firstname,
        Name = lastname,
        YearResult = long.Parse(yearResult),
        Section = section
    };

    bool result = studentRepo.Save(student, student => student.Name.Equals(lastname) || student.Firstname.Equals(firstname));

    if (!result)
    {
        Console.WriteLine("Cet étudiant existe déjà");
        continue;
    }

    Console.WriteLine("L'étudiant a été ajouté");
    students++;
}
