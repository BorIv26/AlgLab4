using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlgLab4
{
    [TestFixture]
    class Test
    {
        static Dictionary<string, float[,]> matrices = new Dictionary<string, float[,]>()
        {
            {"Zero", new float[,] { { 1, 2, 3 }, { 2, 4, 6 }, { 3, 6, 9 } } },
            {"Redheffer", new float[,] { { 1, 1, 1 }, { 1, 1, 0 }, { 1, 0, 1 } } },
            {"TwoOnTwo", new float[,] { { 1, 1 }, { 1, 1 } } },
            {"Unit", new float[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } } }

        };

        static float[,] GetMatrixByKey(string key) => matrices[key];
        [Test]
        [TestCase("Zero")]
        public void ZeroDetermCheck(string key)
        {
            Assert.AreEqual(0, Recursive.GetDeterminant(GetMatrixByKey(key)));
        }

        [Test]
        public void RedhefferCheck()
        {
            Assert.AreEqual(GetMatrixByKey("Redheffer"), Redheffer.GetMatrix(3));
        }
        [Test]
        [TestCase(0, "TwoOnTwo")]

        public void TwoOnTwoMatrixCheck(float exp, string key)
        {
            Assert.AreEqual(exp, Recursive.GetDeterminant(GetMatrixByKey(key)));
        }
        [Test]
        public void UnitCheck()
        {
            Assert.AreEqual(1, Recursive.GetDeterminant(GetMatrixByKey("Unit")));
        }

        [Test]
        public void MartensFunctionCheck()
        {
            int[] MartensFirst10 = new int[] { 1, 0, -1, -1, -2, -1, -2, -2, -2, -1 };
            int[] WorkOfMartens = new int[MartensFirst10.Length];
            for (int i = 0; i < MartensFirst10.Length; i++)
            {
                WorkOfMartens[i] = (int)Redheffer.GetMartensFunc(i + 1);
            }

            Assert.AreEqual(MartensFirst10, WorkOfMartens);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void SingleDetermCheck(float exp)
        {
            Assert.AreEqual(exp, Recursive.GetDeterminant(new float[,] { { exp } }));
        }
    }
}
