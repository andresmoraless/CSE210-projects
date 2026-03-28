using System;
using System.Collections.Generic;

/* 
I exceeded requirements by adding a detailed cost breakdown for each order.
In addition to the required total cost, I created separate methods to calculate
the products subtotal and shipping cost, and displayed all three values in the
output to make it more specific.
*/

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Andy Morales", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P100", 899.99, 1));
        order1.AddProduct(new Product("Mouse", "P101", 24.99, 2));
        order1.AddProduct(new Product("Keyboard", "P102", 49.99, 1));

        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Sofia Ramirez", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Headphones", "P200", 79.99, 1));
        order2.AddProduct(new Product("Phone Charger", "P201", 19.99, 3));

        List<Order> orders = new List<Order>();
        orders.Add(order1);
        orders.Add(order2);

        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Lives in USA: {order.GetCustomer().LivesInUSA()}");
            Console.WriteLine($"Products Total: ${order.GetProductsTotal():F2}");
            Console.WriteLine($"Shipping Cost: ${order.GetShippingCost():F2}");
            Console.WriteLine($"Total Price: ${order.GetTotalCost():F2}");
            Console.WriteLine("-----------------------------------");
        }
    }
}