using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokerPlayer
{
    internal class main
    {
        static void Main(string[] args)
        {
            /*
             * Setting the mode value to 1 allows the user to manually input cards
             * Setting the mode value to 2 will allow the AI to auto-generate cards to add to the table
             */
            int mode = 1;

            switch(mode)
            {
                case 1:
                    while (true)
                    {
                        card[] table = new card[5];

                        gameMethods game = new gameMethods();

                        neuralNetwork nn = new neuralNetwork();

                        nn.hardcodeWeightsAndBiases(nn);
                        //nn.randomizeWeightsAndBiases(nn);

                        double[] information_to_put_into_NN = new double[8];

                        double[] final_info = new double[3];

                        int correctlyEntered = 0;

                        while (correctlyEntered < 2)
                        {
                            card x = game.createCard();
                            //card x = game.createRandomCard();

                            if (game.findCard(x.getRank(), x.getSuit(), table, false) == false)
                            {
                                table[correctlyEntered++] = x;
                            }
                        }

                        information_to_put_into_NN[0] = game.doIHaveRoyalFlush(table);
                        information_to_put_into_NN[1] = game.doIHaveStraightFlush(table);
                        information_to_put_into_NN[2] = game.doIHaveFourOfAKind(table);
                        information_to_put_into_NN[3] = game.doIHaveFullHouse(table);
                        information_to_put_into_NN[4] = game.doIHaveFlush(table);
                        information_to_put_into_NN[5] = game.doIHaveStraight(table);
                        information_to_put_into_NN[6] = game.doIHaveThreeOfAKind(table);
                        information_to_put_into_NN[7] = game.doIHaveAPair(table);

                        final_info = nn.feedForward(information_to_put_into_NN, nn);

                        if (final_info[0] > 0)
                        {
                            Console.WriteLine("Bet (20% - 30% as to not scare off the other players)");
                        }
                        else if (final_info[1] > 0)
                        {
                            Console.WriteLine("Limp in this pot (bet the bare minimum/check)");
                        }
                        else if (final_info[2] > 0 || final_info[0] == 0 && final_info[1] == 0 && final_info[2] == 0)
                        {
                            Console.WriteLine("Fold.");
                        }
                        else
                        {
                            Console.WriteLine("There has been an error");
                        }

                        while (correctlyEntered < 5)
                        {
                            card x = game.createCard();
                            //card x = game.createRandomCard();

                            if (game.findCard(x.getRank(), x.getSuit(), table, false) == false)
                            {
                                table[correctlyEntered++] = x;

                                information_to_put_into_NN[0] = game.doIHaveRoyalFlush(table);
                                information_to_put_into_NN[1] = game.doIHaveStraightFlush(table);
                                information_to_put_into_NN[2] = game.doIHaveFourOfAKind(table);
                                information_to_put_into_NN[3] = game.doIHaveFullHouse(table);
                                information_to_put_into_NN[4] = game.doIHaveFlush(table);
                                information_to_put_into_NN[5] = game.doIHaveStraight(table);
                                information_to_put_into_NN[6] = game.doIHaveThreeOfAKind(table);
                                information_to_put_into_NN[7] = game.doIHaveAPair(table);

                                final_info = nn.feedForward(information_to_put_into_NN, nn);

                                if (final_info[0] > 0)
                                {
                                    Console.WriteLine("Bet (20% - 30% as to not scare off the other players)");
                                }
                                else if (final_info[1] > 0)
                                {
                                    Console.WriteLine("Limp in this pot (bet the bare minimum/check)");
                                }
                                else if (final_info[2] > 0)
                                {
                                    Console.WriteLine("Fold.");
                                }
                                else
                                {
                                    Console.WriteLine("There has been an error");
                                }
                            }
                        }
                        Console.WriteLine("Want to enter another hand? y to continue n to exit");

                        string toExit = Console.ReadLine();

                        if (toExit == "n")
                        {
                            break;
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                    break;
                case 2:
                    while (true)
                    {
                        card[] table = new card[5];

                        gameMethods game = new gameMethods();

                        neuralNetwork nn = new neuralNetwork();

                        nn.hardcodeWeightsAndBiases(nn);
                        //nn.randomizeWeightsAndBiases(nn);

                        double[] information_to_put_into_NN = new double[8];

                        double[] final_info = new double[3];

                        int correctlyEntered = 0;

                        while (correctlyEntered < 2)
                        {
                            //card x = game.createCard();
                            card x = game.createRandomCard();

                            if (game.findCard(x.getRank(), x.getSuit(), table, false) == false)
                            {
                                table[correctlyEntered++] = x;
                            }
                        }

                        information_to_put_into_NN[0] = game.doIHaveRoyalFlush(table);
                        information_to_put_into_NN[1] = game.doIHaveStraightFlush(table);
                        information_to_put_into_NN[2] = game.doIHaveFourOfAKind(table);
                        information_to_put_into_NN[3] = game.doIHaveFullHouse(table);
                        information_to_put_into_NN[4] = game.doIHaveFlush(table);
                        information_to_put_into_NN[5] = game.doIHaveStraight(table);
                        information_to_put_into_NN[6] = game.doIHaveThreeOfAKind(table);
                        information_to_put_into_NN[7] = game.doIHaveAPair(table);

                        final_info = nn.feedForward(information_to_put_into_NN, nn);

                        if (final_info[0] > 0)
                        {
                            Console.WriteLine("Bet (20% - 30% as to not scare off the other players)");
                        }
                        else if (final_info[1] > 0)
                        {
                            Console.WriteLine("Limp in this pot (bet the bare minimum/check)");
                        }
                        else if (final_info[2] > 0 || final_info[0] == 0 && final_info[1] == 0 && final_info[2] == 0)
                        {
                            Console.WriteLine("Fold.");
                        }
                        else
                        {
                            Console.WriteLine("There has been an error");
                        }

                        while (correctlyEntered < 5)
                        {
                            //card x = game.createCard();
                            card x = game.createRandomCard();

                            if (game.findCard(x.getRank(), x.getSuit(), table, false) == false)
                            {
                                table[correctlyEntered++] = x;

                                information_to_put_into_NN[0] = game.doIHaveRoyalFlush(table);
                                information_to_put_into_NN[1] = game.doIHaveStraightFlush(table);
                                information_to_put_into_NN[2] = game.doIHaveFourOfAKind(table);
                                information_to_put_into_NN[3] = game.doIHaveFullHouse(table);
                                information_to_put_into_NN[4] = game.doIHaveFlush(table);
                                information_to_put_into_NN[5] = game.doIHaveStraight(table);
                                information_to_put_into_NN[6] = game.doIHaveThreeOfAKind(table);
                                information_to_put_into_NN[7] = game.doIHaveAPair(table);

                                final_info = nn.feedForward(information_to_put_into_NN, nn);

                                if (final_info[0] > 0)
                                {
                                    Console.WriteLine("Bet (20% - 30% as to not scare off the other players)");
                                }
                                else if (final_info[1] > 0)
                                {
                                    Console.WriteLine("Limp in this pot (bet the bare minimum/check)");
                                }
                                else if (final_info[2] > 0)
                                {
                                    Console.WriteLine("Fold.");
                                }
                                else
                                {
                                    Console.WriteLine("There has been an error");
                                }
                            }
                        }

                        for (int i = 0; i < 5; i++)
                        {
                            Console.WriteLine("CARD NO. " + (i + 1));
                            Console.WriteLine(table[i].getRank());
                            Console.WriteLine(table[i].getSuit());
                            Console.WriteLine("-------------------");
                        }

                        Console.WriteLine("Want to enter another hand? y to continue n to exit");

                        string toExit = Console.ReadLine();

                        if (toExit == "n")
                        {
                            break;
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                    break;
            }
        }
    }
}
