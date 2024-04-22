using CSharpCodeRecipeCollection.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpCodeRecipeCollection
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Count();
        }

        /// <summary>
        /// 0.1刻みで1.0までカウントする
        /// </summary>
        private void Count()
        {
            // 1.0になるまでループ
            float count = 0.0f;
            while (true)
            {
                // countに0.1を加算
                count += 0.1f;
                Console.WriteLine("足しました->" + count.ToString());
                // 1.0になったら抜ける
                if (count == 1.0f)
                {
                    Console.WriteLine("１になったので抜けます");
                    break;
                }
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            // 誤差を表示
            float countF = 1f;
            double countD = 1d;
            Console.WriteLine("{0:F99}", countF);
            Console.WriteLine("{0:F99}", countD);
        }

        /// <summary>
        /// 0.1刻みで1.0までカウントする
        /// </summary>
        private void CountUp(float eps)
        {
            // 1.0になるまでループ
            float count = 0.0f;
            while (true)
            {
                // countに0.1を加算
                count += 0.1f;
                Console.WriteLine("足しました->" + count.ToString("G17"));
                // 1.0になったら抜ける
                if (Math.Abs(count - 1.0f) <= eps)
                {
                    Console.WriteLine("1になったので抜けます");
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CountUp(Single.Epsilon);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            var fEps = EpsilonHelper.GetFloatEpsilon();
            var dEps = EpsilonHelper.GetDoubleEpsilon();
            CountUp(fEps);

        }


        private void button5_Click(object sender, EventArgs e)
        {
            float eps = 1E-05f;     // 許容範囲のイプシロンを大きめに設定する
            CountUp(eps);
        }

        /// <summary>
        /// 0.1刻みで0までカウントする
        /// </summary>
        private void CountDown(float eps)
        {
            // 1.0になるまでループ
            float count = 1.0f;
            while (true)
            {
                // countに0.1を加算
                count -= 0.1f;
                Console.WriteLine("引きました->" + count.ToString("G17"));

                // 0になったら抜ける
                if (count <= eps)
                {
                    Console.WriteLine("0になったので抜けます");
                    break;
                }
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            CountDown(Single.Epsilon);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Stopwatchクラス生成
            var sw = new System.Diagnostics.Stopwatch();

            //-----------------
            // 計測開始
            sw.Start();

            // ★処理A
            var ans = Math.Pow(2, 100);
            Console.WriteLine(ans);

            // 計測停止
            sw.Stop();


            // 結果表示
            Console.WriteLine("■処理Aにかかった時間");
            TimeSpan ts = sw.Elapsed;
            Console.WriteLine($"　{ts}");
            Console.WriteLine($"　{ts.Hours}時間 {ts.Minutes}分 {ts.Seconds}秒 {ts.Milliseconds}ミリ秒");
            Console.WriteLine($"　{sw.ElapsedMilliseconds}ミリ秒");

            //-----------------
            // 経過時間をリセットしてから計測開始
            sw.Restart();

            // ★処理B
            Console.WriteLine(ruizyo(2, 100));


            // 計測停止
            sw.Stop();

            // 結果表示
            Console.WriteLine("■処理Bにかかった時間");
            ts = sw.Elapsed;
            Console.WriteLine($"　{ts}");
            Console.WriteLine($"　{ts.Hours}時間 {ts.Minutes}分 {ts.Seconds}秒 {ts.Milliseconds}ミリ秒");
            Console.WriteLine($"　{sw.ElapsedMilliseconds}ミリ秒");

        }

        double ruizyo(int baseNum, int exponentNum)
        {
            if (exponentNum <= 0)
            {
                return 1;
            }
            
            return baseNum * ruizyo(baseNum, exponentNum - 1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string input = "Stacey";
            string result = SwapPosition(input);
            Console.WriteLine("入れ替え後の文字列: " + result);
        }
        static string SwapCharacters(string s, int i, int j)
        {
            char[] charArray = s.ToCharArray();
            char temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            return new string(charArray);
        }
        static string SwapPosition(string s, int index = 0)
        {
            // 基底条件: 文字列が空またはインデックスが文字列の長さを超えた場合
            if (string.IsNullOrEmpty(s) || index >= s.Length - 1)
                return s;

            // インデックスが偶数の場合、次の文字と入れ替える
            if (index % 2 == 0)
            {
                s = SwapCharacters(s, index, index + 1);
            }

            // 次のインデックスに再帰的に適用
            return SwapPosition(s, index + 1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var s = "aaabbb";
            var ans = stringCompressionHelper(s, 0, s.Length, 0, ' ', string.Empty);
            Console.WriteLine(ans);
        }

        public static string stringCompressionHelper(string s, int index, int length, int count, char sHolder, string sOut)
        {
            if (index >= length)
            {
                sOut += $"{count}";
                return sOut;
            }

            if (index == 0)
            {
                sHolder = s[index];
                sOut = sHolder.ToString();
                count++;
                return stringCompressionHelper(s, index + 1, length, count, sHolder, sOut);
            }

            if (sHolder == s[index])
            {
                count++;
            }
            else
            {
                sOut += $"{count}";
                sHolder = s[index];
                sOut += sHolder.ToString();
                count = 0;
                count++;
            }

            return stringCompressionHelper(s, index + 1, length, count, sHolder, sOut);
        }
    }
}
