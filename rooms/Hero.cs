using System;



public class Hero
{

    static int gameHeight = Console.WindowHeight = 20;
    static int gameWidth = Console.WindowWidth = 45;

    //the starting possition must be entered with switch case (experiment)
    //static int PositionX = int.Parse(Console.ReadLine());
    //static int PositionY = int.Parse(Console.ReadLine());
    static int lives = 2;
    static char shots = '*';
    //static int[,] startingPosition = new int[StartingPositionX, StartingPositionY];
    static int[,] coordinates = new int
           [Rooms.playFieldWidth - 1, Rooms.playFieldHeight - 1];


    public static int PositionX { get; set; }
    public static int PositionY { get; set; }
    public static char symbol = '@';
    public static int reminder = 0;
    //initialize player
    public static void DrawPlayer(int PositionY, int PositionX,char symbol)
    {
        if (reminder == 0)
        {
            symbol = '<';
        }
        if (reminder == 1)
        {
            symbol = '>';
        }
        if (reminder == 2)
        {
            symbol = '^';
        }
        if (reminder == 3)
        {
            symbol = 'v';
        }
        DrawSymbolAtCoordinates(symbol, PositionY, PositionX,reminder);
    }
    //draw player at position
    public static void DrawSymbolAtCoordinates(char symbol, int PositionY,
                                               int PositionX,int reminder)
    {
        Console.SetCursorPosition(PositionY, PositionX);
        Console.WriteLine(symbol);
    }

    public static void PlayerMovement()
    {
        //the input from keybord
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
            //Left arrow input
            if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (Rooms.room[PositionY, PositionX - 1] != 2 && Rooms.room[PositionY, PositionX - 1] != 1)
                //(coordinates[PositionX - 1, PositionY] != 2))
                //check to see if the possition is empty
                {
                    PositionX--;
                    reminder = 0;
                }
            }
            //Right arrow input
            if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                if ((Rooms.room[PositionY, PositionX + 1] != 1) &&
                  (Rooms.room[PositionY, PositionX + 1] != 2))
                //check to see if the possition is empty
                {
                    PositionX++;
                    reminder = 1;
                }
            }
            //upper  arrow input
            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                if ((Rooms.room[PositionY - 1, PositionX] != 1) &&
                  (Rooms.room[PositionY - 1, PositionX] != 2))
                //check to see if the possition is empty
                {
                    PositionY--;
                    reminder = 2;
                }
            }
            //Down arrow input
            if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                if ((Rooms.room[PositionY + 1, PositionX] != 1) &&
                  (Rooms.room[PositionY + 1, PositionX] != 2))
                //check to see if the possition is empty
                {
                    PositionY++;
                    reminder = 3;
                }
            }
        }
    }
    public static void Shooting(char symbol)
    {

    }
}