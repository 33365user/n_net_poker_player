using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokerPlayer
{
    internal class neuralNetwork
    {

        /*
         * The attributes needed for each neural network
         */
        double[] no_ins = new double[8]; //Hardcoded lengths due to time
        double[] no_outs = new double[3];
        double[] biases = new double[3];
        double[,] weights = new double[8, 3];


        /*
         * Returns a random double
         * Who would of known that in the year of our lord 2022 it would be this hard to generate a random number with a decimal point
         */
        private double randomDouble(double lowerBound, double upperBound)
        {
            var random = new Random();
            var rDouble = random.NextDouble();
            var rRangeDouble = rDouble * (upperBound - lowerBound) + lowerBound;
            return rRangeDouble;
        }

        /*

        public neuralNetwork(int ins, int outs)
        {
            int[] no_ins = new int[ins];
            int[] no_outs = new int[outs];
            int[] biases = new int[outs];
            int[,] weights = new int[ins, outs];
        }

        */

        /*
         * Randomizes the weights and biases of a given neural network
         * Returns a object of type neural network
         */
        public neuralNetwork randomizeWeightsAndBiases(neuralNetwork x)
        {
            for (int i = 0; i < x.no_ins.Length; i++)
            {
                for (int j = 0; j < x.no_outs.Length; j++)
                {
                    x.weights[i, j] = randomDouble(-1, 1);//rnd.Next(-1, 2);
                }
            }

            for (int i = 0; i < x.biases.Length; i++)
            {
                x.biases[i] = randomDouble(-1, 1);
            }

            return x;
        }

        /*
         * Hardcodes the weights and biases of a given neural network
         * Returns a object of type neural network
         */
        public neuralNetwork hardcodeWeightsAndBiases(neuralNetwork x)
        {
            for (int i = 0; i < x.no_ins.Length; i++)
            {
                for (int j = 0; j < x.no_outs.Length; j++)
                {
                    x.weights[i, j] = 1;//I don't want most of the weights to influence anything, so to begin with I will set all values to 1
                }
            }


            //below are the weights for the bet output and the inputs Royal flush, straightflush, and four of a kind, you want to play these hands, thus the extra little boost to their sum
            x.weights[0, 0] = 2;
            x.weights[0, 1] = 2;
            x.weights[0, 2] = 2;

            x.biases[0] = 0.9;//The bet bias
            x.biases[1] = 0.6;//The check bias
            x.biases[2] = -1;//The fold bias - needs to be -1 to ensure if no other output fires, this output will

            return x;
        }

        public double[] feedForward(double[] newIns, neuralNetwork x)
        {
            for(int i = 0; i < x.no_ins.Length; i++)
            {
                x.no_ins[i] = newIns[i];
            }

            for (int i = 0; i < x.no_outs.Length; i++)
            {
                double sum = 0;

                for (int j = 0; j < x.no_ins.Length; j++)
                {
                    sum = (sum + x.no_ins[j] * x.weights[j,i]);
                }

                if(sum > x.biases[i])
                {
                    x.no_outs[i] = 1;
                }
                else
                {
                    x.no_outs[i] = 0;
                }
            }

            return x.no_outs;
        }
    }
}
