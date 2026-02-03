
public class Operation
{
    private static List<string> CartItems = new List<string>();
    static Stack<string> Action = new Stack<string>();
    public static List<string> GetCartItems()
    {
        return CartItems;
    }


   

    public static void AddItemInCart()
    {
        var items = Products.AllItems;
        string NameItem;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("==========================================");
        Console.WriteLine("           AVAILABLE PRODUCTS              ");
        Console.WriteLine("==========================================");
        Console.ResetColor();

        foreach (var item in items)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"- {item.Key,-15}");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" | ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Price: {item.Value,8} EGP");

            Console.ResetColor();
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("==========================================");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter Product Name: ");
        Console.ResetColor();

        NameItem = Console.ReadLine();

        Console.WriteLine("------------------------------------------");

        if (items.ContainsKey(NameItem))
        {
            CartItems.Add(NameItem);
            Action.Push($"Item: {NameItem} Added To Cart");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✔ {NameItem} has been added to your cart successfully!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"✖ Sorry, '{NameItem}' is not available right now.");
        }

        Console.ResetColor();
        Console.WriteLine("------------------------------------------");
    }
    public static void ViewCart()
    {
        Console.Clear();

        if (CartItems.Any())
        {
            var ItemsAndPrice = Products.GetPriceItem();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==========================================");
            Console.WriteLine("              YOUR SHOPPING CART           ");
            Console.WriteLine("==========================================");
            Console.ResetColor();

            foreach (var item in ItemsAndPrice)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"- Name: {item.Item1,-15}");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" | ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Price: {item.Item2,8} EGP");

                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==========================================");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠ Your cart is empty. Start adding products!");
            Console.ResetColor();
        }
    }

    public static void RemoveItemFromCart()
    {
        string ItemName;
        Console.Clear();

        ViewCart();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("           REMOVE ITEM FROM CART           ");
        Console.WriteLine("------------------------------------------");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter Item Name To Remove: ");
        Console.ResetColor();

        ItemName = Console.ReadLine();

        Console.WriteLine("------------------------------------------");

        if (CartItems.Contains(ItemName))
        {
            CartItems.Remove(ItemName);
            Action.Push($"Item: {ItemName} Remove From Cart");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✔ {ItemName} has been removed successfully.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"✖ {ItemName} was not found in your cart.");
        }

        Console.ResetColor();
        Console.WriteLine("------------------------------------------");
    }
    public static void CheckOut()
    {
        double price = 0;
        Console.Clear();
        if (CartItems.Any())
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==========================================");
            Console.WriteLine("                CHECKOUT                  ");
            Console.WriteLine("==========================================");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Your Cart Items:");
            Console.ResetColor();

            var ItemAndPrice = Products.GetPriceItem();

            foreach (var item in ItemAndPrice)
            {
                price += item.Item2;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"- {item.Item1,-15}");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" | ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Price: {item.Item2,8} EGP");

                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==========================================");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"TOTAL PRICE: {price} EGP");
            Console.ResetColor();

            Console.WriteLine("------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please proceed to payment.");
            Console.WriteLine("Thank you for shopping with us ");
            Console.ResetColor();

            CartItems.Clear();
            Action.Push("CheckOut");
        }
    }

    public static void UndoAction()
    {
        Console.Clear();

        if (Action.Count > 0)
        {
            string LastAction = Action.Pop();
            var ActionArr = LastAction.Split();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==========================================");
            Console.WriteLine("               UNDO ACTION                ");
            Console.WriteLine("==========================================");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Last Action: {LastAction}");
            Console.ResetColor();

            Console.WriteLine("------------------------------------------");

            if (LastAction.Contains("Added"))
            {
                CartItems.Remove(ActionArr[1]);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✔ Item '{ActionArr[1]}' has been removed (Undo Add).");
            }
            else if (LastAction.Contains("Remove"))
            {
                CartItems.Add(ActionArr[1]);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✔ Item '{ActionArr[1]}' has been added back (Undo Remove).");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("✖ Checkout cannot be undone. Please contact support for a refund.");
            }

            Console.ResetColor();
            Console.WriteLine("==========================================");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠ No actions available to undo.");
            Console.ResetColor();
        }
    }


}


