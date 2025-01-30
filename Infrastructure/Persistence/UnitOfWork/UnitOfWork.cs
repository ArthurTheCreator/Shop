using Infrastructure.Interface.UnitOfWOrk;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private IDbContextTransaction dbContextTransaction;
    private readonly AppDbContext _context = context;

    public void BeginTransaction()
    {
        dbContextTransaction = _context.Database.BeginTransaction();
    }

    public void Commit()
    {
        _context.SaveChanges();
        dbContextTransaction.Commit();
        dbContextTransaction.Dispose();
    }
}