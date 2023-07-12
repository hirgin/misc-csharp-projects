Pack userPack = new Pack();

while(true)
{
    Console.WriteLine("Here are the following items you can put into your pack.");
    Console.WriteLine("1. Arrow\n2. Bow\n3. Rope\n4. Water\n5. Food\n6. Sword");
    Console.WriteLine("Please enter the number of which item you would like to put in your bag or '7' if you would like the view whats in the bag.");
    int userInput = Convert.ToInt32(Console.ReadLine());

    switch (userInput)
    {
        case 1:
            userPack.Add(new Arrow());
            break;
        case 2:
            userPack.Add(new Bow());
            break;
        case 3:
            userPack.Add(new Rope());
            break;
        case 4:
            userPack.Add(new Water());
            break;
        case 5:
            userPack.Add(new Food());
            break;
        case 6:
            userPack.Add(new Sword());
            break;
        case 7:
            userPack.packWatch();
            break;
    }
   



   
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
        foreach (InventoryItem item in pack)
        {
            if (item == null) { break; }
            Console.WriteLine($"{item}");
        }
            Console.WriteLine($"The amount of items in the bag is {checkItems()}.");
        Console.WriteLine($"The current weight of the bag is {checkWeight()}.");
        Console.WriteLine($"The current volume of the bag is {checkVolume()}.\n");

    }

}



