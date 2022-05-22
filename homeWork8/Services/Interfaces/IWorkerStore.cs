using homeWork8.Models;
namespace homeWork8.Services.Interfaces;

public interface IWorkerStore
{
    public void AddWorker(Worker worker);
    public void AddAddress(Address address);
    public Address? GetAddress(int Id);
}