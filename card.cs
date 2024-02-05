using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokerPlayer
{
    internal class card
    {
        int rank;// 2,3,4,5,6,7,8,9,10,J,Q,K or A
        string suit;//H for Hearts, D for Diamonds, C for Clubs and S for Spades

        public string enterSuit()
        {
            while (true)
            {
                try
                {
                    string[] validSuits = new string[] { "H", "D", "C", "S" };

                    string input;

                    Console.WriteLine("Please enter a suit");

                    input = Console.ReadLine().ToUpper();

                    for (int a = 0; a < 13; a++)
                    {
                        if (input == validSuits[a])
                        {
                            return input; ;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public int enterRank()
        {
            while (true)
            {
                try
                {
                    string[] validRanks = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

                    string input;

                    Console.WriteLine("Please enter a rank");

                    input = Console.ReadLine().ToUpper();

                    for (int a = 0; a < 13; a++)
                    {
                        if (input == validRanks[a])
                        {
                            int y = 0;

                            switch (input)
                            {
                                case "2":
                                    y = 2;
                                    break;
                                case "3":
                                    y = 3;
                                    break;
                                case "4":
                                    y = 4;
                                    break;
                                case "5":
                                    y = 5;
                                    break;
                                case "6":
                                    y = 6;
                                    break;
                                case "7":
                                    y = 7;
                                    break;
                                case "8":
                                    y = 8;
                                    break;
                                case "9":
                                    y = 9;
                                    break;
                                case "10":
                                    y = 10;
                                    break;
                                case "J":
                                    y = 11;
                                    break;
                                case "Q":
                                    y = 12;
                                    break;
                                case "K":
                                    y = 13;
                                    break;
                                case "A":
                                    y = 14;
                                    break;
                            }

                            return y;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void setRank(int x)
        {
            rank = x;
        }
        public void setSuit(string x)
        {
            suit = x;
        }

        public int getRank()
        {
            return rank;
        }

        public string getSuit()
        {
            return suit;
        }

    }
}
