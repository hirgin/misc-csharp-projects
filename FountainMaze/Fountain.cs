
Game game = new Game();
game.run();




class Game // Class that holds game logic 
{
    
    public Grid gameGrid { get; }
    public Fountain fountain { get; }
    public Player player { get; }

    public Game()
    {
        gameGrid = new Grid();
        fountain = new Fountain();
        player = new Player();
    }

    public void checkRoom()
    {
        if (gameGrid._grid[player.x, player.y] == "fountain")
        {
            if (fountain.onState) { Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!"); }
            else { Console.WriteLine("You hear water drippin in this room. The Fountain of Objects is here!"); }
        }
        if (gameGrid._grid[player.x, player.y] == "entrance")
        {
            Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.");
        }
    }
    public bool gameEnd()
    {
        if (fountain.onState && player.x == 0 && player.y == 0)
        {
            Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!");
            return true;
        }
        else return false;
    }

    public void displayPlayer()
    {
        Console.WriteLine($"You are in the room at (Row = {player.x}, Column = {player.y})");
    }

    public void userChoice()
    {
        Console.Write("What do you want to do? ");
        string userInput = Console.ReadLine();
        if (userInput == "move east") { player.movePlayer("east"); return; }
        if (userInput == "move west") { player.movePlayer("west"); return; }
        if (userInput == "move north") { player.movePlayer("north"); return; }
        if (userInput == "move south") { player.movePlayer("south"); return; }
        if (userInput == "enable fountain" && player.x == 0 && player.y == 2) { fountain.enableFountain(); return; }

    }

    public void run()
    {
        while (!gameEnd())
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
            displayPlayer();
            checkRoom();
            userChoice();
            gameEnd();
        }
    }
}

class GameObject // Generic class for all game objects to have
{
    public int x { get; protected set; }
    public int y { get; protected set; }
    public static bool isOOB(int x, int y) => (x < 0 || y < 0 || x > 3 || y > 3) ? false : true; // if it is out of bounds, return false, else return true

}

class Fountain : GameObject
{
    public Fountain()
    {
        x = 0; y = 2;
    }
    public bool onState { get; private set; } = false;

    public void enableFountain()
    {
        onState = true;
    }
}
class Player : GameObject
{
   public Player() 
    {
        x = 0; 
        y = 0;    
    }
    public void movePlayer(string direction)
    {
        if (direction == "north" && isOOB(x + 1, y) != false) { x += 1; }
        else if(direction == "south" && isOOB(x - 1, y) != false){ x -= 1; }
        else if (direction == "west" && isOOB(x, y - 1) != false) { y -= 1; }
        else if (direction == "east" && isOOB(x, y + 1) != false) { y +=1; }
    }

    
}

class Grid
{
    public string[,] _grid = new string[4,4];

    public Grid() 
    {
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                _grid[i, j] = "empty";
            }
        }
        _grid[0, 0] = "entrance";
        _grid[0, 2] = "fountain";
    }



}