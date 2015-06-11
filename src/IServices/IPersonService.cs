using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AOPModule;
using Autofac.Extras.DynamicProxy2;
using Models;

namespace IServices
{
    [Intercept(typeof(CustomBaseInterceptor))]
    public interface IPersonService
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        void AddPerson(Person person);

        /// <summary>
        /// 获得所有用户
        /// </summary>
        IList<Person> GetPersons();
    }
}
