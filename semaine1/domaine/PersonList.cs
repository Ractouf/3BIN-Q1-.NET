namespace ex1.domaine
{
    internal class PersonList
    {
        private static PersonList _instance;
        private IDictionary<String, Person> _personMap;

        private PersonList()
        {
            _personMap = new Dictionary<String, Person>();
        }

        public static PersonList Instance
        {
            get { _instance ??= new PersonList(); return _instance; }
        }

        public void AddPerson(Person person)
        {
            if (person == null)
                throw new InvalidDataException();
            _personMap.Add(person.Name, person);
        }

        public IEnumerator<Person> PersonEnumerator()
        {
            return _personMap.Values.GetEnumerator();
        }
    }
}
