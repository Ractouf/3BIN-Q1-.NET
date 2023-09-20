using ex1.domaine;

namespace ex1.client
{
    internal class Test
    {
        public static void Main(String[] args)
        {
            Actor[] myActors =  {
                new ( "Assange", "Julian", new DateTime(1961, 7, 3), 187),
                new ( "Paul", "Newmann", new DateTime(1925, 1, 26), 187),
                new ( "Becker", "Norma Jean", new DateTime(1926, 6, 1), 187)
            };

            Director[] myDirectors = {
                new ("Spielberg", "Steven", new DateTime(1946, 12, 18)),
                new ("Coen", "Ettan", new DateTime(1957, 9, 21)),
                new ("Coppolla", "Francis Ford", new DateTime(1939, 4, 7))
            };

            Movie bigLebow = new("The Big Lebowski", 1996);
            Movie eT = new("E.T.", 1982);

            eT.AddActor(myActors[0]);
            eT.AddActor(myActors[2]);
            eT.Director = myDirectors[0];

            bigLebow.AddActor(myActors[1]);
            bigLebow.AddActor(myActors[2]);
            bigLebow.Director = myDirectors[1];

            PersonList myPersons = PersonList.Instance;

            foreach (Actor act in myActors)
            {
                myPersons.AddPerson(act);
            }

            foreach (Director director in myDirectors)
            {
                myPersons.AddPerson(director);
            }

            IEnumerator<Person> ActorIt = myPersons.PersonEnumerator();

            while (ActorIt.MoveNext())
            {
                Person person = ActorIt.Current;
                Console.WriteLine(person);

                IEnumerator<Movie> MoviesIt;
                if (person is Actor)
                {
                    Console.WriteLine("a joué dans les films suivants :");
                    MoviesIt = ((Actor)person).Movies();
                }
                else
                {
                    if (person is Director)
                    {
                        Console.WriteLine("a dirigé les films suivants :");
                        MoviesIt = ((Director)person).Movies();
                    }
                    else
                    {
                        Console.WriteLine("est inconnu et n'a rien à faire ici !!! ");
                        continue;
                    }
                }
                while (MoviesIt.MoveNext())
                {
                    Movie movie = MoviesIt.Current;
                    Console.WriteLine(movie);
                }
            }
        }
    }
}
