using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


class PrintRooms
{


    static void Main()
    {
        //Console.BufferHeight = gameHeight;
        //Console.BufferWidth = gameWidth + 1;
        Console.CursorVisible = false;


        Rooms.FillRoomsWithSymbols(Rooms.room, Rooms.currentLevel);
        Hero.DrawPlayer(1, 1 , Hero.symbol);
        Hero.PositionX = 1;
        Hero.PositionY = 2;

        while (true)
        {

            Console.Clear();
            // RoomWalls();
            Rooms.PrintRoom(Rooms.room);
            Hero.PlayerMovement();

            Hero.DrawPlayer(Hero.PositionX, Hero.PositionY , Hero.symbol);
            if (Rooms.newLevel)   // changes to new level, using 'goto' is not the best way, accepting other solutions!
            {
                Rooms.currentLevel++;
                Rooms.FillRoomsWithSymbols(Rooms.room, Rooms.currentLevel);

            }


            Thread.Sleep(250);
        }

    }
}