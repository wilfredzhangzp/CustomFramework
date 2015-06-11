using AOPModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer
{
    public class IocContainer
    {
        public static T GetInstance<T>()
        {
            return IocUtil.GetInstance<T>();
        }
    }
}
