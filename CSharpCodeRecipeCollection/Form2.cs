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


    }
}
