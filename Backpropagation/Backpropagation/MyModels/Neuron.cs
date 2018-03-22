using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backpropagation
{
    class sigmoid
    {
        public static double output(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        public static double derivative(double x)
        {
            return x * (1 - x);
        }
    }
    public class Neuron
    {
        public List<double> inputs;
        public List<Synapse> InputSynapses;
        public List<Synapse> OutputSynapses;
        public double Gradient { get; set; }

        private double biasWeight;

        public double WeightedSum
        {
            get
            {
                double wsum = 0;
                for (int i = 0; i < inputs.Count; i++)
                    wsum += InputSynapses[i].Weight * inputs[i];
                return wsum += biasWeight;
            }
            set { WeightedSum = value; }
        }
        public double Output
        {
            get { return sigmoid.output(WeightedSum); }
        }

        public Neuron(double[] trainingVec)
        {
            inputs = trainingVec.ToList();
            InputSynapses = new List<Synapse>();
            for (int i = 0; i < trainingVec.Count(); i++)
                InputSynapses.Add(new Synapse(Network.r.NextDouble(), null, this));
            biasWeight = Network.r.NextDouble();
        }

        public Neuron(double[] trainingVec, double[] weights, double bias)
        {
            inputs = trainingVec.ToList();
            InputSynapses = new List<Synapse>();
            for (int i = 0; i < trainingVec.Count(); i++)
                InputSynapses.Add(new Synapse(weights[i], null, this));
            biasWeight = bias;
        }

        public Neuron(List<Neuron> inputNeurons)
        {
            inputs = new List<double>();
            InputSynapses = new List<Synapse>();
            foreach (var n in inputNeurons)
            {
                inputs.Add(n.Output);
                var synapse = new Synapse(Network.r.NextDouble(), n, this);
                n.OutputSynapses = new List<Synapse>();
                n.OutputSynapses.Add(synapse);
                InputSynapses.Add(synapse);
            }
            biasWeight = Network.r.NextDouble();
        }

        public double CalculateGradient(double? desiredOutput = null)
        {
            if (desiredOutput != null)
                return Gradient = (desiredOutput.Value - Output) * sigmoid.derivative(Output);
            return Gradient = sigmoid.derivative(Output)*OutputSynapses.Sum( z => z.OutputNeuron.Gradient *  z.Weight);
        }

        public void AdjustWeights()
        {
            for (int i = 0; i < InputSynapses.Count; i++)
                InputSynapses[i].Weight += Gradient * inputs[i];
            biasWeight += Gradient;
        }
    }
}