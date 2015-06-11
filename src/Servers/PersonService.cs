using System.Collections.Generic;
using System.Linq;
using IServices;
using Models;
using WrappedDapper;

namespace Services
{
    //[Intercept(typeof(CustomBaseInterceptor))]
    public class PersonService:IPersonService
    {
        private Repository<Person> _repository;

        public PersonService()
        {
            _repository = new Repository<Person>();
        }
        public virtual void AddPerson(Person person)
        {
            _repository.Insert(person);
        }

        public virtual IList<Person> GetPersons()
        {
            return _repository.GetAll().ToList();
        }
    }
}
