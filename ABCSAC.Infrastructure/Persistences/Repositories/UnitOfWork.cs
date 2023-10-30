using ABCSAC.Domain.Entities;
using ABCSAC.Infrastructure.Persistences.Context;
using ABCSAC.Infrastructure.Persistences.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ABCSAC.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;

        public IGenericRepository<Empleado> _empleado = null!;
        public IGenericRepository<Afp> _afp = null!;
        public IGenericRepository<Cargo> _cargo = null!;

        public UnitOfWork(DBContext context, IConfiguration configuration)
        {
            _context = context;
        }

        public IGenericRepository<Empleado> Empleado => _empleado ?? new GenericRepository<Empleado>(_context);
        public IGenericRepository<Afp> Afp => _afp ?? new GenericRepository<Afp>(_context);
        public IGenericRepository<Cargo> Cargo => _cargo ?? new GenericRepository<Cargo>(_context);

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        
    }
}
