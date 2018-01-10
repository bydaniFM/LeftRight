using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftRight
{
    class Program
    {
        static void Main(string[] args)
        {
            string opc = "";
            string totalElecs = "", predictGuess = "", registerGuess = "";
            int windowSize = 2;
            int total = 0, rightGuess = 0;
            Predictor predictor = new Predictor("id");
            while (true)
            {
                Console.Clear();

                predictor.PrintData();
                Console.WriteLine();

                Console.WriteLine("Izquierda o derecha (i/d)?");
                opc = Console.ReadLine();

                if (opc != "i") opc = "d";
                total++;

                string prediction = predictor.GetMostLikely(predictGuess);

                Console.WriteLine("IA guess: " + prediction);

                if(prediction == opc)
                {
                    rightGuess++;
                    Console.WriteLine("AI guessed right");
                }
                else
                {
                    Console.WriteLine("AI failed guessing");
                }
                Console.WriteLine("Correct guess rate: " + (100 * (float)rightGuess / total));

                if(totalElecs.Length - windowSize < 0)
                {
                    predictGuess += opc;
                }
                else
                {
                    predictGuess = totalElecs.Substring(totalElecs.Length - windowSize);
                }

                if (totalElecs.Length - windowSize - 1 < 0)
                {
                    registerGuess += opc;
                }
                else
                {
                    registerGuess = totalElecs.Substring(totalElecs.Length - (windowSize + 1));
                    predictor.RegisterSecuence(registerGuess);
                }

                Console.WriteLine("Total guesses: " + totalElecs);
                Console.WriteLine("Prediction guesses: " + predictGuess);
                Console.WriteLine("Register guesses: " + predictGuess);
                Console.ReadLine();
            }
        }
    }
}
