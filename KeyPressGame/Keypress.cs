
Console.WriteLine("Please enter a username.");
string userName = Console.ReadLine();
Player player = new Player(userName);
if(File.Exists(player._fileName))
{
    Console.WriteLine($"Welcome back {player._userName}.");
}
else
{
    Console.WriteLine($"Welcome to the game, {player._userName}.");
}

while (true)
{
    ConsoleKey key = Console.ReadKey().Key;
    if (key == ConsoleKey.Escape)
        break;

    player.increaseScore();
    Console.WriteLine($"\nNew Score is {player._score}");
}

File.WriteAllText($"{player._fileName}" ,(player._score.ToString()));


class Player
{
    public string _userName;
    public string _fileName;
    public int _score { get; private set; }
    public Player(string username)
    {
        _userName = username;
        _fileName = _userName + ".txt";
    }

    public void increaseScore()
    {
        _score++;
    }


}