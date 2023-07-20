Game start = new Game();
start.initGame(8,8);
class Map
{
    private roomType[,] _map;
    public int _col { get; }
    public int _row { get; }
    

    public Map(int row, int col)
    {
        _col = col;
        _row = row;
        
        _map = new roomType[_row, _col]; // initialize map
        changeRoom(0, 0, roomType.Entrance);
        setRooms();
        for (int i = 0; i < _row; i++)
        {
            for (int j = 0; j < _col; j++)
            {
                Console.Write($"{_map[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    private void setRooms()
    {
        if (_col == 4) { changeRoom(rGen.genRandom(_col), rGen.genRandom(_col), roomType.Pits); } // create 1 pit randomly in map

        if (_col == 6) // create 2 pits randomly in map
        {
            for (int i = 0; i < 2; i++)
            {
                changeRoom(rGen.genRandom(_col), rGen.genRandom(_col), roomType.Pits);
            }
        } 

        if (_col == 8) // create 4 pits randomly in map
        {
            for (int i = 0; i < 4; i++)
            {
                changeRoom(rGen.genRandom(_col), rGen.genRandom(_col), roomType.Pits);

            }
        }

        changeRoom(rGen.genRandom(_col), rGen.genRandom(_col), roomType.Fountain);

    }


    public bool inBounds(int x, int y) // function checks if spot is legal and in bounds
    {
        if (x < 0 || y < 0 || x > _row || y > _col)
        {
           
            return false;
        }
        return true;
    }

    public void changeRoom(int x, int y, roomType room) // check if room is in bounds and change type
    {
        if (inBounds(x,y))
        {
            _map[x,y] = room;
        }
    }

}

class rGen
{
    public static int genRandom(int size) // random number generator
    {
        var random = new Random();
        int randomNumber = random.Next(0, size);
        return randomNumber;
    }
    
  
}
class Game
{
    public Map map;

    public string mapSize { get; private set; }
    public void initGame(int row, int col)
    {
        map = new Map(row, col);
        
    }
}
public record Coordinates(int col, int row);

enum roomType { Empty, Fountain, Pits, Maelstrom, Entrance, OOB }
