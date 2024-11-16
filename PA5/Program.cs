using System;
using pa5;

public class Game
{
    private ICharacter _player1;
    private ICharacter _player2;
    private Random _random;

    public Game()
    {
        _random = new Random();
        _player1 = ChooseCharacter("Player 1");
        _player2 = ChooseCharacter("Player 2");

        Console.WriteLine($"\nPlayer 1 chose {_player1.Name} with {_player1.Health} health, " +
                          $"{_player1.AttackStrength} attack, and {_player1.DefenseStrength} defense.");
        Console.WriteLine($"Player 2 chose {_player2.Name} with {_player2.Health} health, " +
                          $"{_player2.AttackStrength} attack, and {_player2.DefenseStrength} defense.\n");
    }

    private ICharacter ChooseCharacter(string playerName)
    {
        Console.WriteLine($"{playerName}, choose your character:");
        Console.WriteLine("1. Jack Sparrow");
        Console.WriteLine("2. Davy Jones");
        Console.WriteLine("3. Will Turner");

        int choice;
        while (true)
        {
            Console.Write("Enter the number of your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 3)
                break;
            Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
        }

        return choice switch
        {
            1 => new JackSparrow(),
            2 => new DavyJones(),
            3 => new WillTurner(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public void Start()
{
    bool isPlayer1Turn = _random.Next(2) == 0;
    Console.WriteLine(isPlayer1Turn ? "Player 1 starts the game!" : "Player 2 starts the game!");

    while (_player1.Health > 0 && _player2.Health > 0)
    {
        if (isPlayer1Turn)
        {
            PlayTurn(_player1, _player2); 
        }
        else
        {
            PlayTurn(_player2, _player1); 
        }

        isPlayer1Turn = !isPlayer1Turn; 
    }

    Console.WriteLine(_player1.Health > 0 ? "Player 1 wins!" : "Player 2 wins!");
}


    private void PlayTurn(ICharacter player1, ICharacter player2)
{
    while (true)
    {
        Console.WriteLine($"\n{player1.Name}'s turn:");
        Console.WriteLine("Choose an action:");
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Defend");
        Console.WriteLine("3. View Stats");

        int choice;
        while (true)
        {
            Console.Write("Enter the number of your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 3)
                break;
            Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
        }

        if (choice == 1) 
        {
            Console.WriteLine($"{player1.Name} attacks {player2.Name}!");
            player1.Attack(player2);
            break;
        }
        else if (choice == 2)
        {
            Console.WriteLine($"{player1.Name} chooses to defend.");
            player1.Defend();
            break;
        }
        else if (choice == 3) 
        {
            Console.WriteLine($"\n{player1.Name} Stats:");
            Console.WriteLine($"Health: {player1.Health}");
            Console.WriteLine($"Max Power: {player1.MaxPower}");
            Console.WriteLine($"Attack Strength: {player1.AttackStrength}");
            Console.WriteLine($"Defense Strength: {player1.DefenseStrength}\n");
        }
    }
}

}

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.Start();
    }
}
