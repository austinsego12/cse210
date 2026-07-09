using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = new List<Order>();

        // First customer lives in the USA.
        Address address1 = new Address(
            "4820 Maple Ridge Drive",
            "Saint Louis",
            "Missouri",
            "USA"
        );

        Customer customer1 = new Customer(
            "Austin Sego",
            address1
        );

        Order order1 = new Order(customer1);

        Product product1 = new Product(
            "Arduino Uno Starter Kit",
            "ARD-1001",
            39.99,
            1
        );

        Product product2 = new Product(
            "PIR Motion Sensor",
            "SNS-2044",
            7.50,
            2
        );

        Product product3 = new Product(
            "LED and Resistor Pack",
            "ELE-330R",
            4.25,
            1
        );

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        orders.Add(order1);


        // Second customer lives outside the USA.
        Address address2 = new Address(
            "18 Riverbend Lane",
            "Toronto",
            "Ontario",
            "Canada"
        );

        Customer customer2 = new Customer(
            "Megan Carter",
            address2
        );

        Order order2 = new Order(customer2);

        Product product4 = new Product(
            "Wireless Keyboard",
            "KEY-7782",
            28.95,
            1
        );

        Product product5 = new Product(
            "USB-C Hub",
            "USB-4421",
            32.49,
            2
        );

        order2.AddProduct(product4);
        order2.AddProduct(product5);

        orders.Add(order2);


        // Display each order.
        foreach (Order order in orders)
        {
            Console.WriteLine("========================================");
            Console.WriteLine(order.GetPackingLabel());

            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();

            Console.WriteLine(
                $"Total Price: ${order.GetTotalCost():0.00}"
            );

            Console.WriteLine();
        }
    }
}