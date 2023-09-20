namespace ex1.domaine
{
    [Serializable]
    internal class Person
    {
        private static readonly long _serialVersionUID = 1L;

        private readonly String _name;
	    private readonly String _firstname;
	    private readonly DateTime _birthDate;

        public Person(String name, String firstname, DateTime birthDate)
        {
            _name = name;
            _firstname = firstname;
            _birthDate = birthDate;
        }

        public virtual String Name
        {
            get { return _name; }
        }
        public String FirstName
        {
            get { return _firstname; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
        }

        public override String ToString()
        {
            return "Person [name =  " + _name + ", firstname = " + 
                _firstname + ", birthDate = " + _birthDate;
        }
    }
}
