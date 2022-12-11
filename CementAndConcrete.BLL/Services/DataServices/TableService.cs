using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.DAL.Entities;
using CementAndConcrete.DAL.Interfaces;
using CementAndConcrete.Domain.Enums;
using CementAndConcrete.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace CementAndConcrete.BLL.Services.DataServices
{
    /// <summary>
    ///     Class for dependency injection Service TableService.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class TableService : ITableService
    {
        /// <summary>
        ///     Contains all repositories.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TableService" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="unitOfWork"> Contains all repositories</param>
        public TableService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     Map data from Table to TableDto to create a new database entry.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item"> Contains the Table object</param>
        public void Create(Table item)
        {
            try
            {
                this.Validate(item);

                TableDto? table = new MapperConfiguration(cfg => cfg.CreateMap<Table, TableDto>())
                    .CreateMapper()
                    .Map<TableDto>(item);
                this.unitOfWork.Tables.Create(table);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't add table {e.Message}");
            }
        }

        /// <summary>
        ///     Map data from Table to TableDto to delete a new database entry.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the Table object</param>
        public void Delete(Guid id)
        {
            try
            {
                this.unitOfWork.Tables.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't delete table {e.Message}");
            }
        }

        /// <summary>
        ///     Map data from Table to TableDto to get needed record from database.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">The base model object identifier</param>
        /// <returns>The Table object</returns>
        public Table Get(Guid id)
        {
            try
            {
                Table? table = this.GetAll().FirstOrDefault(x => x.Id == id);

                return table != null && table.Name.IsNullOrEmpty() ? table : new Table(TableCategories.Default);
            }
            catch (Exception exception)
            {
                throw new Exception($"Unable to get table title. {exception.Message}");
            }
        }

        /// <summary>
        ///     Map data from Table to TableDto to get records from database.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>List of Table objects</returns>
        public IEnumerable<Table> GetAll()
        {
            try
            {
                var tables = new MapperConfiguration(
                        cfg => cfg.CreateMap<TableDto, Table>())
                    .CreateMapper()
                    .Map<List<Table>>(this.unitOfWork.Tables.GetAll());

                return tables;
            }
            catch (Exception exception)
            {
                throw new ArgumentException($"Cannot get list of tables. {exception.Message}");
            }
        }

        /// <summary>
        ///     Map data from Table to TableDto to update a new database entry.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">Contains the Table object</param>
        public void Update(Table item)
        {
            try
            {
                this.Validate(item);

                TableDto? disc = new MapperConfiguration(cfg => cfg.CreateMap<Table, TableDto>())
                    .CreateMapper()
                    .Map<TableDto>(item);
                this.unitOfWork.Tables.Update(disc);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't update table {e.Message}");
            }
        }

        /// <summary>
        ///     Validates the Table provided.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">The Table to be validated</param>
        private void Validate(Table item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (string.IsNullOrEmpty(item.Name))
            {
                throw new ValidationException("Incorrect name");
            }

            try
            {
                this.unitOfWork.Tables.Get(item.Id);
            }
            catch
            {
                throw new Exception("There is no such table");
            }
        }
    }
}