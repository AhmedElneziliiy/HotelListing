using HotelListing.Data;
using HotelListing.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepositoy<Hotel> _hotels;
        private IGenericRepositoy<Country> _countries;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepositoy<Country> Countries => _countries ??= new GenericRepositoy<Country>(_context);

        public IGenericRepositoy<Hotel> Hotels => _hotels ??= new GenericRepositoy<Hotel>(_context) ;


        public void Dispose()
        {
            //Dispose like a garbage collector that free up the memory
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
