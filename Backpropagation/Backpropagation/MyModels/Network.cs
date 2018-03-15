using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkFreshStart
{
    public class Network : INetwork
    {
        public int InputSize { get; }
        

        public void Configure(int inputSize)
        {
            throw new NotImplementedException();
        }

        public int Predict(int[] inputVec)
        {
            throw new NotImplementedException();
        }

        public void Train(int[] trainingVec, int expectedOutput)
        {
            throw new NotImplementedException();
        }
    }
}
