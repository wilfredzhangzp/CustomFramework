using System;
using System.Reflection;
using Autofac;
using Autofac.Builder;
using Autofac.Extras.DynamicProxy2;
using Autofac.Features.Scanning;

namespace AOPModule
{
    public class IocUtil
    {
        private static ContainerBuilder _containerBuilder;
        private static IContainer _container;

        static IocUtil()
        {
            _containerBuilder =new ContainerBuilder();
        }
        #region -- SingleInstance

        public static void RegisterTypeSingleInstance<T>()
        {
            RegisterType<T>().AsSelf().SingleInstance();
        } 

        public static void RegisterTypeSingleInstance<T1,T2>()
        {
            RegisterType<T1>().As<T2>().SingleInstance();
        }

        public static T GetInstance<T>()
        {
            if (_container == null)
            {
                _container =_containerBuilder.Build();
            }
            return _container.Resolve<T>();
        }

        #endregion

        #region AOP enable

        /// <summary>
        /// 注册AOP 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void RegisterTypeAop(Type type)
        {
            RegisterType(type).EnableClassInterceptors();

        }

        public static void RegisterTypeAop(Type type1,Type type2)
        {
            RegisterType(type1).As(type2).EnableClassInterceptors();
        }

        /// <summary>
        /// 注册AOP 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void RegisterTypeAop<T>()
        {
            RegisterType<T>().EnableClassInterceptors();

        }

        public static void RegisterTypeAop<T1, T2>()
        {
            RegisterType<T1>().As<T2>().EnableClassInterceptors();
        }

        /// <summary>
        /// 注册AOP以及实现的拦截器
        /// </summary>
        /// <typeparam name="T">注册的类</typeparam>
        public static void RegisterTypeAop<T>(params Type[] interceptors)
        {
            RegisterType<T>().EnableClassInterceptors().InterceptedBy(interceptors);
        }
        

        #endregion

        #region -- Use for extention

        /// <summary>
        /// 返回注册的信息，用于扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IRegistrationBuilder<T, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterType<T>()
        {
            return _containerBuilder.RegisterType<T>();
        }

        public static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterType(Type type)
        {
            return _containerBuilder.RegisterType(type);
        }

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterAssembly(params Assembly[] assemblies)
        {
            return _containerBuilder.RegisterAssemblyTypes(assemblies);
        }

        #endregion

    }
}
