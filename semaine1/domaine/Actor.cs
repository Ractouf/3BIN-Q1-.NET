namespace ex1.domaine
{
    [Serializable]
    internal class Actor : Person
    {
        private static readonly long _serialVersionUID = 1L;
        private readonly int _sizeInCentimeter;
        private List<Movie> _movies;

        public Actor(string name, string firstname, DateTime birthDate, int sizeInCentimeter) : base(name, firstname, birthDate)
        {
            _sizeInCentimeter = sizeInCentimeter;
            _movies = new List<Movie>();
        }

        public int SizeInCentimeter
        { 
            get { return _sizeInCentimeter; }
        }

        public override String Name
        {
            get { return base.Name.ToUpper(); }
        }

        public Boolean AddMovie(Movie movie)
        {
            if ((movie == null) || _movies.Contains(movie))
                return false;

            if (!movie.ContainsActor(this))
                movie.AddActor(this);

            _movies.Add(movie);

            return true;
        }

        public Boolean ContainsMovie(Movie movie)
        {
            return _movies.Contains(movie);
        }

        public IEnumerator<Movie> Movies()
        { 
            return _movies.GetEnumerator();
        }

        public override string ToString()
        {
            return "Actor [name = " + base.Name + ", firstname = " + base.FirstName + ", size in centimeter = " + _sizeInCentimeter + ", birthdate = " + base.BirthDate + "]";
        }
    }
}
