using VKFW1.Api.Entities;
using VKFW1.Api.Enums;
using VKFW1.Api.Extensions;
using VKFW1.Api.Models;

namespace VKFW1.Api.DataAccess.DB;

public class CustomerDB
{
    public static List<Customer> customers = new List<Customer>
    {
        new()
        {
            Id = 1,
            Name = "Jack",
            Surname = "London",
            IdentificationNumber = "12345678912",
            Address = "England",
            Age = 25,
            Gender = Gender.Male
        },
        new()
        {
            Id = 2,
            Name = "Yasar",
            Surname = "Kemal",
            IdentificationNumber = "98098765432",
            Address = "Turkey",
            Age = 50,
            Gender = Gender.Male
        }
    };

    public static Customer GetById(long id)
    {
        return customers.Find(c => c.Id == id);
    }

    public static List<Customer> GetList(string? name, string order = "ASC")
    {
        return order == "ASC"
            ? customers.Where(c => (name == null || c.Name.ToLower().Contains(name.ToLower())))
                .OrderBy(c => c.Id).ToList()
            : customers.Where(c => (name == null || c.Name.ToLower().Contains(name.ToLower())))
                .OrderByDescending(c => c.Id).ToList();
    }

    public static void Add(CustomerCreateRequestModel model)
    {
        Customer customer = new Customer()
        {
            Name = model.Name.ArrangeName(model.Gender),
            Surname = model.Surname,
            IdentificationNumber = model.IdentificationNumber,
            Address = model.Address,
            Age = model.Age,
            Gender = model.Gender
        };
        customers.Add(customer);
    }

    public static void Delete(long id)
    {
        var entity = customers.Find(c => c.Id == id);

        if (entity != null)
        {
            customers.Remove(entity);
        }
    }

    public static void UpdatePatch(long id,string name, string surname)
    {
        var entity = customers.Find(c => c.Id == id);

        if (entity != null)
        {
            entity.Name = name.ArrangeName(entity.Gender);
            entity.Surname = surname;
        }
    }

    public static void Update(Customer customer)
    {
        var entity = customers.Find(c => c.Id == customer.Id);

        if (entity != null)
        {
            entity.Id = customer.Id;
            entity.Name = customer.Name.ArrangeName(customer.Gender);
            entity.Surname = customer.Surname;
            entity.IdentificationNumber = customer.IdentificationNumber;
            entity.Address = customer.Address;
            entity.Age = customer.Age;
            entity.Gender = customer.Gender;
        }
    }
}