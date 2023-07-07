
int round = 1;

int cityHP = 15;
int canRNG = 0;
int canDMG = 0;

int manticoreHP = 10;
int manticoreDMG = 1;
int manticoreRNG = 0;

int cannonDMG (int round)
{
    int canDMG = 1;
    if (round % 3 == 0 && round % 5 == 0)
    {
        canDMG = 10;
    }
    else if (round % 3 == 0 || round % 5 == 0)
    {
        canDMG = 3;
    }
    
    return canDMG;
}

bool dmgTaken (int mRNG , int cRNG)
{
    
    if (canRNG == manticoreRNG)
    {
        Console.WriteLine($"That round was a DIRECT HIT!");
        return true;
    }
    else if (canRNG > manticoreRNG) { Console.WriteLine("That round OVERSHOT the target."); }
    else
    {
        Console.WriteLine("That round FELL SHORT of the target.");
    }
    return false;
}


Console.Write("Player 1, how far away from the city do you want to station the Manticore? ");
manticoreRNG = Convert.ToInt32(Console.ReadLine());

Console.Clear();

Console.WriteLine("Player 2, it is your turn.");

while(manticoreHP > 0 && cityHP > 0)
{

    canDMG = cannonDMG(round);
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine($"STATUS: Round {round} City: {cityHP}/15 Manticore: {manticoreHP}/10");
    Console.WriteLine($"The cannon is expected to deal {canDMG} damage this round.");
    Console.Write("Enter desired cannon range: ");
    canRNG = Convert.ToInt32(Console.ReadLine());

    if(dmgTaken(manticoreRNG, canRNG))
        { manticoreHP -= canDMG; }
    cityHP--;
    round++;
}

Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");