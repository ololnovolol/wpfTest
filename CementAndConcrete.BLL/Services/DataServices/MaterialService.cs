using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.DAL.Entities;
using CementAndConcrete.DAL.Interfaces;
using CementAndConcrete.Domain.Models;

namespace CementAndConcrete.BLL.Services.DataServices
{
    /// <summary>
    ///     Class for dependency injection Service MaterialService.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class MaterialService : IMaterialService
    {
        /// <summary>
        ///     Contains all repositories.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MaterialService" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="unitOfWork"> Contains all repositories</param>
        public MaterialService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     Map data from Material to MaterialDto to create a new database entry.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item"> Contains the Material object</param>
        public void Create(Material item)
        {
            try
            {
                this.Validate(item);

                MaterialDto? material = new MapperConfiguration(cfg => cfg.CreateMap<Material, MaterialDto>())
                    .CreateMapper()
                    .Map<MaterialDto>(item);
                this.unitOfWork.Materials.Create(material);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't add Material object {e.Message}");
            }
        }

        /// <summary>
        ///     Map data from Material to MaterialDto to delete a new database entry.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the Material object</param>
        public void Delete(Guid id)
        {
            try
            {
                this.unitOfWork.Materials.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't delete Material object {e.Message}");
            }
        }

        /// <summary>
        ///     Map data from Material to MaterialDto to get needed record from database.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">The base model object identifier</param>
        /// <returns>The Material object</returns>
        public Material Get(Guid id)
        {
            try
            {
                Material? material = this.GetAll().FirstOrDefault(x => x.Id == id);

                if (material != null)
                {
                    return material;
                }

                string empty = string.Empty;

                return new Material(string.Empty, default, default);
            }
            catch (Exception exception)
            {
                throw new Exception($"Unable to get Material object. {exception.Message}");
            }
        }

        /// <summary>
        ///     Map data from Material to MaterialDto to get records from database.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>List of Material objects</returns>
        public IEnumerable<Material> GetAll()
        {
            try
            {
                var materials = new MapperConfiguration(
                        cfg => cfg.CreateMap<MaterialDto, Material>())
                    .CreateMapper()
                    .Map<List<Material>>(this.unitOfWork.Materials.GetAll());

                return materials;
            }
            catch (Exception exception)
            {
                throw new ArgumentException($"Cannot get list of Materials. {exception.Message}");
            }
        }

        /// <summary>
        ///     Map data from Material to MaterialDto to update a new database entry.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">Contains the Material object</param>
        public void Update(Material item)
        {
            try
            {
                this.Validate(item);

                MaterialDto? material = new MapperConfiguration(cfg => cfg.CreateMap<Material, MaterialDto>())
                    .CreateMapper()
                    .Map<MaterialDto>(item);
                this.unitOfWork.Materials.Update(material);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't update Material object {e.Message}");
            }
        }

        /// <summary>
        ///     Validates the Material provided.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">The Material to be validated</param>
        private void Validate(Material item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (item.Amount < 0 || item.Price < 0)
            {
                throw new ValidationException("Incorrect Material Amount or Price cant been < 0");
            }

            try
            {
                this.unitOfWork.Materials.Get(item.Id);
            }
            catch
            {
                throw new Exception("There is no such Material object");
            }
        }
    }
}