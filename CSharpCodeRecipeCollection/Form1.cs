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
using System.Text.RegularExpressions;
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

        private void button7_Click(object sender, EventArgs e)
        {
            var s1 = new Stack<int>();
            var data = new string[] { "一郎", "二郎", "三郎" };
            var s2 = new Stack<string>(data);
            foreach (var name in s2)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("sの要素数は{0}です", s2.Count);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var s = new Stack<int>();
            s.Push(1); //要素：1
            s.Push(2); //要素：2, 1
            s.Push(3); //要素：3, 2, 1

            foreach (var i in s)
            {
                Console.WriteLine(i);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);

            Console.WriteLine("先頭の要素は{0}です", s.Peek());

            foreach (var i in s)
            {
                Console.WriteLine(i);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);

            Console.WriteLine("先頭の要素は{0}です", s.Pop());

            foreach (var i in s)
            {
                Console.WriteLine(i);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);


            s.Clear(); //要素を削除

            Console.WriteLine("sの要素数は{0}です", s.Count);
            foreach (var i in s)
            {
                Console.WriteLine(i);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);

            Console.WriteLine("sに2が含まれているか調べます.結果は{0}です.", s.Contains(2));
            Console.WriteLine("sに4が含まれているか調べます.結果は{0}です.", s.Contains(4));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //何故かコンパイルエラー

            //var s = new Stack<int>();

            //Console.WriteLine("TryPeekを実行します.結果は{0},取得した値は{1}です", s.TryPeek(out int val1), val1);

            //s.Push(1);
            //s.Push(2);
            //s.Push(3);

            //Console.WriteLine("TryPeekを実行します.結果は{0},取得した値は{1}です", s.TryPeek(out int val2), val2);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //何故かコンパイルエラー

            //var s = new Stack<int>();

            //Console.WriteLine("TryPopを実行します.結果は{0},取得した値は{1}です", s.TryPop(out int val1), val1);

            //s.Push(1);
            //s.Push(2);
            //s.Push(3);

            //Console.WriteLine("TryPopを実行します.結果は{0},取得した値は{1}です", s.TryPop(out int val2), val2);

            //foreach (var i in s)
            //{
            //    Console.WriteLine(i);
            //}
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);

            int[] s_array = s.ToArray();

            for(int i = 0; i < s_array.Length; i++)
            {
                Console.WriteLine(s_array[i]);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var s = new Stack<int>();
            for(int i = 0; i < 5; i++)
            {
                s.Push(i);
            }

            var array = new int[10];
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = 10;
            }

            s.CopyTo(array, 3);

            Console.WriteLine("[{0}]", string.Join(" ", array));
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            var tel = new[] { "080-0000-0000aaa", "084-000-0000", "184-0000" };
            var rgx = new Regex(@"\d{2,4}-\d{2,4}-\d{4}");
            foreach (var t in tel)
            {
                Console.WriteLine(rgx.IsMatch(t) ? t : "アンマッチ");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var tel = new[] { "080-0000-0000aaa", "aaa084-000-0000", "184-0000" };
            var rgx = new Regex(@"^\d{2,4}-\d{2,4}-\d{4}");
            foreach (var t in tel)
            {
                Console.WriteLine(rgx.IsMatch(t) ? t : "アンマッチ");
            }

        }

        private void button20_Click(object sender, EventArgs e)
        {
            var tel = new[] { "080-0000-0000aaa", "aaa084-000-0000", "184-0000" };
            var rgx = new Regex(@"\d{2,4}-\d{2,4}-\d{4}$");
            foreach (var t in tel)
            {
                Console.WriteLine(rgx.IsMatch(t) ? t : "アンマッチ");
            }

        }

        private void button21_Click(object sender, EventArgs e)
        {
            var tel = new[] { "080-0000-0000aaa", "aaa084-000-0000", "aaa084-000-0000aaa", "084-000-0000", "184-0000" };
            var rgx = new Regex(@"^\d{2,4}-\d{2,4}-\d{4}$");
            foreach (var t in tel)
            {
                Console.WriteLine(rgx.IsMatch(t) ? t : "アンマッチ");
            }

        }
    }
}
