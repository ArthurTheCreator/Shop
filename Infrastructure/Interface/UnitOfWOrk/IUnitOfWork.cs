namespace Infrastructure.Interface.UnitOfWOrk;

public interface IUnitOfWork
{
    void BeginTransaction();
    void Commit();
}