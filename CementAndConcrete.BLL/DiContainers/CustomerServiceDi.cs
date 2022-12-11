using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.BLL.Services.DataServices;
using Ninject.Modules;

namespace CementAndConcrete.BLL.DiContainers
{
    /// <summary>
    ///     Class for dependency injection Service Customers.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class CustomerServiceDi : NinjectModule
    {
        /// <summary>
        ///     Binds the Customers service to its base interface IConsumerService.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public override void Load()
        {
            this.Bind<ICustomersService>().To<CustomerService>().InSingletonScope();
        }
    }
}