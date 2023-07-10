Pack userPack = new Pack();

while(true)
{
    Console.WriteLine("Type 1 to add a sword to the pack.");
    Console.WriteLine("Type 2 to see what is in the bag.");

    userPack.packWatch();
    Sword sword = new Sword();
    userPack.Add(sword);
    userPack.Add(sword);
    userPack.Add(sword);
    userPack.packWatch();

    break;
}
class InventoryItem
{
    public double _weight, _volume;
    public InventoryItem(double weight, double volume)
    {
        _weight = weight;
        _volume = volume;
    }
}


class Arrow : InventoryItem
{
    public Arrow() : base(0.1, 0.05) { }
        
}

class Bow : InventoryItem
{
    public Bow() : base(1.0,4.0) { }
}

class Food : InventoryItem
{
    public Food() : base(1.0, 0.5) { }
}

class Rope : InventoryItem
{
    public Rope() : base(1.0, 1.5) { }
}

class Sword : InventoryItem
{
    public Sword() : base(5.0, 3.0) { }
}

class Water : InventoryItem
{
    public Water() : base(2.0, 3.0) { }
}

class Pack
{
    InventoryItem[] pack = new InventoryItem[5];
    private double maxWeight = 10;
    private double maxVolume = 10;
    private int itemsCount = 0;
    private bool checkWeight (double itemWeight)
    {
        double currentWeight = 0;
        foreach (InventoryItem item in pack) 
        {
            if ((currentWeight + itemWeight) > maxWeight) { return false; }
            if (item == null) { return true; }
            currentWeight+= item._weight;
        }
        
      
      return true; 
    }

    private double checkWeight()
    {
        double currentWeight = 0;
       
        foreach (InventoryItem item in pack)
        {
            if(item == null) { return currentWeight; }
            currentWeight += item._weight;
         
        }
        return currentWeight;
    }

    private bool checkVolume(double itemVolume)
    {
        double currentVolume = 0;
        foreach (InventoryItem item in pack)
        {
            if ((currentVolume + itemVolume) > maxVolume) { return false; }
            if (item == null) { return true; }
            currentVolume += item._volume;
        }
         return true; 
    }

    private double checkVolume()
    {
        double currentVolume = 0;
        foreach (InventoryItem item in pack)
        {
            if (item == null){return currentVolume;}
            currentVolume += item._volume;
            
        }

        return currentVolume;
    }

    public bool Add(InventoryItem item)
    {
        if(!(checkWeight(item._weight))) { Console.WriteLine("Item weighs too much to be put in the pack."); return false; }

        if(!(checkVolume(item._volume))) { Console.WriteLine("Item's volume is too much to be put in the pack."); return false; }
        if (pack[4] != null)
        {
            Console.WriteLine("Pack is full. Cannot add item."); return false;
        }
        else
        {
            pack[itemsCount] = item;
            itemsCount++;
            return true;
        }
    }

    public double checkItems()
    {
        double currentItems = 0;
        foreach (InventoryItem item in pack)
        {
            if(item != null) { currentItems++; }
            else { return currentItems; }
        }

        return currentItems;
    }

    public void packWatch()
    {
        Console.WriteLine($"The amount of items in the bag is {checkItems()}.");
        Console.WriteLine($"The current weight of the bag is {checkWeight()}.");
        Console.WriteLine($"The current volume of the bag is {checkVolume()}.");
        
    }

}
