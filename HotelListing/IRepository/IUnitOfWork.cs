using HotelListing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepositoy<Hotel> Hotels { get; }
        IGenericRepositoy<Country> Countries { get; }
        void Save();
    }
}
