using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokerPlayer
{
    internal class gameMethods
    {
        public void determineWinHardcode(card[] x)
        {
            int winValue = 0;

            if(doIHaveRoyalFlush(x) > 0)
            {
                winValue = (winValue + 8);
            }
            else if (doIHaveStraightFlush(x) > 0)
            {
                winValue = (winValue + 7);
            }
            else if (doIHaveFourOfAKind(x) > 0)
            {
                winValue = (winValue + 6);
            }
            else if (doIHaveFullHouse(x) > 0)
            {
                winValue = (winValue + 5);
            }
            else if (doIHaveFlush(x) > 0)
            {
                winValue = (winValue + 4);
            }
            else if (doIHaveStraight(x) > 0)
            {
                winValue = (winValue + 3);
            }
            else if(doIHaveThreeOfAKind(x) > 0)
            {
                winValue = (winValue + 2);
            }
            else if (doIHaveAPair(x) > 0)
            {
                winValue = (winValue + 1);
            }

            //---------------------------------------------

            if(winValue >= 8)
            {
                Console.WriteLine("You have an almost unbeatable hand - Go for broke!");
            }
            else if(winValue >= 6)
            {
                Console.WriteLine("You have a good shot at winning - Bet");
            }
            else if (winValue >= 2)
            {
                Console.WriteLine("You have an okay shot at winning - Bet but be cautious");
            }
            else if (winValue == 1)
            {
                Console.WriteLine("You only have a pair, you can be beaten by all other hands - Check (where you can) and don't put too much money in");
            }
            else
            {
                Console.WriteLine("You don't have anything, if you do play it's risky - I would suggest folding");
            }

        }

        public card[] orderCards(card[] x)
        {
            for (int a = 0; a < x.Length; a++)
            {
                for(int b = 0; b < x.Length; b++)
                {
                    if(x[a] != null)
                    {
                        if(x[b] != null)
                        {
                            if (x[a].getRank() < x[b].getRank())
                            {
                                card temp = new card();
                                temp.setRank(x[b].getRank());
                                temp.setSuit(x[b].getSuit());

                                x[b].setRank(x[a].getRank());
                                x[b].setSuit(x[a].getSuit());

                                x[a].setRank(temp.getRank());
                                x[a].setSuit(temp.getSuit());
                            }
                        }
                    }
                }
            }
            return x;
        }

        public bool findCard(int targetRank, string targetSuit, card[] x, bool ignoreSuit)
        {
            card temp = new card();
            temp.setRank(targetRank);
            temp.setSuit(targetSuit);

            if (ignoreSuit == false)
            {
                for (int a = 0; a < x.Length; a++)
                {
                    if(x[a] != null)
                    {
                        if (x[a].getRank() == temp.getRank() && x[a].getSuit() == temp.getSuit())
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                for (int a = 0; a < x.Length; a++)
                {
                    if (x[a] != null)
                    {
                        if (x[a].getRank() == temp.getRank())
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            
        }

        public card createRandomCard()
        {
            Random rnd = new Random();
            int newRank = 0;
            newRank = rnd.Next(2, 15);
            int newSuitInt = 0;
            newSuitInt = rnd.Next(1, 5);
            string newSuit = "";

            switch (newSuitInt)
            {
                case 1:
                    newSuit = "H";
                    break;
                case 2:
                    newSuit = "D";
                    break;
                case 3:
                    newSuit = "C";
                    break;
                case 4:
                    newSuit = "S";
                    break;
            }

            card temp = new card();

            temp.setRank(newRank);
            temp.setSuit(newSuit);

            return temp;
        }

        public card createCard()
        {
            card temp = new card();
            temp.setRank(temp.enterRank());
            temp.setSuit(temp.enterSuit());

            return temp;
        }

        public double doIHaveRoyalFlush(card[] x)
        {
            if (x.Length < 5)//if there aren't enough cards
            {
                return 0;
            }
            else
            {
                if (findCard(10, x[0].getSuit(), x, false))
                {
                    if (findCard(11, x[0].getSuit(), x, false))//J
                    {
                        if (findCard(12, x[0].getSuit(), x, false))//Q
                        {
                            if (findCard(13, x[0].getSuit(), x, false))//K
                            {
                                if (findCard(14, x[0].getSuit(), x, false))//A
                                {
                                    double toReturn = (14 * 0.1);
                                    return toReturn;
                                }
                            }
                        }
                    }
                }
                return 0 ;
            }
        }

        public double doIHaveStraightFlush(card[] x)
        {
            if (x.Length < 5)//if there aren't enough cards
            {
                return 0;
            }
            else
            {
                orderCards(x);

                int y = x[0].getRank();
                string z = x[0].getSuit();

                if(findCard((y + 1), z, x, false))
                {
                    if (findCard((y + 2), z, x, false))
                    {
                        if (findCard((y + 3), z, x, false))
                        {
                            if(findCard((y + 4), z, x, false))
                            {
                                double toReturn = x[4].getRank() * 0.1;
                                return toReturn;
                            }
                        }
                    }
                }

                return 0;
            }
        }

        public double doIHaveFourOfAKind(card[] x)
        {
            if (x.Length < 4)//if there aren't enough cards
            {
                return 0;
            }
            else
            {
                orderCards(x);

                int counter = 0;

                int indexHolder = 0;

                for(int i = 0; i < x.Length; i++)
                {
                    if (x[i] != null)
                    {
                        if (x[i].getRank() == x[1].getRank())
                        {
                            counter = (counter + 1);
                            indexHolder = i;
                        }
                    }
                }
                if (counter == 4)
                {
                    return (indexHolder * 0.1);
                }
                else
                {
                    return 0;
                }
            }
        }

        public double doIHaveFullHouse(card[] x)
        {
            double three = doIHaveThreeOfAKind(x);
            double pair = doIHaveAPair(x);

            if (three > 0 && pair > 0)
            {
                double toReturn = (three + pair);
                return toReturn;
            }
            else
            {
                return 0;
            }
        }

        public double doIHaveFlush(card[] x)
        {
            if (x.Length < 5)//if there aren't enough cards
            {
                return 0;
            }
            else
            {
                if (x[0] != null)
                {
                    if (x[1] != null)
                    {
                        if (x[2] != null)
                        {
                            if (x[3] != null)
                            {
                                if (x[4] != null)
                                {
                                    if (x[0].getSuit() == x[1].getSuit())
                                    {
                                        if (x[0].getSuit() == x[2].getSuit())
                                        {
                                            if (x[0].getSuit() == x[3].getSuit())
                                            {
                                                if (x[0].getSuit() == x[4].getSuit())
                                                {
                                                    double toReturn = x[4].getRank() * 0.1;
                                                    return toReturn;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }

        public double doIHaveStraight(card[] x)
        {
            if (x.Length < 5)//if there aren't enough cards
            {
                return 0;
            }
            else
            {
                orderCards(x);

                int y = x[0].getRank();
                string z = x[0].getSuit();

                if (findCard((y + 1), z, x, true))
                {
                    if (findCard((y + 2), z, x, true))
                    {
                        if (findCard((y + 3), z, x, true))
                        {
                            if (findCard((y + 4), z, x, true))
                            {
                                double toReturn = (x[4].getRank() * 0.1);
                                return toReturn;
                            }
                        }
                    }
                }

                return 0;
            }
        }

        public double doIHaveThreeOfAKind(card[] x)
        {
            if (x.Length < 3)//if there aren't enough cards
            {
                return 0;
            }
            else
            {
                orderCards(x);

                int counter = 0;

                int indexHolder = 0;

                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] != null)
                    {
                        if (x[i].getRank() == x[1].getRank())
                        {
                            counter = (counter + 1);
                            indexHolder = i;
                        }
                    }
                }
                if (counter == 3)
                {
                    return (x[indexHolder].getRank() * 0.1);
                }
                else
                {
                    return 0;
                }
            }
        }

        public double doIHaveAPair(card[] x)
        {
            if(x.Length < 2)
            {
                return 0;
            }
            else
            {
                for (int a = 0; a < x.Length; a++)
                {
                    for (int b = 1; b < x.Length; b++)
                    {
                        if(x[a] != null)
                        {
                            if (x[b] != null)
                            {
                                if (x[a].getRank() == x[b].getRank() && a != b)
                                {
                                    double toReturn = (x[a].getRank() * 0.1);

                                    return toReturn;
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }
    }
}
