using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backpropagation
{
    public class Synapse
    {
        public Neuron InputNeuron;
        public Neuron OutputNeuron;
        public double Weight { get; set; }
        public Synapse(double weight, Neuron inputNeuron, Neuron outputNeuron)
        {
            Weight = weight;
            InputNeuron = inputNeuron;
            OutputNeuron = outputNeuron;
        }
        public Synapse()
        {
            Weight = 0;
            InputNeuron = null;
            OutputNeuron = null;
        }
    }
}
