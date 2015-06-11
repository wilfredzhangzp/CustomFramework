using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using Castle.Core.Internal;

namespace AOPModule
{
    /// <summary>
    /// 注册和获取
    /// </summary>
    public static class AopLoader
    {
        public static void Register()
        {
            IocUtil.RegisterType<CustomBaseInterceptor>();
            IocUtil.RegisterAssembly(Assembly.Load("Services")).AsImplementedInterfaces().
                EnableInterfaceInterceptors();  
        }
    }
}
