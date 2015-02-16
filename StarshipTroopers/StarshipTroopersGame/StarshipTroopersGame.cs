using System;
using System.IO;
using System.Threading;
using System.Text;

class StarshipTroopersGame
{   
    public const int Width = 150;
    public const int Height = 38;
                                

    static void Main()    
    {
        Console.BufferWidth = Console.WindowWidth = Width;
        Console.BufferHeight = Console.WindowHeight = Height;
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Title = "Starship Troopers - Team Efreet Sultan '15";
        Console.CursorVisible = false;

        //var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        //var fullFileName = Path.Combine(desktopFolder, "SpaceShip.txt");
        //string[] playerSymbols = System.IO.File.ReadAllLines(fullFileName);
        bool playing = true;
        string[] playerSymbols = { " >ooo", ">>>>>>", " >ooo" };
        PlayerShip player = new PlayerShip(0, Height / 2, playerSymbols, ConsoleColor.Cyan);
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
                    if (player.Y + 1 < Height-4) //the Height-4 prevents excessive flickering when the ship reaches the bottom border
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
    }

    static void ColissionDetection(PlayerShip player) //INCOMPLETE
    {
        if (true)//set valid conditions
        {
            player.Lives--;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Thread.Sleep(100);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Thread.Sleep(100);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Thread.Sleep(100);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Thread.Sleep(100);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Thread.Sleep(100);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Thread.Sleep(100);
            Console.Clear();
            //TODO: (OPTIONAL) SOUND
        }
    }

    static void SplashScreen()
    {
        Console.SetCursorPosition(0, 2);
        for (int i = 0; i < Width ; i++)
        {
            Console.Write("-");
        }
        Console.SetCursorPosition(0, Height-1);
        
        for (int i = 0; i < Width; i++)
        {
            Console.Write("-");
        }
        string info =
@"Starship Troopers guide  

                                                Control the spaceship with the arrow keys - Up and Down
                                                To shoot press the Space bar. You have 5 lives, so be 
                                                careful not to lose them all. If you do, the game ends!
                                                        Press Q to exit the game at any time.

                                                           Press any key to start the game!";
        //Console.Clear();
        Console.SetCursorPosition(Width/2 - 10, Height/2-3);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(info);
        Console.CursorVisible = false;
        Console.ReadLine();
        //Console.Clear();
    }
}