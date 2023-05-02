namespace Inventory_Management_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.inventory = FileManager.LoadInventory();
            while (true)
            {
                Console.WriteLine("Enter 1 to add\nEnter 2 to Remove\nEnter 3 to Print");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        inventoryManagement.Add();
                        break;
                    case 2:
                        inventoryManagement.Remove();
                        break;
                    case 3:
                        inventoryManagement.Print();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }

            }
        }
    }
}