using System;
using System.Collections;


namespace SortAlgorithm
{
    public class QuickSort: ISortAlgorithm
    {
        public int Scale { get; private set; }
        private double[] Data;
        // TODO Use generic type.
        private Func<double, double, bool> Comparator;

        public QuickSort()
        {
            Initial(DataScale.Default);
        }

        public QuickSort(int scale)
        {
            Initial(scale);
        }

        public void SetComparator(Func<double, double, bool> cmp)
        {
            Comparator = cmp;
        }

        public void Seed()
        {
            Random random = new Random();

            for (int i = 0; i < Scale; i++)
            {
                Data[i] = random.NextDouble();
            }
        }

        public void Sort()
        {
            DoSort(0, Scale - 1);
        }

        public IEnumerable Current()
        {
            for (int i = 0; i < Scale; i++)
            {
                yield return Data[i];
            }
        }

        private void Initial(int scale)
        {
            if (scale > DataScale.Maximum)
            {
                scale = DataScale.Maximum;
                System.Console.WriteLine("Scale too large, change to {0}", scale);
            }
            if (scale < DataScale.Minimum)
            {
                scale = DataScale.Minimum;
                System.Console.WriteLine("Scale too small, change to {0}", scale);
            }

            Scale = scale;
            Data = new double[Scale];
            Comparator = (double a, double b) => a < b;
        }

        private void DoSort(int l, int r)
        {
            if (l >= r)
            {
                return;
            }

            int part = Partition(l, r);
            if (part > l)
            {
                DoSort(l, part - 1);
            }
            if (part < r)
            {
                DoSort(part + 1, r);
            }
        }

        private int Partition(int l, int r)
        {
            int p = (l + r) / 2;
            Swap(l, p);

            for (p = l, l = l + 1; l <= r;)
            {
                if (Comparator(Data[p], Data[l]))
                {
                    Swap(l, r);
                    r = r - 1;
                }
                else
                {
                    l = l + 1;
                }
            }

            Swap(p, r);

            return r;
        }

        private void Swap(int a, int b)
        {
            double temp = Data[a];
            Data[a] = Data[b];
            Data[b] = temp;
        }
    }
}