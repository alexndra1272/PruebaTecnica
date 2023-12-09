using System;
using Backend.Data.DTOs;
using Backend.Data.Models;

namespace Backend.Repository;

public interface IFacturaRepository : IGenericRepository<Factura>
{
    Task<IEnumerable<FacturaDTO>> GetFacturasWithDetailsAsync();
}


