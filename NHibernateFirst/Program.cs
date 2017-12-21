using System;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace NHibernateFirst
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static ISession OpenSession()
        {
            if (sessionFactory == null)
            {
                Configuration c = new Configuration();
                c.AddAssembly(Assembly.GetCallingAssembly());
                sessionFactory = c.BuildSessionFactory();
            }
            return sessionFactory.OpenSession();
        }

        static void CreateEmployeeAndSaveToDatabase(Employee e)
        {
            var employee = e;

            using (ISession session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(employee); // jesli zapisujemy encje bez id to w tym momencie (wywolanie metody Save)
                                            // spowoduje wydenerowanie tego id (klucza glownego, unikalnego)
                    transaction.Commit();
                }
                Console.WriteLine("Saved " + employee.name + " to the database");
            }
        }

        private static ISessionFactory sessionFactory;
    }
}
