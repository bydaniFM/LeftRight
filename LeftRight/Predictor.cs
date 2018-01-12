using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftRight
{
    class Predictor
    {
        private Dictionary<string, DataRecord> data;
        private string possibleActions;
        private Random rnd;

        public Predictor(string _possibleActions)
        {
            data = new Dictionary<string, DataRecord>();
            possibleActions = _possibleActions;
            rnd = new Random();
        }

        public string GetMostLikely(string actions)
        {
            DataRecord keyData;
            int highestValue = 0;
            char bestAction = ' ';
            if (data.ContainsKey(actions)) {

                keyData = data[actions];
                foreach (char action in keyData.counts.Keys)
                {
                    if (keyData.counts[action] > highestValue)
                    {
                        highestValue = keyData.counts[action];
                        bestAction = action;
                        //Console.WriteLine("CONTROL1");
                    }
                }
            }
            else
            {
                bestAction = possibleActions[rnd.Next(possibleActions.Length)];
                //Console.WriteLine("CONTROL2");
            }
            return bestAction.ToString();
        }

        public void RegisterSecuence(string actions)
        {
            string key = actions.Substring(0, actions.Length - 1);
            char value = actions[actions.Length - 1];

            if (!data.ContainsKey(key))
            {
                data[key] = new DataRecord();
            }

            DataRecord keyData = data[key];

            if (!keyData.counts.ContainsKey(value))
            {
                keyData.counts[value] = 0;
            }

            keyData.counts[value]++;
            keyData.total++;

        }

        public void PrintData()
        {
            Console.WriteLine("PREDICTOR DATA");
            foreach(string key in data.Keys)
            {
                Console.WriteLine(key);
                DataRecord keyData = data[key];
                foreach (char action in keyData.counts.Keys)
                {
                    Console.WriteLine("\t" + action + " -> " + keyData.counts[action]);
                }
            }
        }
    }
}
