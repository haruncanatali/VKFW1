using VKFW1.Api.Entities;
using VKFW1.Api.Models;

namespace VKFW1.Api.DataAccess.Abstract;

public interface ICustomerService
{ 
    void Add(CustomerCreateRequestModel model);
    void Delete(long id);
    void UpdatePatch(long id, string name, string surname);
    void Update(Customer customer);
    List<Customer> GetList(string? name, string order = "ASC");
    Customer GetById(long id);
}