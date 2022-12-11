using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.BLL.Services.DataServices;
using Ninject.Modules;

namespace CementAndConcrete.BLL.DiContainers
{
    /// <summary>
    ///     Class for dependency injection Service Builder.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class BuilderServiceDi : NinjectModule
    {
        /// <summary>
        ///     Binds the Builder service to its base interface IBuilderService.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public override void Load()
        {
            this.Bind<IBuilderService>().To<BuilderService>().InTransientScope();
        }
    }
}