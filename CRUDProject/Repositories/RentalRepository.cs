using CRUDProject.Data;
using CRUDProject.DBContext;
using CRUDProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace CRUDProject.Repositories
{
    public class RentalRepository:IRentalService
    {
        private readonly AppDbContext _context;
        public RentalRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Rental> Create(Rental customer)
        {
            _context.Rentals.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        public async Task<Rental> Update(Rental customer)
        {
            var existingPerson = await _context.Rentals.FindAsync(customer.rental_id);
            if (existingPerson == null)
            {
                return null;
            }

            existingPerson.film_title = customer.film_title;
            existingPerson.film_category = customer.film_category;

            _context.Rentals.Update(existingPerson);
            await _context.SaveChangesAsync();
            return existingPerson;
        }
        public async Task<bool> Delete(int id)
        {
            var customer = await _context.Rentals.FindAsync(id);
            if (customer == null)
            {
                return false;
            }

            _context.Rentals.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Rental> GetCustomerById(int id)
        {
            return await _context.Rentals.FindAsync(id);
        }

        public async Task<IEnumerable<Rental>> GetAllCustomers()
        {
            return await _context.Rentals.ToListAsync();
        }
    }
}
