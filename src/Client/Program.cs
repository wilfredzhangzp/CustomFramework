using System;
using AOPModule;
using IServices;
using LogModule;
using Models;

namespace Client
{
    class Program
    {

        static void Main(string[] args)
        {
            LogHelper.WriteMsg("调用方法：");
            AopLoader.Register();  
            Person personA = new Person(){FirstName = "z",LastName = "p"};
            Person personB = new Person() { FirstName = "c", LastName = "m" };
            IPersonService personService = IocContainer.GetInstance<IPersonService>();
            personService.AddPerson(personA);
            personService.AddPerson(personB);
            var persons = personService.GetPersons();
            Console.ReadKey();
        }
    }
}
