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

        private void button22_Click(object sender, EventArgs e)
        {
            var str = "電話番号は、084-000-0000です。";
            var rgx = new Regex(@"(\d{2,4})-(\d{2,4})-(\d{4})");
            var match = rgx.Match(str);

            if (match.Success)
            {
                Console.WriteLine($"位置:{match.Index} マッチ文字列:{match.Value}");

                foreach (Group m in match.Groups)
                {
                    Console.WriteLine(m.Value);
                }
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            var str = "自宅の電話番号は、084-000-0000です。携帯は、080-0000-0000です。";
            var rgx = new Regex(@"\d{2,4}-\d{2,4}-\d{4}");
            var result = rgx.Matches(str);
            Console.WriteLine(result.Count);
            if (result.Count != 0 && result[0].Success)
            {
                Console.WriteLine(result[0]);
            }

            foreach (Match m in result)
            {
                Console.WriteLine($"位置:{m.Index} マッチ文字列:{m.Value}");
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            var tags = "<p><strong>WINGS</strong>サイト<a href='index.html'><img src='wings.jpg'></img></a></p>";
            var rgx = new Regex(@"<.+>");
            var result = rgx.Matches(tags);

            foreach (Match m in result)
            {
                Console.WriteLine(m.Value);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            var tags = "<p><strong>WINGS</strong>サイト<a href='index.html'><img src='wings.jpg'></img></a></p>";
            var rgx = new Regex(@"<.+?>");
            var result = rgx.Matches(tags);

            foreach (Match m in result)
            {
                Console.WriteLine(m.Value);
            }

        }

        private void button26_Click(object sender, EventArgs e)
        {
            var str = "仕事用はwings@example.comです。プライベート用はYAMA@example.comです。";
            var rgx = new Regex(@"[a-z0-9+_-]+@[a-z0-9-]+(\.[a-z]+)", RegexOptions.IgnoreCase);

            var result = rgx.Matches(str);
            foreach (Match m in result)
            {
                Console.WriteLine(m.Value);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            var str = "10人のインディアン。\n1年生になったら";
            var rgx = new Regex(@"^\d+", RegexOptions.Multiline);
            var result = rgx.Matches(str);

            foreach (Match m in result)
            {
                Console.WriteLine(m.Value);
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            var str = "初めまして。\nよろしくお願いします。";
            var rgx = new Regex(@"^.+", RegexOptions.Singleline);
            var result = rgx.Matches(str);

            foreach (Match m in result)
            {
                Console.WriteLine(m.Value);
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            var str = "サポートサイトはhttp://www.wings.msn.to/です。";
            var rgx = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[a-z_0-9-./?%&=]*)?", RegexOptions.IgnoreCase);

            Console.WriteLine(rgx.Replace(str, "<a href='$0'>$0</a>"));
        }

        private void button30_Click(object sender, EventArgs e)
        {
            using (var writer = new StreamWriter(@"data.log", append: true, Encoding.GetEncoding("Shift-JIS")))
            {
                writer.WriteLine(DateTime.Now.ToString());
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            using (var reader = new StreamReader("data.log"))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            using (var reader = new StreamReader("data.log"))
            {
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            // FileInfoオブジェクトを生成（引数はファイルのパス）
            var file = new FileInfo(@"sample.txt");

            // ファイルが存在するか
            Console.WriteLine(file.Exists);
            // ファイル名を取得
            Console.WriteLine(file.Name);
            // フォルダ名を取得
            Console.WriteLine(file.DirectoryName);
            // 読み取り専用か
            Console.WriteLine(file.IsReadOnly);
            // ファイルの最終アクセス日時、最終更新日時、サイズを取得
            Console.WriteLine(file.LastAccessTime);
            Console.WriteLine(file.LastWriteTime);
            Console.WriteLine(file.Length);
            
            // ファイルをコピー
            var file2 = file.CopyTo(@"sample_copy.txt", true);

            // ファイルを移動
            file2.MoveTo(@"SelfCSharp\sample_copy.txt");

            // ファイル名を変更
            file.MoveTo(@"SelfCSharp\sample_renamed.txt");

            // ファイルを削除
            file2.Delete();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            var dir = new DirectoryInfo(@"C:\Users\kyota\source\repos\CSharpCodeRecipeCollection\CSharpCodeRecipeCollection\bin\Debug");

            // フォルダが存在するか
            Console.WriteLine(dir.Exists);
            // フォルダの親フォルダを取得
            Console.WriteLine(dir.Parent);
            // フォルダのルート(根)を取得
            Console.WriteLine(dir.Root);
            // ファイルの作成日時、最終アクセス日時、最終更新日時
            Console.WriteLine(dir.CreationTime);
            Console.WriteLine(dir.LastAccessTime);
            Console.WriteLine(dir.LastWriteTime);

            // サブフォルダの一覧を取得
            var dirs = dir.GetDirectories();
            foreach ( var d in dirs )
            {
                Console.WriteLine(d.FullName);
            }

            // フォルダの作成
            var dir2 = new DirectoryInfo(@"NewFolder");
            dir2.Create();

            // フォルダ名の変更
            dir2.MoveTo(@"NewFolder2");

            // フォルダの移動
            dir2.MoveTo(@"C:\Users\kyota\source\repos\CSharpCodeRecipeCollection\CSharpCodeRecipeCollection\bin\NewFolder3");

            dir2.CreateSubdirectory("sub");

            dir2.Delete(true);
        }
    }
}
