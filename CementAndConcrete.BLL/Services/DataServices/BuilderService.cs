using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.DAL.Entities;
using CementAndConcrete.DAL.Interfaces;
using CementAndConcrete.Domain.Models;

namespace CementAndConcrete.BLL.Services.DataServices
{
    /// <summary>
    ///     Class for dependency injection Service BuilderService.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class BuilderService : IBuilderService
    {
        /// <summary>
        ///     Contains all repositories.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BuilderService" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="unitOfWork"> Contains all repositories</param>
        public BuilderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     Map data from Builder to BuilderDto to create a new database entry.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item"> Contains the Builder object</param>
        public void Create(Builder item)
        {
            try
            {
                this.Validate(item);

                BuilderDto? builder = new MapperConfiguration(cfg => cfg.CreateMap<Builder, BuilderDto>())
                    .CreateMapper()
                    .Map<BuilderDto>(item);
                this.unitOfWork.Builders.Create(builder);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't add Builder object {e.Message}");
            }
        }

        /// <summary>
        ///     Map data from Builder to BuilderDto to delete a new database entry.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the Builder object</param>
        public void Delete(Guid id)
        {
            try
            {
                this.unitOfWork.Builders.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't delete Builder object {e.Message}");
            }
        }

        /// <summary>
        ///     Map data from Builder to BuilderDto to get needed record from database.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">The base model object identifier</param>
        /// <returns>The Builder object</returns>
        public Builder Get(Guid id)
        {
            try
            {
                Builder? builder = this.GetAll().FirstOrDefault(x => x.Id == id);

                if (builder != null)
                {
                    return builder;
                }

                string empty = string.Empty;

                return new Builder(empty, empty, empty, default);
            }
            catch (Exception exception)
            {
                throw new Exception($"Unable to get Builder object. {exception.Message}");
            }
        }

        /// <summary>
        ///     Map data from Builder to BuilderDto to get records from database.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>List of Builder objects</returns>
        public IEnumerable<Builder> GetAll()
        {
            try
            {
                var builders = new MapperConfiguration(
                        cfg => cfg.CreateMap<BuilderDto, Builder>())
                    .CreateMapper()
                    .Map<List<Builder>>(this.unitOfWork.Builders.GetAll());

                return builders;
            }
            catch (Exception exception)
            {
                throw new ArgumentException($"Cannot get list of Builders. {exception.Message}");
            }
        }

        /// <summary>
        ///     Map data from Builder to BuilderDto to update a new database entry.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">Contains the Builder object</param>
        public void Update(Builder item)
        {
            try
            {
                this.Validate(item);

                BuilderDto? builder = new MapperConfiguration(cfg => cfg.CreateMap<Builder, BuilderDto>())
                    .CreateMapper()
                    .Map<BuilderDto>(item);
                this.unitOfWork.Builders.Update(builder);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't update Builder object {e.Message}");
            }
        }

        /// <summary>
        ///     Validates the Builder provided.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">The Builder to be validated</param>
        private void Validate(Builder item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (string.IsNullOrWhiteSpace(item.Phone) ||
                string.IsNullOrWhiteSpace(item.Skill.ToString()))
            {
                throw new ValidationException("Incorrect Builder data something with parameters is empty");
            }

            try
            {
                this.unitOfWork.Builders.Get(item.Id);
            }
            catch
            {
                throw new Exception("There is no such Builder object");
            }
        }
    }
}