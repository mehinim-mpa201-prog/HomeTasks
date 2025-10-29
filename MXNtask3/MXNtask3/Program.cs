using System.ComponentModel;
using System.Net.Security;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;



namespace MXNtask3;

internal class Program
{
    static void Main(string[] args)
    {
        Category cat1 = new Category(1, "Sushi");

        Dish dish1 = new Dish(1, "Philadelphia", 17);
        Dish dish2 = new Dish(2, "Sika maki", 15);

        dish1.Category = cat1;
        dish2.Category = cat1;

        Restaurant restaurant = new Restaurant();
        restaurant.AddDishToMenu(dish1);
        restaurant.AddDishToMenu(dish2);


        Dish[] orderDishes = { dish1, dish2 };

        Order order1 = new Order(1);
        order1.Dishes = orderDishes;
        order1.CalculateTotal();
        restaurant.PlaceOrder(order1);

        Console.WriteLine($"Total price of order: {order1.TotalAmount}");

        Dish[] all = { dish1, dish2 };
        Dish.FindDishesByCategory(all, cat1);

        Console.WriteLine($"Dishes found in category {cat1.Name} ");
    }
}

class Dish
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public Category Category { get; set; }


    public Dish(int id, string name, double price)
    {
        Id = id;
        Name = name;
        Price = price;


    }

  
    public Dish[] FindDishesByCategory(Dish[] allDishes,int categoryId)
    {
        Dish[] filteredDishes = new Dish[allDishes.Length]; 
       
        for (int i = 0; i < allDishes.Length; i++)
        {
            if (allDishes[i] != null)
            {
                if (allDishes[i].Category.Id == categoryId)
                {
                    filteredDishes[i] = allDishes[i];
                }
            }
            
        }
        return filteredDishes;
        
    }

    public static void FindDishesByCategory(Dish[] allDishes, Category category)
    {
        for (int i = 0; i < allDishes.Length; i++)
        {
            if (allDishes[i].Category == category)
            {
                Console.WriteLine(allDishes[i].Name);
            }
        }
    }
}
class Category
{
    
    public int Id { get; set; }
    public string Name { get; set; }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;

    }
}

class Order
{
    public int Id { get; set; }
    public Dish[] Dishes { get; set; }

    public double TotalAmount { get; set; }

    public Order(int id)
    {
        Id = id;
        Dishes = []; 

    }
    public void CalculateTotal()
    {
        double sum = 0;
        for (int i = 0; i < Dishes.Length; i++)
        {
            if (Dishes[i] != null)
            {
                sum += Dishes[i].Price;
            }
        }
        TotalAmount = sum;
    }
}
class Restaurant
{
    public string Name { get; set; }
    public string Address { get; set; }

    public Dish[] Menu { get; set; }
    public Order[] Orders { get; set; }


    public Restaurant()
    {
        Menu = new Dish[] {

                new Dish(1, "Big mac", 11),
                new Dish(2, "Filetofish", 15)
            };
        Orders = new Order[0];
    }
    public void AddDishToMenu(Dish dish)
    {
        Dish[] newMenu = new Dish[Menu.Length + 1];
        for (int i = 0; i < Menu.Length; i++)
        {
            newMenu[i] = Menu[i];
        }
        newMenu[Menu.Length] = dish;
        Menu = newMenu;
    }
    public void PlaceOrder(Order order)
    {
        Order[] newOrders = new Order[Orders.Length + 1];
        for (int i = 0; i < Orders.Length; i++)
        {
            if (Orders[i] != null)
            {
                newOrders[i] = Orders[i];
            }
        }
        newOrders[Orders.Length] = order;
        Orders = newOrders;
    }

} 

