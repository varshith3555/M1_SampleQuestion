using System;
using System.Collections.Generic;
using System.Linq;

public class CakeOrder
{
    private Dictionary<string, double> orderMap = new Dictionary<string, double>();
    public void addOrderDetails(String orderld, double cakeCost)
    {
        orderMap[orderld] = cakeCost;
    }
    public Dictionary<string, double> findOrdersAboveSpecifiedCost(double cakeCost)
    {
        return orderMap.Where (x => x.Value > cakeCost).ToDictionary(x => x.Key, x => x.Value);
    }
}

public class Cake
{
    public static void Main()
    {
        CakeOrder c = new CakeOrder();
        System.Console.WriteLine("Enter number of cake orders to be added");
        int n = int.Parse(Console.ReadLine()!);

        System.Console.WriteLine("Enter the cake order details (Order Id: CakeCost)");  
        for(int i = 1; i <= n; i++)
        {
            string? input = Console.ReadLine();
            if (input != null)
            {
                string[] parts = input.Split(":");
                if (parts.Length == 2)
                {
                    c.addOrderDetails(parts[0], double.Parse(parts[1]));
                }
            }
        }

        System.Console.WriteLine("Enter the cost to search the cake orders");
        double cost = double.Parse(Console.ReadLine()!);
        
        Dictionary<string, double> result = c.findOrdersAboveSpecifiedCost(cost);
        
        if (result.Count > 0)
        {
            System.Console.WriteLine("Cake Orders above the specified cost");
            foreach (var order in result)
            {
                System.Console.WriteLine($"Order ID: {order.Key}, Cake Cost: {order.Value}");
            }
        }
        else
        {
            System.Console.WriteLine("No orders found above the specified cost");
        }
    }
}