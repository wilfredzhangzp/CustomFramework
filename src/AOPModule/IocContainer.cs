namespace AOPModule
{
    public class IocContainer
    {
        public static T GetInstance<T>()
        {
            return IocUtil.GetInstance<T>();
        }
    }
}