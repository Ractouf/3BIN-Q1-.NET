namespace ex1.domaine
{
    internal class Movie
    {
        private String _title;
        private int _releaseYear;
        private List<Actor> _actors;
        private Director _director;

        public Movie(String title, int releaseYear)
        {
            _actors = new List<Actor>();
            _title = title;
            _releaseYear = releaseYear;
        }

        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public int ReleaseYear
        {
            get { return _releaseYear; }
            set { _releaseYear = value; }
        }

        public Director Director
        {
            get { return _director; }
            set 
            { 
                if (value == null) 
                    return; 

                _director = value;
                _director.AddMovie(this);
            }
        }

        public Boolean AddActor(Actor actor)
        {
            if (_actors.Contains(actor))
                return false;

            _actors.Add(actor);
            if (!actor.ContainsMovie(this))
                actor.AddMovie(this);

            return true;
        }

        public Boolean ContainsActor(Actor actor)
        {
            return _actors.Contains(actor);
        }

        public override string ToString()
        {
            return "Movie [title = " + _title + ", releaseYear = " + _releaseYear + "]";
        }
    }
}
