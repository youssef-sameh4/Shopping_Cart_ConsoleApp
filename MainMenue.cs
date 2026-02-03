public class MainMenue
{
    enum EChoose { EAdd = 1, EView, ERemove, ECheck, EUndo, EExit }
    public static void Menue()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===================================================");
        Console.WriteLine("🛒🛍️  WELCOME TO YOUR SHOPPING CART SYSTEM  🛍️🛒");
        Console.WriteLine("===================================================");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("[1] Add Item To Cart");
        Console.WriteLine("[2] View Cart");
        Console.WriteLine("[3] Remove Item From Cart");
        Console.WriteLine("[4] Check Out");
        Console.WriteLine("[5] Undo Last Action");
        Console.WriteLine("[6] Exit");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===============================================");
        Console.ResetColor();
    }

    public static void Main_Menu()
    {
        while (true)
        {
            Console.Clear();
            int choose = 0;

            Menue();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Choose a number from the list: ");
            Console.ResetColor();

            choose = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch ((EChoose)choose)
            {
                case EChoose.EAdd:
                    Operation.AddItemInCart();
                    break;

                case EChoose.EView:
                    Operation.ViewCart();
                    break;

                case EChoose.ERemove:
                    Operation.RemoveItemFromCart();
                    break;

                case EChoose.ECheck:
                    Operation.CheckOut();
                    break;

                case EChoose.EUndo:
                    Operation.UndoAction();
                    break;

                case EChoose.EExit:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thank you for using our system. Goodbye 👋");
                    Console.ResetColor();
                    Environment.Exit(0);
                    break;
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine();
            Console.WriteLine("Press ENTER to return to menu...");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}


