using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.BLL.Services.DataServices;
using Ninject.Modules;

namespace CementAndConcrete.BLL.DiContainers
{
    /// <summary>
    ///     Class for dependency injection Service Order.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class OrderServiceDi : NinjectModule
    {
        /// <summary>
        ///     Binds the Order service to its base interface IOrderService.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public override void Load()
        {
            this.Bind<IOrderService>().To<OrderService>().InTransientScope();
        }
    }
}