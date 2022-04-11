using CalcServiceLibrary;
using MathServiceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationClient
{
    public partial class Form1 : Form
    {
        //private readonly IMathService _mathClient = ChannelFactory<IMathService>.CreateChannel(
        //    new BasicHttpBinding(),
        //    new EndpointAddress("http://localhost:4444/MathService")
        //    );
        //private readonly ICalcService _calcClient = ChannelFactory<ICalcService>.CreateChannel(
        //    new BasicHttpBinding(),
        //    new EndpointAddress("http://localhost:5555/CalcService")
        //    );
        private readonly IMathService _mathClient = new ChannelFactory<IMathService>("MathService").CreateChannel();
        private readonly ICalcService _calcClient = new ChannelFactory<ICalcService>("CalcService").CreateChannel();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int number1 = Convert.ToInt32(textBox1.Text);
            int number2 = Convert.ToInt32(textBox2.Text);

            int result = _mathClient.Add(new MathServiceLibrary.MyNumbers() { Number1 = number1, Number2 = number2 });
            textBox3.Text = result.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int number1 = Convert.ToInt32(textBox1.Text);
            int number2 = Convert.ToInt32(textBox2.Text);

            int result = _mathClient.Substract(new MathServiceLibrary.MyNumbers() { Number1 = number1, Number2 = number2 });
            textBox3.Text = result.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int number1 = Convert.ToInt32(textBox1.Text);
            int number2 = Convert.ToInt32(textBox2.Text);

            int result = _calcClient.Multiply(new CalcServiceLibrary.MyNumbers() { Number1 = number1, Number2 = number2 });
            textBox3.Text = result.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int number1 = Convert.ToInt32(textBox1.Text);
            int number2 = Convert.ToInt32(textBox2.Text);

            int result = _calcClient.Divide(new CalcServiceLibrary.MyNumbers() { Number1 = number1, Number2 = number2 });
            textBox3.Text = result.ToString();
        }
    }
}
