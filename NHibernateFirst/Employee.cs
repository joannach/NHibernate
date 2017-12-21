namespace NHibernateFirst
{
    class Employee
    {
        public int id;      //daje dostep do identity z bazy (primary key) trwałego obiektu
        public string name;
        public Employee manager;

        public string SayHello()
        {
            return $"Cos tam cos tam, said {name} ";
        }
    }
}
