namespace ex1.domaine
{
    [Serializable]
    internal class Director : Person
    {
        private static readonly long _serialVersionUID = 5952964360274024205L;
        private List<Movie> _directedMovies;

        public Director(string name, string firstname, DateTime birthDate) : base(name, firstname, birthDate)
        {
            _directedMovies = new List<Movie>();
        }

        public Boolean AddMovie(Movie movie) {
            if (_directedMovies.Contains(movie))
                return false;

            if (movie.Director == null)
                movie.Director = this;

            _directedMovies.Add(movie);

            return true;
        }

        public IEnumerator<Movie> Movies()
        {
            return _directedMovies.GetEnumerator();
        }
    }
}
