using CRUDProject.Data;
using System;

namespace CRUDProject.Interfaces
{
    public interface IRentalService
    {
        Task<Rental> Create(Rental customer);
        Task<Rental> Update(Rental customer);
        Task<bool> Delete(int id);
        Task<Rental> GetCustomerById(int id);
        Task<IEnumerable<Rental>> GetAllCustomers();
    }
}
