using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.BLL.Services.DataServices;
using Ninject.Modules;

namespace CementAndConcrete.BLL.DiContainers
{
    /// <summary>
    ///     Class for dependency injection Service Table.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class TableServiceDi : NinjectModule
    {
        /// <summary>
        ///     Binds the Table service to its base interface ITableService.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public override void Load()
        {
            this.Bind<ITableService>().To<TableService>().InTransientScope();
        }
    }
}