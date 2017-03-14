using Microsoft.VisualStudio.TestTools.UnitTesting;
using AtmProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmProject.Tests
{
    [TestClass()]
    public class MoneySorterTests
    {
       public static MoneySorter sorter = new MoneySorter();

        [AssemblyInitialize()]
        public static void Initialize(TestContext ctx)
        {
            sorter.InitializeMoneyValues();

        }

        [TestMethod()]
        public void CalculateMoneyAmountsTest()
        {
            Dictionary<int, int> result = sorter.CalculateMoneyAmounts(1000);
            int thousands = 0;
            result.TryGetValue(1000, out thousands);
            Assert.AreEqual(1, thousands);
        }

        [TestMethod()]
        public void MoneyBinSorterTest()
        {

            int[] bins = new int[3];
            bins[0] = 0;
            bins[1] = 0;
            bins[2] = 0;
            foreach (var value in sorter.MoneyValues)
            {
                bins[sorter.FindBin(value)]++;
            }

            Assert.AreEqual(1, bins[0]); 

        }
    }
}