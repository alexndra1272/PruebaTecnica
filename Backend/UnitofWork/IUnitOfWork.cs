using System;
using Backend.Repository;
namespace Backend.UnitofWork;


public interface IUnitOfWork : IDisposable
{
    IPersonaRepository Personas { get; }

    // Agrega otras propiedades de repositorios según sea necesario

    Task CompleteAsync();
}