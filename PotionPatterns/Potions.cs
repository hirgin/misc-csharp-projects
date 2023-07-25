Potions potion = Potions.water;
while(true)
{
    Console.WriteLine($"You have a vial of {potion} currently. ");
    Console.WriteLine("Add one of these available ingredients: stardust, snake venom, dragon breath, shadow glass, eyeshine gem.");

    Ingredients ingredient = Console.ReadLine() switch
    {
        "stardust" => Ingredients.stardust,
        "snake venom" => Ingredients.snakeVenom,
        "dragon breath" => Ingredients.dragonBreath,
        "shadow glass" => Ingredients.shadowGlass,
        "eyeshine gem" => Ingredients.eyeshineGem,
        _ => Ingredients.water
    } ;
    

    potion = makePotion(ingredient,potion);



}



Potions makePotion(Ingredients i, Potions p)
{
    return (i, p) switch
    {
        (Ingredients.stardust, Potions.water) => Potions.elixir,
        (Ingredients.snakeVenom, Potions.elixir) => Potions.poison,
        (Ingredients.dragonBreath, Potions.elixir) => Potions.flying,
        (Ingredients.shadowGlass, Potions.elixir) => Potions.invisibility,
        (Ingredients.eyeshineGem, Potions.elixir) => Potions.nightSight,
        (Ingredients.shadowGlass, Potions.nightSight) => Potions.cloudyBrew,
        (Ingredients.eyeshineGem, Potions.invisibility) => Potions.cloudyBrew,
        (Ingredients.stardust, Potions.cloudyBrew) => Potions.wraith,
        (Ingredients.water, Potions.water) => Potions.water,
        (_,_) => Potions.ruined

    } ;

}

enum Ingredients {water,  stardust, snakeVenom, dragonBreath, shadowGlass, eyeshineGem }
enum Potions { water, elixir, poison, flying, invisibility, nightSight, cloudyBrew, wraith, ruined }

