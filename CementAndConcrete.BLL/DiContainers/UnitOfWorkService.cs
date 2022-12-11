using CementAndConcrete.DAL.Interfaces;
using CementAndConcrete.DAL.UnitOfWorks;
using Ninject.Modules;

namespace CementAndConcrete.BLL.DiContainers
{
    /// <summary>
    ///     Class for dependency injection Service UnitOfWork.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class UnitOfWorkService : NinjectModule
    {
        /// <summary>
        ///     Contains Connection path to database.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UnitOfWorkService" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="connectionString"> Contains the path to database.</param>
        public UnitOfWorkService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        ///     Binds the UnitOfWork service to its base interface IUnitOfWork.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public override void Load()
        {
            this.Bind<IUnitOfWork>()
                .To<UnitOfWork>()
                .InTransientScope()
                .WithConstructorArgument(this.connectionString);
        }
    }
}