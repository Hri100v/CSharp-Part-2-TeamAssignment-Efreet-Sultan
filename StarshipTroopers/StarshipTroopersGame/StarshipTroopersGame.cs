using System;
using System.IO;
using System.Threading;
using System.Text;
using ConsoleExtender;

class StarshipTroopersGame
{   
    public const int Width = 230;
    public const int Height = 100;


    static void Main()
    {
        ConsoleHelper.SetConsoleFont(2); //sets the appropriate font size for printing info screen

      
        Console.BufferWidth = Console.WindowWidth = Width;
        Console.BufferHeight = Console.WindowHeight = Height;
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Title = "Starship Troopers - Team Efreet Sultan '15";
        Console.CursorVisible = false;

        var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        var assetsPath = Path.Combine(desktopFolder, @"StarshipTroopers\Assets\");
        var playerShipPath = "SpaceShip.txt";
        var fullFileName = Path.Combine(assetsPath, playerShipPath);
        string[] playerSymbols = System.IO.File.ReadAllLines(fullFileName);
        bool playing = true;
        //string[] playerSymbols = { " >ooo", ">>>>>>", " >ooo" };
        PlayerShip player = new PlayerShip(0, Height / 2, playerSymbols, ConsoleColor.Yellow);
        player.Lives = 5;

        SplashScreen();

        
        while (playing)
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    if (player.Y - 2 >= 0)
                    {
                        player.Y--;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    if (player.Y + 1 < Height-25) //the Height-25 prevents excessive flickering when the ship reaches the bottom border
                    {                               
                        player.Y++;
                    }
                } 
                else if (pressedKey.Key == ConsoleKey.Q) //terminates the game
                {
                    playing = false;
                }
            }

            Thread.Sleep(30);    
            Console.Clear();
            player.Draw();
        }

        GameOverScreen();
    }


    static void CollissionDetection(PlayerShip player) //INCOMPLETE
    {
        if (true)//set valid conditions
        {
            player.Lives--;

            //TODO: (OPTIONAL) SOUND
        }
    }

    static void SplashScreen()
    {
        Console.SetCursorPosition(0, 2);
        for (int i = 0; i < Width; i++)
        {
            Console.Write("=");
        }
        Console.SetCursorPosition(0, Height - 1);

        for (int i = 0; i < Width; i++)
        {
            Console.Write("=");
        }
        string[] info =
        {@"Starship Troopers guide",  

                                                "Control the spaceship with the arrow keys - Up and Down",
                                                " To shoot press the Space bar. You have 5 lives, so be", 
                                                "careful not to lose them all. If you do, the game ends!",
                                                "          Press Q to exit the game at any time.",
                                                "",
                                                "             Press Enter to start the game!"};

        Console.SetCursorPosition(Width/2 - 17, Height/2-3);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        for (int i = 0; i < info.Length; i++) //prints info
        {
            Console.Write(info[i]);
            Console.SetCursorPosition(Width / 2 - 35, Height / 2 + i);
        }
        Console.CursorVisible = false;
        Console.ReadLine();
        ConsoleHelper.SetConsoleFont(2); //sets the appropriate console font for playing the game
        Console.Clear();
    }
        
    
    static void GameOverScreen()
    {
        throw new NotImplementedException();
    }
}