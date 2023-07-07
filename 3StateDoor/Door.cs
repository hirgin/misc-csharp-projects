
Door kitchen = new Door("151");

while(true)
{
    Console.WriteLine($"The door is currently {kitchen.state}");
    Console.WriteLine("Would you like to open, close, lock, or unlock the door?");
    string userInput = Console.ReadLine();
    switch (userInput)
    {
        case "open": kitchen.openDoor(); break;
        case "close": kitchen.closeDoor(); break;
        case "lock": kitchen.lockDoor(); break;
        case "unlock": kitchen.unlockDoor(); break;
    }
}

class Door
{

    public DoorState state {  get; private set; }
    private string doorCode;

    public Door(string userCode)
    {
        doorCode = userCode;
        state = DoorState.Closed;
    }

    

    public void openDoor()
    {
        if (state == DoorState.Open) { Console.WriteLine("The door is already open."); return; }
        if (state == DoorState.Locked) { Console.WriteLine("The door is locked."); return; }
        else 
        { 
            Console.WriteLine("You have opened the door");
            state = DoorState.Open;
        }
    }

    public void closeDoor()
    {
        if (state == DoorState.Closed) { Console.WriteLine("The door is already closed."); return; }
        if (state == DoorState.Locked) { Console.WriteLine("The door is already closed and locked."); return; }
        else 
        { 
            Console.WriteLine("You have closed the door");
            state = DoorState.Closed;
        }
    }

    public void lockDoor()
    {
        if(state == DoorState.Locked) { Console.WriteLine("The door is already locked"); return; }
        if(state == DoorState.Open) { Console.WriteLine("The door is open."); return; }
        else 
        { 
            Console.WriteLine("The door is now locked.");
            state = DoorState.Locked;
        }
    }

    public void unlockDoor()
    {
        if (state == DoorState.Locked)
        {
            Console.WriteLine("Enter the code to unlock the door.");
            if(validCode(Console.ReadLine()))
            {
                Console.WriteLine("You have successfully unlocked the door");
                state = DoorState.Open;
                return;
            }
            else { Console.WriteLine("You have input the wrong code."); return; }

        }
        else { Console.WriteLine("The door is not locked."); }
    }

    public void changeCode()
    {
        Console.WriteLine("Enter the door code.");
        if(validCode(Console.ReadLine()) ) 
        { 
            Console.WriteLine("Please enter your new desired passcode");
            doorCode = Console.ReadLine();
            return;
        }
        else
        {
            Console.WriteLine("You have input the wrong code.");
        }
    }

    bool validCode(string userEntry)
    {
        if(userEntry == doorCode)
        {  return true; }
        else { return false; }
    }


    public enum DoorState { Open, Closed, Locked }

}