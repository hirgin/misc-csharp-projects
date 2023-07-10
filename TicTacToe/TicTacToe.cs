
Game tictactoe = new Game();
tictactoe.startGame();


class Board 
{
    public char[,] board { get; private set; } = new char[3, 3];

    public Board()
    {
        clearBoard(); // set board to default empty values
    }

    public void displayBoard() // write out outline of board and player moves included
    {
        Console.WriteLine("-------------");
        for(int i = 0; i < 3; i++) 
        {
            Console.WriteLine($"| {board[i,0]} | {board[i,1]} | {board[i,2]} |");
            Console.WriteLine("-------------");
        }
    }

    public void changeBoard(int x, int y, Player player)
    {
        board[x, y] = player.type; // add player move to board space
    }

    private void clearBoard() // set board to empty ' '
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }
    }

}

class Player
{
    public char type { get; private set; }
    public Player(char type) // set type (x or y)
    {
        this.type = type;
    }


    public bool chooseMove( Game gName, Board bName) // player inputs move, if valid it moves to that location, if not then re input
    {
        Console.WriteLine($"Player {this.type} please choose where to move on the board using grid coordinates. (Example: \"1 3\")");
        string s = Console.ReadLine();
        string[] values = s.Split(' ');
        int x = int.Parse(values[0]);
        int y = int.Parse(values[1]);
        x -= 1; y-=1;
        if (gName.validMove(x, y))
        {
            bName.changeBoard(x, y, this);
            return true;
        }
        else { Console.WriteLine("Invalid move, try again."); return false; }
    }

}

class Game : Board
{

    Board newBoard = new Board();
    public void startGame() // contains entire gameplay loop
    {
        Player x = new Player('x');
        Player y = new Player('y');
        int turns = 0;
        while (true)
        {
            newBoard.displayBoard();
            while (x.chooseMove(this, newBoard) == false) { }
            turns++;
            if (checkWin('x') == true)
            {
                Console.WriteLine("Player x has won! Congrats!");
                newBoard.displayBoard();
                return;
            }
            if (turns >= 9) { Console.WriteLine("Game has drawn!");  return; } // check for draw
            while (y.chooseMove(this, newBoard) == false ) { }
            turns++;
            
            if (checkWin('y') == true )
            {
                Console.WriteLine("Player y has won! Congrats!");
                newBoard.displayBoard();
                return;
            }
          
        }
        
        return;
    }


    public bool validMove(int x , int y) // checks if it is a valid move within the board bounds and is an empty spot
    {
        if (x > 2 || x < 0 || y > 2 || y < 0)
        {
            Console.WriteLine("Out of bounds.");
            return false;
        }
        if (newBoard.board[x,y] != ' ')
        {
            return false;
        }
        return true;
    }
  
    private bool checkWin(char val)
    {
        
        for(int i =0; i <3; i++) // horizontal check
        {
            if (newBoard.board[i, 0] == val && newBoard.board[i, 1] == val && newBoard.board[i,2] == val){ return true; }
        }
        for (int i = 0; i < 3; i++) // vertical check
        {
            if (newBoard.board[0, i] == val && newBoard.board[1, i] == val && newBoard.board[2, i] == val) { return true; }
        }

        //diagonal checks
        if (newBoard.board[0, 0] == val && newBoard.board[1, 1] == val && newBoard.board[2, 2] == val) { return true; }
        if (newBoard.board[0, 2] == val && newBoard.board[1, 1] == val && newBoard.board[2, 0] == val) { return true; }

        return false;
    }
}
