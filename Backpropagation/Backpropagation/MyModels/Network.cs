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
        public static Random r = new Random();
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
            double[] input = inputVec.Select(z => (double)z).ToArray();
            HiddenLayer.ForEach(n => n.inputs = input.ToList());
            for (int i = 0; i < HiddenLayer.Count; i++)
            {
                OutputNeuron.inputs[i] = HiddenLayer[i].Output;
            }
            //Console.WriteLine(Convert.ToInt32(Math.Round(OutputNeuron.Output, 4)));
            return Convert.ToInt32(Math.Round(OutputNeuron.Output, 4));
            //Math.Round(OutputNeuron.Output, 4);
        }

        public void Train(int[] trainingVec, int expectedOutput)
        {
            double[] input = trainingVec.Select(z => (double)z).ToArray();
            double output = expectedOutput;
            HiddenLayer.ForEach(n => n.inputs = input.ToList());
            for (int i = 0; i< HiddenLayer.Count; i++)
            {
                OutputNeuron.inputs[i] = HiddenLayer[i].Output;
            }
            OutputNeuron.CalculateGradient(output);
            OutputNeuron.AdjustWeights();
            HiddenLayer.ForEach(n => n.CalculateGradient());
            HiddenLayer.ForEach(n => n.AdjustWeights());
        }
    }
}
