using ABCSAC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCSAC.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Empleado> Empleado { get; }
        IGenericRepository<Afp> Afp { get; }
        IGenericRepository<Cargo> Cargo { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
