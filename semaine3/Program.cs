﻿using semaine3.Models;

NorthwindContext context = new NorthwindContext();

// ex1
/*Console.Write("Enter a city name:\n");
String city = Console.ReadLine();

IQueryable<Customer> customers = from c in context.Customers 
                                 where c.City == city 
                                 select c;

foreach (Customer customer in customers) {
    Console.WriteLine("Customer: {0} : {1}", customer.CustomerId, customer.ContactName);
}*/

// ex2
/*IQueryable<Category> categories = from c in context.Categories 
                                  where c.CategoryName == "Beverages" || c.CategoryName == "Condiments"
                                  select c;

foreach (Category c in categories)
{
    Console.WriteLine("Category : {0}", c.CategoryName);

    foreach (Product p in c.Products)
    {
        Console.WriteLine("\t{0}", p.ProductName);
    }
}*/

// ex3
/*IQueryable<Category> categories = from c in context.Categories
                               .Include("Products")
                               where c.CategoryName == "Beverages" || c.CategoryName == "Condiments"
                               select c;
foreach (Category c in categories)
{
    Console.WriteLine("Category : {0}", c.CategoryName);

    foreach (Product p in c.Products)
    {
        Console.WriteLine("\t{0}", p.ProductName);
    }
}*/

// ex4
/*Console.Write("Enter a client ID:\n");
String customerID = Console.ReadLine();

var orders = from o in context.Orders
             where o.ShippedDate != null && o.Customer.CustomerId == customerID
             orderby o.OrderDate
             select new
             {
                 o.Customer.CustomerId,
                 o.OrderDate,
                 o.ShippedDate
             };

foreach (var order in orders) 
{
    Console.WriteLine("CustomerID : {0} OrderDate : {1} ShippedDate : {2}", order.CustomerId, order.OrderDate, order.ShippedDate); 
}*/

//ex 5
/*var orderDetails = from od in context.OrderDetails
                   group od by od.ProductId into grouped
                   orderby grouped.Key
                   select new
                   {
                       ProductID = grouped.Key,
                       Total = grouped.Sum(od => od.UnitPrice * od.Quantity)
                   };

foreach (var order in orderDetails) 
{ 
    Console.WriteLine("{0} ----> {1}", order.ProductID, order.Total);
}*/

//ex 6
/*IQueryable<Employee> employees = from e in context.Employees
                                 where e.Territories.Any(t => t.Region.RegionDescription.Equals("Western")) 
                                 select e;

foreach (Employee employee in employees) {
    Console.WriteLine($"{employee.FirstName} {employee.LastName}");
}*/

//ex 7
/*var territories = (from e in context.Employees 
                                    where e.LastName.Equals("Suyama") 
                                    select e.ReportsToNavigation.Territories).SingleOrDefault();

foreach (Territory territory in territories) {
    Console.WriteLine(territory.TerritoryDescription);
}*/

// ex Update
/*foreach (Customer customer in (from c in context.Customers select c))
{
    customer.ContactName = customer.ContactName.ToUpper();
}

context.SaveChanges();

foreach (Customer customer in (from c in context.Customers select c))
{ 
    Console.WriteLine(customer.ContactName);
}*/

// ex Insert
/*Console.WriteLine("Veuillez entrer le nom d'une catégorie a ajouter");
String categoryName = Console.ReadLine();

Category category = new Category();
category.CategoryName = categoryName;

context.Categories.Add(category);
context.SaveChanges();

Console.WriteLine((from c in context.Categories where c.CategoryName == categoryName select c).SingleOrDefault().CategoryName);*/

// ex Delete 1-2
/*Category damien = (from c in context.Categories
                     where c.CategoryName == "DAMIEN"
                     select c).SingleOrDefault();

context.Categories.Remove(damien);
context.SaveChanges();

IQueryable<Category> verify = from c in context.Categories
                              where c.CategoryName == "DAMIEN"
                              select c;

if (verify.IsNullOrEmpty()) Console.WriteLine("Category was successfully removed");
else Console.WriteLine("Category was not removed");*/

// ex Delete 3-4
/*Console.WriteLine("Veuillez entrer l'ID de l'employé a supprimer: ");
int removeID = Int32.Parse(Console.ReadLine());
Employee removeEmployee = (from e in context.Employees where e.EmployeeId == removeID select e).SingleOrDefault();

Console.WriteLine("Veuillez entrer l'ID de l'employé qui récupère les Orders: ");
int addID = Int32.Parse(Console.ReadLine());
Employee addEmployee = (from e in context.Employees where e.EmployeeId == addID select e).SingleOrDefault();

IQueryable<Order> orders = from o in context.Orders
                           where o.EmployeeId == removeID
                           select o;

foreach (Order order in orders)
{
    order.EmployeeId = addID;
    order.Employee = addEmployee;
}

context.Remove(removeEmployee);
// does not work because you need to delete cascade but I could not bother to do it
context.SaveChanges();

foreach (Order order in (from o in context.Orders select o))
{ 
    Console.WriteLine(order.EmployeeId);
}*/
