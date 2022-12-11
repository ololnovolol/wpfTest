using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.BLL.Services.DataServices;
using Ninject.Modules;

namespace CementAndConcrete.BLL.DiContainers
{
    /// <summary>
    ///     Class for dependency injection Service Material.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class MaterialServiceDi : NinjectModule
    {
        /// <summary>
        ///     Binds the Material service to its base interface IMaterialService.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public override void Load()
        {
            this.Bind<IMaterialService>().To<MaterialService>().InTransientScope();
        }
    }
}