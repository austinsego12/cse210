using System;

class Program
{
    static void Main()
    {
        Address a1 = new Address("123 Maple St", "Rexburg", "ID", "USA");
        Customer c1 = new Customer("Alex Carter", a1);

        Address a2 = new Address("55 King Road", "Toronto", "ON", "Canada");
        Customer c2 = new Customer("Sofia Nguyen", a2);

        Product p1 = new Product("Wireless Mouse", "WM-100", 19.99, 2);
        Product p2 = new Product("Mechanical Keyboard", "MK-200", 89.50, 1);
        Product p3 = new Product("USB C Cable", "UC-300", 7.25, 3);

        Order order1 = new Order(c1);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        Order order2 = new Order(c2);
        order2.AddProduct(p3);
        order2.AddProduct(new Product("Laptop Stand", "LS-400", 29.99, 1));

        Console.WriteLine("Online Ordering\n");

        Console.WriteLine("ORDER 1");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order1.GetTotalCost():0.00}");
        Console.WriteLine("\n----------------------------\n");

        Console.WriteLine("ORDER 2");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order2.GetTotalCost():0.00}");
        Console.WriteLine();
    }
}

