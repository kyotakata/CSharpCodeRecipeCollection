using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventSample
{
    public partial class Form1 : Form
    {
        Form2 _form2 = new Form2();

        public Form1()
        {
            InitializeComponent();
            _form2.MouseDown += _form2_MouseDown;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _form2.ShowDialog();
        }

        private void _form2_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"Form2.MouseDownイベント：クリックされた座標は({e.X},{e.Y})");
        }
    }
}
