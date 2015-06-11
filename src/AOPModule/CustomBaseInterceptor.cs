using Castle.DynamicProxy;
using LogModule;

namespace AOPModule
{
    /// <summary>
    /// 自定义拦截器
    /// </summary>
    public class CustomBaseInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            BeforeProceed(invocation);
            invocation.Proceed();
            AfterProceed();
        }

        protected virtual void BeforeProceed(IInvocation invocation)
        {
            LogHelper.WriteMsg("调用方法："+invocation.Method.Name);
        }

        protected virtual void AfterProceed()
        {
            
        }
    }
}