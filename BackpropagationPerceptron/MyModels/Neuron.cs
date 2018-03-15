using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkFreshStart
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
    class Neuron
    {
        public List<double> inputs;
        public List<double> weights;
        public double Gradient { get; set; }

        private double biasWeight;

        private Random r = new Random();

        public double WeightedSum
        {
            get
            {
                double wsum = 0;
                for (int i = 0; i < inputs.Count; i++)
                   wsum += weights[i] * inputs[i];
                return wsum += biasWeight;
            }
            set { WeightedSum = value; }
        }
        public Neuron(double[] trainingVec)
        {
            inputs = trainingVec.ToList();
            weights = new List<double>();
            for (int i = 0; i < trainingVec.Count(); i++)
                weights.Add(r.NextDouble());
            biasWeight = r.NextDouble();
        }

        public Neuron(double[] trainingVec, double[] weights, double bias)
        {
            inputs = trainingVec.ToList();
            this.weights = weights.ToList();
            biasWeight = bias;
        }

        public double Output
        {
            get { return sigmoid.output(WeightedSum); }
        }

        public double CalculateGradient(Neuron OutputNeuron = null ,double? desiredOutput = null)
        {
            if (desiredOutput != null)
                return Gradient = (desiredOutput.Value - Output) * sigmoid.derivative(Output);
            //надо придумать как лучше получать градиент выходного нейрона
            return Gradient = sigmoid.derivative(Output) * OutputNeuron.weights.Sum(a => a * OutputNeuron.Gradient);
        }

        //public void adjustWeights()
        //{
        //    weights[0] += error * inputs[0];
        //    weights[1] += error * inputs[1];
        //    biasWeight += error;
        //}
    }



}
