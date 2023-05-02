using Inventory_Management_Program;
using Newtonsoft.Json;
using System.Net.Http;

// rice pulse wheat
public class Grains
{
    public string Brand { get; set; }
    public int Quantity { get; set; }
    public int PricePerKG { get; set; }

    public override string ToString()
    {
        return $"                     Brand: {Brand} Quantity: {Quantity} PricePerKG: {PricePerKG}\n";
    }
}
public class Inventory
{
    public List<Grains> Wheat { get; set; }
    public List<Grains> Pulse { get; set; }
    public List<Grains> Rice { get; set; }
    public Inventory()
    {
        Wheat = new List<Grains>();
        Pulse = new List<Grains>();
        Rice = new List<Grains>();
    }
   

    public int TotalWieght { get; set; }
    public int TotalCost { get; set; }
    public override string ToString()
    {
        string pulse = "Pulse:-->\n"; Pulse.ForEach(x => pulse += x.ToString());
        string rice = "Rice:-->\n"; Rice.ForEach(x => rice += x.ToString());
        string wheat = "Wheat:-->\n"; Wheat.ForEach(x => wheat += x.ToString());
        return pulse + rice + wheat + $"TotalCost: {TotalCost} TotalWeight: {TotalWieght}";
    }
}
public class InventoryManagement
{
    public Inventory inventory { get; set; }
    public InventoryManagement()
    {
        this.inventory = new Inventory();
    }
    public void Add()
    {
        Console.WriteLine("Enter W to Add Wheat\nEnter R to Add Rice\nEnter P to add Pulse");
        char ch = Console.ReadLine()[0];
        switch (ch)
        {
            case 'W':
                var data = this.TakeInPuts(); inventory.TotalCost += data.Quantity * data.PricePerKG; inventory.TotalWieght += data.Quantity;
                this.inventory.Wheat.Add(data); FileManager.Save(this.inventory);
                break;
            case 'R':
                data = this.TakeInPuts(); inventory.TotalCost += data.Quantity * data.PricePerKG; inventory.TotalWieght += data.Quantity;
                this.inventory.Rice.Add(data); FileManager.Save(this.inventory);
                break;
            case 'P':
                data = this.TakeInPuts(); inventory.TotalCost += data.Quantity * data.PricePerKG; inventory.TotalWieght += data.Quantity;
                this.inventory.Pulse.Add(data); FileManager.Save(this.inventory);
                break;
            default:
                Console.WriteLine("Invalid Input");
                break;
        }
    }
    public void Remove()
    {
        Console.WriteLine("Enter W to delete Wheat\nEnter R to delete Rice\nEnter P to delete Pulse");
        char ch = Console.ReadLine()[0];
        string brand = Console.ReadLine();
        int sum = inventory.TotalCost;
        int weight = inventory.TotalWieght;
        switch (ch)
        {
            case 'W':
                foreach (Grains s in inventory.Wheat)
                {
                    if (s.Brand.Equals(brand))
                    {
                        sum -= (s.PricePerKG*s.Quantity);
                        weight -= (s.Quantity);
                        inventory.Wheat.Remove(s);
                        FileManager.Save(this.inventory);
                        break;
                    }
                }

                break;
            case 'R':
                foreach (Grains s in inventory.Rice)
                {
                    if (s.Brand.Equals(brand))
                    {
                        sum -= (s.PricePerKG * s.Quantity);
                        weight -= (s.Quantity);
                        inventory.Rice.Remove(s);
                        FileManager.Save(this.inventory);
                        break;
                    }
                }

                break;
            case 'P':
                foreach (Grains s in inventory.Pulse)
                {
                    if (s.Brand.Equals(brand))
                    {
                        sum -= (s.PricePerKG * s.Quantity);
                        weight -= (s.Quantity);
                        inventory.Pulse.Remove(s);
                        FileManager.Save(this.inventory);
                        break;
                    }
                }

                break;
            default:
                Console.WriteLine("Invalid Input");
                break;
        }
        inventory.TotalCost = sum;
        inventory.TotalWieght = weight;


    }
    private Grains TakeInPuts()
    {
        Grains g = new Grains();
        Console.WriteLine("Enter Brand Name");
        g.Brand = Console.ReadLine();
        Console.WriteLine("Enter PricePerKG: ");
        g.PricePerKG = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the Quantity");
        g.Quantity = int.Parse(Console.ReadLine());
        return g;
    }
   
    public void Print()
    {
        Console.WriteLine(inventory.ToString());
    }
}
