using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominion
{
    class Store
    {
        

        //10 cards per action except gardens
        private static int Cellar;
        private static int Chapel;
        private static int Moat;
        private static int Chancellor;
        private static int Village;
        private static int Woodcutter;
        private static int Wordshop;
        private static int Bureaucrat;
        private static int Feast;
        private static int Gardens; //12
        private static int Militia;
        private static int Moneylender;
        private static int Remodel;
        private static int Smithy;
        private static int Spy;
        private static int Thief;
        private static int ThroneRoom;
        private static int CouncilRoom;
        private static int Festival;
        private static int Laboratory;
        private static int Library;
        private static int Market;
        private static int Mine;
        private static int Witch;
        private static int Adventurer;

        private static int Curse; //30 Curses
        private static int Estate; //24
        private static int Duchy; //12
        private static int Province; //12

        private static int Copper; //60
        private static int Silver; //40
        private static int Gold; //30

        public static void removeCard(String cardName)
        {
            
        }

        public void setGameMode (string Name)
        {
            if (Name == "Standard")
            {
                Cellar = 10;
                Moat = 10;
                Village = 10;
                Woodcutter = 10;
                Wordshop = 10;
                Militia = 10;
                Remodel = 10;
                Smithy = 10;
                Market = 10;
                Mine = 10;
            }

            resetTreasureAndVP();

        }

        private void resetTreasureAndVP()
        {
            Estate = 24;
            Duchy = 12;
            Province = 12;

            Copper = 60;
            Silver = 40;
            Gold = 30;
        }
    }
}
