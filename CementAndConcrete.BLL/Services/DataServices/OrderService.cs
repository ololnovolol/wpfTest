using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.DAL.Entities;
using CementAndConcrete.DAL.Interfaces;
using CementAndConcrete.Domain.Models;

namespace CementAndConcrete.BLL.Services.DataServices
{
    /// <summary>
    ///     Class for dependency injection Service OrderService.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class OrderService : IOrderService
    {
        /// <summary>
        ///     Contains all repositories.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="OrderService" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="unitOfWork"> Contains all repositories</param>
        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     Map data from Order to OrderDto to create a new database entry.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item"> Contains the Order object</param>
        public void Create(Order item)
        {
            try
            {
                this.Validate(item);

                OrderDto? order = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>())
                    .CreateMapper()
                    .Map<OrderDto>(item);
                this.unitOfWork.Orders.Create(order);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't add Order object {e.Message}");
            }
        }

        /// <summary>
        ///     Map data from Order to OrderDto to delete a new database entry.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the Order object</param>
        public void Delete(Guid id)
        {
            try
            {
                this.unitOfWork.Orders.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't delete Order object {e.Message}");
            }
        }

        /// <summary>
        ///     Map data from Order to OrderDto to get needed record from database.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">The base model object identifier</param>
        /// <returns>The Order object</returns>
        public Order Get(Guid id)
        {
            try
            {
                Order? order = this.GetAll().FirstOrDefault(x => x.Id == id);

                return order ?? new Order(Guid.NewGuid(), DateTime.MinValue, DateTime.MaxValue, decimal.Zero);
            }
            catch (Exception exception)
            {
                throw new Exception($"Unable to get Order object. {exception.Message}");
            }
        }

        /// <summary>
        ///     Map data from Order to OrderDto to get records from database.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>List of Order objects</returns>
        public IEnumerable<Order> GetAll()
        {
            try
            {
                var orders = new MapperConfiguration(
                        cfg => cfg.CreateMap<OrderDto, Order>())
                    .CreateMapper()
                    .Map<List<Order>>(this.unitOfWork.Orders.GetAll());

                return orders;
            }
            catch (Exception exception)
            {
                throw new ArgumentException($"Cannot get list of Orders. {exception.Message}");
            }
        }

        /// <summary>
        ///     Map data from Order to OrderDto to update a new database entry.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">Contains the Order object</param>
        public void Update(Order item)
        {
            try
            {
                this.Validate(item);

                OrderDto? order = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>())
                    .CreateMapper()
                    .Map<OrderDto>(item);
                this.unitOfWork.Orders.Update(order);
            }
            catch (Exception e)
            {
                throw new Exception($"Can't update Order object {e.Message}");
            }
        }

        /// <summary>
        ///     Validates the Order provided.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">The Order to be validated</param>
        private void Validate(Order item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (item.TotalPrice < 0)
            {
                throw new ValidationException("Incorrect Order TotalPrice");
            }

            if (string.IsNullOrEmpty(item.Name) ||
                string.IsNullOrEmpty(item.CustomerId.ToString()))
            {
                throw new ValidationException("Incorrect Order data something with parameters is empty");
            }

            try
            {
                this.unitOfWork.Orders.Get(item.Id);
            }
            catch
            {
                throw new Exception("There is no such Order object");
            }
        }
    }
}