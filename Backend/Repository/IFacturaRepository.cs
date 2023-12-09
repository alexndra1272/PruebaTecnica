using System;
using Backend.Data.Models;

namespace Backend.Repository;

public interface IFacturaRepository : IGenericRepository<Factura>
{ 
    Task<IEnumerable<Factura>> GetFacturasWithDetailsAsync();
}


