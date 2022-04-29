// See https://aka.ms/new-console-template for more information
using Game;

Console.WriteLine("*¤*¤*¤ Welcome to the space battle between the rebels and the empire. ¤*¤*¤*\n");
Console.WriteLine("How many rebels do you want? Tap a number.\n");
int nb_Rebelle = Int32.Parse(Console.ReadLine());
Console.WriteLine("How many soldiers do you want for the empire? Tap a number.\n");
int nb_Empire = Int32.Parse(Console.ReadLine());

// creation of my empire and my rebelle
Board board = new Board(nb_Empire, nb_Rebelle);
//board.display();

// print the hero
Console.WriteLine("-- The hero for the Empire is " + board.hero_Empire.GetName());
Console.WriteLine("-- The hero for the rebels is " + board.hero_Rebelle.GetName());

// print the favori
Console.WriteLine("-- The favorite of this game is " + board.favori.GetName() + "\n");

// lauch the game
int round = 1;
while (!board.isFinish())
{
    Console.WriteLine("======= Round " + round + " =======");

    Random random = new Random();
    int team = random.Next(2); // choose the team who attack
    Soldat soldat_E = board.list_Empire[random.Next(0, board.list_Empire.Length)];
    Soldat soldat_R = board.list_Rebelle[random.Next(0, board.list_Rebelle.Length)];
    while (soldat_E.isDead())
        soldat_E = board.list_Empire[random.Next(0, board.list_Empire.Length)];
    while (soldat_R.isDead())
        soldat_R = board.list_Rebelle[random.Next(0, board.list_Rebelle.Length)];
    if (team == 0) // Empire attack
    {
        Console.WriteLine("Traitor !\n");
        soldat_E.attack(soldat_R);
    }
    else // Rebelle attack
    {
        Console.WriteLine("Pour la princesse Organa !\n");
        soldat_R.attack(soldat_E);
    }
    round++;
}

Console.WriteLine("*¤*¤*¤ The game is finish. *¤*¤*¤ \n");
if (!board.favori.isDead())
    Console.WriteLine("-- The favori is not dead.");
else
    Console.WriteLine("-- The favori is dead.");