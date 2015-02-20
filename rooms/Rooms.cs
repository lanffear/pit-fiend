using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Rooms
{
    static int gameHeight = Console.WindowHeight = 20;
    static int gameWidth = Console.WindowWidth = 45;
    public static int playFieldHeight = gameHeight - 5;
    public static int playFieldWidth = gameWidth - 10;

    public static int currentLevel = 1;        // Changing this, changes the room (1-2 currently)

    public static bool newLevel = false;

    public static void Print(int col, int row, object data) // Method used for printing.
    {
        Console.SetCursorPosition(row, col);
        Console.Write(data);
    }

    public static int[,] room = new int[playFieldHeight, playFieldWidth];

    public static void FillRoom(int type, int length, int row, int col, int[,] room) //Method used to fill matrix. Type '1' == '|', Type '2' == '-'
    {
        if (type == 1)
        {
            for (int i = 0; i < length; i++)
            {
                room[row + i, col] = 1;
            }
        }
        else if (type == 2)
        {
            for (int i = 0; i < length; i++)
            {
                room[row, col + i] = 2;
            }
        }
    }

    public static void FillRoomsWithSymbols(int[,] room, int Level)
    {
        //Cleans the playfield
        for (int i = 1; i < playFieldHeight; i++)
        {
            for (int j = 1; j < playFieldWidth - 1; j++)
            {
                room[i, j] = 3;
            }
        }

        //Room walls
        FillRoom(1, playFieldHeight, 0, 0, room);       //left
        FillRoom(2, playFieldWidth - 1, 0, 0, room);    //top
        FillRoom(1, playFieldHeight, 0, 34, room);      //right
        FillRoom(2, playFieldWidth - 1, 14, 0, room);    //bottom

        if (Level == 1)
        {
            // Top-Left corner
            FillRoom(1, 6, 1, 4, room);
            FillRoom(1, 6, 2, 10, room);


            // Top-Mid
            FillRoom(2, 6, 2, 11, room);    //line left '-'          
            FillRoom(1, 6, 4, 13, room);
            FillRoom(2, 10, 4, 16, room);   //long line '-'

            FillRoom(1, 4, 5, 17, room);
            FillRoom(1, 3, 1, 21, room);    // separating line '|'
            FillRoom(1, 3, 5, 25, room);


            // Top-Right
            FillRoom(1, 6, 3, 28, room);    //Line '|'

            FillRoom(2, 3, 3, 31, room);
            FillRoom(2, 3, 5, 29, room);    //Zig-zag
            FillRoom(2, 3, 7, 31, room);

            //Bottom-Left
            FillRoom(2, 10, 8, 1, room);    //upper line '-'    
            FillRoom(2, 10, 12, 2, room);   //bottom line '-'

            FillRoom(1, 2, 9, 3, room);
            FillRoom(1, 2, 10, 6, room);    //Zig-zag '|'
            FillRoom(1, 2, 9, 9, room);

            //Bottom-Mid
            FillRoom(1, 6, 8, 22, room);    //right line '|'

            FillRoom(2, 10, 10, 12, room);  //top line '-'

            FillRoom(1, 2, 11, 12, room);
            FillRoom(1, 2, 12, 15, room);   //Middle-Bottom, Zig-zag
            FillRoom(1, 2, 11, 18, room);

            //Bottom-Right
            FillRoom(2, 9, 9, 23, room);    //top line '-'

            FillRoom(1, 3, 11, 28, room);   //Zig-Zag '|'
            FillRoom(1, 3, 10, 31, room);

        }
        else if (Level == 2)
        {
            //Top-Left
            FillRoom(2, 13, 3, 4, room);    //  '-'
            FillRoom(2, 10, 5, 4, room);    //  '-'

            //Top-Mid
            FillRoom(1, 3, 5, 14, room);
            FillRoom(1, 6, 1, 17, room);    //Turn '|'
            FillRoom(1, 5, 3, 20, room);

            FillRoom(2, 3, 5, 22, room);    //Right Zig-zag '-'
            FillRoom(2, 3, 3, 21, room);    //Right Zig-zag '-'

            //Top-Right
            FillRoom(1, 5, 1, 25, room);
            FillRoom(1, 4, 1, 28, room);    //Turn '|'
            FillRoom(1, 4, 2, 31, room);

            FillRoom(2, 7, 6, 25, room);    //Bottom line '-'

            //Bottom-Left
            FillRoom(1, 6, 6, 4, room);     //Turn '|'

            FillRoom(1, 7, 7, 8, room);     //Zig-Zag wall, '|'

            FillRoom(2, 3, 7, 11, room);
            FillRoom(2, 3, 9, 9, room);
            FillRoom(2, 3, 11, 11, room);

            //Bottom-Mid
            FillRoom(2, 20, 8, 14, room);   //Bottom long top line '-'

            FillRoom(1, 4, 9, 14, room);    //Left wall '|'

            //First hiding place
            FillRoom(1, 1, 13, 16, room);
            FillRoom(2, 1, 12, 16, room);
            FillRoom(1, 1, 11, 17, room);
            FillRoom(2, 1, 10, 16, room);

            FillRoom(1, 4, 9, 19, room);    //Middle wall(left)  '|'
            FillRoom(1, 4, 10, 21, room);   //Middle wall(right) '|'

            //Second hiding place
            FillRoom(1, 1, 9, 23, room);
            FillRoom(2, 1, 12, 23, room);
            FillRoom(1, 1, 11, 24, room);
            FillRoom(2, 1, 10, 23, room);

            //Bottom-Right            
            FillRoom(1, 4, 10, 26, room);   //Left wall '|'
            FillRoom(2, 6, 10, 27, room);   //Upper wall '-'


        }

    } // Fills the matrix with numbers => they represent later walls.

    public static void PrintRoom(int[,] room)
    {
        for (int i = 0; i < playFieldHeight; i++)
        {
            for (int j = 0; j < playFieldWidth; j++)
            {
                switch (room[i, j])
                {
                    case 1:
                        Print(i, j, '|');
                        break;

                    case 2:
                        Print(i, j, '-');
                        break;

                    default:
                        break;
                }
            }
        }
    } // Using the numbers in the matrix, prints the gamefield

}