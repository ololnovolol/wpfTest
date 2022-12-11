using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.DAL.Entities;
using CementAndConcrete.DAL.Interfaces;
using CementAndConcrete.Domain.Models;

namespace CementAndConcrete.BLL.Services.DataServices
{
    /// <summary>
    ///     Class for dependency injection Service ConsumerService.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class CustomerService : ICustomersService
    {
        /// <summary>
        ///     Contains all repositories.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CustomerService" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="unitOfWork"> Contains all repositories</param>
        public CustomerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     Map data from Customers to CustomerDto to create a new database entry.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item"> Contains the Customers object</param>
        public void Create(Customer item)
        {
            try
            {
                this.Validate(item);

                CustomerDto? consumer = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDto>())
                    .CreateMapper()
                    .Map<CustomerDto>(item);
                this.unitOfWork.Consumers.Create(consumer);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't add Customers object {e.Message}");
            }
        }

        /// <summary>
        ///     Map data from Customers to CustomerDto to delete a new database entry.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the Customers object</param>
        public void Delete(Guid id)
        {
            try
            {
                this.unitOfWork.Consumers.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't delete consumer object {e.Message}");
            }
        }

        /// <summary>
        ///     Map data from Customers to CustomerDto to get needed record from database.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">The base model object identifier</param>
        /// <returns>The Customers object</returns>
        public Customer Get(Guid id)
        {
            try
            {
                Customer? consumer = this.GetAll().FirstOrDefault(x => x.Id == id);

                if (consumer != null)
                {
                    return consumer;
                }

                string empty = string.Empty;

                return new Customer(empty, empty, empty, empty, empty, empty, empty);
            }
            catch (Exception exception)
            {
                throw new Exception($"Unable to get Customers object. {exception.Message}");
            }
        }

        /// <summary>
        ///     Map data from Customers to CustomerDto to get records from database.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>List of Customers objects</returns>
        public IEnumerable<Customer> GetAll()
        {
            try
            {
                var consumers = new MapperConfiguration(
                        cfg => cfg.CreateMap<CustomerDto, Customer>())
                    .CreateMapper()
                    .Map<List<Customer>>(this.unitOfWork.Consumers.GetAll());

                return consumers;
            }
            catch (Exception exception)
            {
                throw new ArgumentException($"Cannot get list of Customers. {exception.Message}");
            }
        }

        /// <summary>
        ///     Map data from Customers to CustomerDto to update a new database entry.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">Contains the Customers object</param>
        public void Update(Customer item)
        {
            try
            {
                this.Validate(item);

                CustomerDto? consumer = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDto>())
                    .CreateMapper()
                    .Map<CustomerDto>(item);
                this.unitOfWork.Consumers.Update(consumer);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't update consumer object {e.Message}");
            }
        }

        /// <summary>
        ///     Validates the Customers provided.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">The Customers to be validated</param>
        private void Validate(Customer item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (string.IsNullOrEmpty(item.Phone) ||
                string.IsNullOrEmpty(item.Street) ||
                string.IsNullOrEmpty(item.City) ||
                string.IsNullOrEmpty(item.Country) ||
                string.IsNullOrEmpty(item.Apartment))
            {
                throw new ValidationException("Incorrect Consumers data something with parameters is empty");
            }

            try
            {
                this.unitOfWork.Consumers.Get(item.Id);
            }
            catch
            {
                throw new Exception("There is no such Customers object");
            }
        }
    }
}