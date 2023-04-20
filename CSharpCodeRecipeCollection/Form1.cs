using CSharpCodeRecipeCollection.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpCodeRecipeCollection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var manager = new MonsterManager();
            manager.Add("めたるすらいむ");
            var monster = manager[3];

            Debug.WriteLine(monster.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var a = 1;
            var b = 2;
            Swap(ref a, ref b);
            Debug.WriteLine("a:{0}",a);
            Debug.WriteLine("b:{0}", b);

            var c = 1.5;
            var d = 2.5;
            Swap<double>(ref c, ref d);
            Debug.WriteLine("a:{0}", c);
            Debug.WriteLine("b:{0}", d);

        }

        public static void Swap(ref int a, ref int b)
        {
            int c;
            c= a;
            a = b;
            b = c;
        }

        // ジェネリックを使ったメソッド
        public static void Swap<T>(ref T a, ref T b)
        {
            T c;
            c = a;
            a = b;
            b = c;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var array = new Array<double>(3);
            array.Set(0, 1.2);
            array.Set(1, 1.3);
            array.Set(2, 1.4);
            var value = array.Get(2);
            Debug.WriteLine(value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var gc = new GenericsConstraint<string>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines("sample.txt");
            var we = new WordsExtractor(lines);
            foreach (var word in we.Extract())
            {
                Console.WriteLine(word);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            throw new Exception("えらーでした");
        }
    }
}
