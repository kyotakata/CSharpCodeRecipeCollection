using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeRecipeCollection.Helper
{
    internal static class EpsilonHelper
    {
        /// <summary>
        /// 計算機イプシロン（float）を求める。変数をひたすら2で割り続け、ゼロになった瞬間のひとつ前を捉える。
        /// </summary>
        /// <returns>計算機イプシロン（float）</returns>
        internal static float GetFloatEpsilon()
        {

            float eps = 1.0f;
            while (1.0f + eps / 2.0f > 1.0f)
            {
                eps /= 2.0f;
            }
            Console.WriteLine(eps);
            return eps;
        }

        /// <summary>
        /// 計算機イプシロン（double）を求める。変数をひたすら2で割り続け、ゼロになった瞬間のひとつ前を捉える。
        /// </summary>
        /// <returns>計算機イプシロン（double）</returns>
        internal static double GetDoubleEpsilon()
        {
            double eps = 1.0d;
            while (1.0d + eps / 2.0d > 1.0d)
            {
                eps /= 2.0d;
            }
            Console.WriteLine(eps);
            return eps;
        }
    }
}
