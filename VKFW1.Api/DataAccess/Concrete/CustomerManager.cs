using VKFW1.Api.DataAccess.Abstract;
using VKFW1.Api.DataAccess.DB;
using VKFW1.Api.Entities;
using VKFW1.Api.Models;

namespace VKFW1.Api.DataAccess.Concrete;

public class CustomerManager : ICustomerService
{
    public void Add(CustomerCreateRequestModel model)
    {
        CustomerDB.Add(model);
    }

    public void Delete(long id)
    {
        CustomerDB.Delete(id);
    }

    public void UpdatePatch(long id, string name, string surname)
    {
        CustomerDB.UpdatePatch(id,name,surname);
    }

    public void Update(Customer customer)
    {
        CustomerDB.Update(customer);
    }

    public List<Customer> GetList(string? name, string order = "ASC")
    {
        return CustomerDB.GetList(name, order);
    }

    public Customer GetById(long id)
    {
        return CustomerDB.GetById(id);
    }
}