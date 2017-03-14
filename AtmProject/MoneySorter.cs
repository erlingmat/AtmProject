using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Advanced;

namespace AtmProject
{
    public class MoneySorter
    {
        public Dictionary<int, int> MoneyValuesAndSizes = new Dictionary<int,int>();
        // Notes are 1000 mm in diameter that is how they are distinguished from coins.
        private int NoteSizeThreshold = 1000;
        public List<int> MoneyValues = new List<int>();
        private List<int> BinEdges = new List<int>();
        private int NumberOfBins = 3;
        /*
- 1,000 note
- 500 note
- 200 note
- 100 note
- 50 note
- 20 coin (40 mm)
- 10 coin (20 mm)
- 5 coin (50 mm)
- 2 coin (30 mm)
- 1 coin (10 mm)
    */
        public void InitializeMoneyValues()
        {
            BinEdges.Add(999);
            BinEdges.Add(20);
            MoneyValuesAndSizes.Add(1000, NoteSizeThreshold); // MoneyValue, Size
            MoneyValuesAndSizes.Add(500, NoteSizeThreshold); // MoneyValue, Size
            MoneyValuesAndSizes.Add(200, NoteSizeThreshold); // MoneyValue, Size
            MoneyValuesAndSizes.Add(100, NoteSizeThreshold); // MoneyValue, Size
            MoneyValuesAndSizes.Add(50, NoteSizeThreshold); // MoneyValue, Size
            MoneyValuesAndSizes.Add(20, 40); // MoneyValue, Size
            MoneyValuesAndSizes.Add(10, 20); // MoneyValue, Size
            MoneyValuesAndSizes.Add(5, 50); // MoneyValue, Size
            MoneyValuesAndSizes.Add(2, 30); // MoneyValue, Size
            MoneyValuesAndSizes.Add(1, 10); // MoneyValue, Size
            
            MoneyValues.Add(1000);
            MoneyValues.Add(500);
            MoneyValues.Add(200);
            MoneyValues.Add(100);
            MoneyValues.Add(50);
            MoneyValues.Add(20);
            MoneyValues.Add(10);
            MoneyValues.Add(5);
            MoneyValues.Add(2);
            MoneyValues.Add(1);


        }

        public int FindSize(int MoneyValue)
        {
            int size = 0;
            if ( MoneyValuesAndSizes.TryGetValue(MoneyValue, out size))
                return size;
            return -1;
        }

        public int FindBin(int MoneyValue)
        {
            int TargetBin = -1;
            int size = FindSize(MoneyValue);
            if (size > 0)
            {
                if (size > BinEdges[0]) TargetBin = 0; // Note
                if (size < BinEdges[0] && size > BinEdges[1]) TargetBin = 1;
                if (size <= BinEdges[1]) TargetBin = 2;
            }
            return TargetBin;
        }

        public Dictionary<int, int> CalculateMoneyAmounts(int Withdrawl)
        {
            Dictionary<int, int> moneyamounts = new Dictionary<int, int>();
            int rest = Withdrawl;
            
            foreach (var curMoneyValue in MoneyValues)
            {
                int count = 0;

                while (rest - curMoneyValue >= 0)
                {
                    count++;
                    rest -= curMoneyValue;
                }
                moneyamounts.Add(curMoneyValue, count);
            }   
            return moneyamounts;
        } 
    }
}
