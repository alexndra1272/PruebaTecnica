using System;
using Backend.Repository;
namespace Backend.UnitofWork;


public interface IUnitOfWork : IDisposable
{
    IPersonaRepository Personas { get; }
    IFacturaRepository Facturas { get; }

    // Agrega otras propiedades de repositorios según sea necesario

    Task CompleteAsync();
}