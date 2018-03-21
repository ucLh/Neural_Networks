using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backpropagation
{
    public class Network : INetwork
    {
        public int InputSize { get; }
        public List<Neuron> HiddenLayer;
        public Neuron OutputNeuron;
        public Network(int[] inputVec)
        {
            //XOR case
            double[] dInput = inputVec.Select(z => (double)z).ToArray();
            HiddenLayer = new List<Neuron>();
            HiddenLayer.Add(new Neuron(dInput));
            HiddenLayer.Add(new Neuron(dInput));
            OutputNeuron = new Neuron(HiddenLayer);
        }

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
