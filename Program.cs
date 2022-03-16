using System;
using System.Collections.Generic;
using Lab3.SortingAlgorithms;
using System.Diagnostics;
using System.Linq;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 10000000;
            List<int> intList = GenerateRandomIntList(length, 50000);       // Random
            List<int> intList2 = GenerateReverseIntList(length);     // Reversed
            List<int> intList3 = GenerateNearlySortedIntList(length);    // NearlySorted

            //List<double> intList = GenerateRandomDoubleList(length, 50000);       // Random
            //List<double> intList2 = GenerateReverseDoubleList(length);     // Reversed
            //List<double> intList3 = GenerateNearlySortedDoubleList(length);    // NearlySorted

            //List<double> doubleList = GenerateRandomDoubleList(100, 500);

            Console.WriteLine("[{0}]", string.Join(", ", intList.ToArray()));

            //HeapSort<int> heapSort = new HeapSort<int>();
            //heapSort.Sort(ref intList);


            //Console.WriteLine("Insertion Sort"); // #1
            //InsertionSort<int> sortingAlgorithm = new InsertionSort<int>();

            //Console.WriteLine("Bubble Sort"); // #2
            //BubbleSort<int> sortingAlgorithm = new BubbleSort<int>();

            //Console.WriteLine("Quick Sort"); // #3
            //QuickSort<double> sortingAlgorithm = new QuickSort<double>();

            //Console.WriteLine("Heap Sort"); // #4
            //HeapSort<int> sortingAlgorithm = new HeapSort<int>();

            //Console.WriteLine("Counting Sort"); // #5
            //CountingSort sortingAlgorithm = new CountingSort();

            Console.WriteLine("Radix Sort"); // #6
            RadixSort sortingAlgorithm = new RadixSort();

            List<double> ElapsedTime = new List<double>();
            for (int i = 0; i < 11; i++)
            {
                List<int> ListCopy = new List<int>(intList);   // change to when int
                //List<double> ListCopy = new List<double>(intList);   // change to when double

                ElapsedTime.Add(TimeSort(sortingAlgorithm, ListCopy));
            }
            Console.WriteLine("finished sort 1");
            double elapsedTimeAverage1 = ElapsedTime.Average();
            double standardDeviation1 = StandardDeviation(ElapsedTime);


            ElapsedTime = new List<double>();
            for (int i = 0; i < 11; i++)
            {
                List<int> ListCopy = new List<int>(intList2);   // change to when int
                //List<double> ListCopy = new List<double>(intList2);   // change to when double

                ElapsedTime.Add(TimeSort(sortingAlgorithm, ListCopy));
            }
            Console.WriteLine("finished sort 2");
            double elapsedTimeAverage2 = ElapsedTime.Average();
            double standardDeviation2 = StandardDeviation(ElapsedTime);


            ElapsedTime = new List<double>();
            for (int i = 0; i < 11; i++)
            {
                List<int> ListCopy = new List<int>(intList3);   // change to when int
                //List<double> ListCopy = new List<double>(intList3);   // change to when double

                ElapsedTime.Add(TimeSort(sortingAlgorithm, ListCopy));
            }
            Console.WriteLine("finished sort 3");
            double elapsedTimeAverage3 = ElapsedTime.Average();
            double standardDeviation3 = StandardDeviation(ElapsedTime);

            Console.Write("Random Elapsed Time Average: ");
            Console.WriteLine(elapsedTimeAverage1);
            Console.Write("Random Standard Deviation: ");
            Console.WriteLine(standardDeviation1);

            Console.Write("Reversed Elapsed Time Average: ");
            Console.WriteLine(elapsedTimeAverage2);
            Console.Write("Reversed Standard Deviation: ");
            Console.WriteLine(standardDeviation2);

            Console.Write("Nearly Sorted Elapsed Time Average: ");
            Console.WriteLine(elapsedTimeAverage3);
            Console.Write("Nearly Sorted Standard Deviation: ");
            Console.WriteLine(standardDeviation3);
        }

        public static double TimeSort<T>(ISortable<T> sortable, List<T> items) where T : IComparable<T>
        {
            // start timer
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            sortable.Sort(ref items);

            // end timer
            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // print info
            //Console.WriteLine(sortable.GetType().ToString());

            // print elapsed time data
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //ts.Hours, ts.Minutes, ts.Seconds,
            //ts.Milliseconds / 10);
            //Console.WriteLine(elapsedTime);
            Console.WriteLine(ts.TotalSeconds);
            return ts.TotalSeconds;

        }

        public static void TimeSort(ISortableDouble sortable, List<double> items)
        {
            // start timer
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            sortable.Sort(items.ToArray());

            // end timer
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            Console.WriteLine(ts.TotalSeconds);
        }
        public static double TimeSort(ISortableInt sortable, List<int> items)
        {
            // start timer
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            sortable.Sort(items.ToArray());

            // end timer
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            Console.WriteLine(ts.TotalSeconds);
            return ts.TotalSeconds;
        }


        public static List<int> GenerateRandomIntList(int length, int maxValue)
        {
            List<int> list = new List<int>();

            Random random = new Random();

            for(int i=0; i < length; i++)
            {
                list.Add(random.Next(maxValue));               
            }

            return list;
        }

        public static List<double> GenerateRandomDoubleList(int length, double maxValue)
        {
            List<double> list = new List<double>();

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                list.Add(random.NextDouble()* maxValue);
            }

            return list;
        }
        public static List<int> GenerateReverseIntList(int length)
        {
            List<int> list = new List<int>();

            for (int i = length; i > 0; i--)
            {
                list.Add(i);
            }

            return list;
        }
        public static List<double> GenerateReverseDoubleList(int length)
        {
            List<double> list = new List<double>();

            for (int i = length; i > 0; i--)
            {
                list.Add(i);
            }

            return list;
        }
        public static List<int> GenerateNearlySortedIntList(int length)
        {
            List<int> list = new List<int>();
            int swapFactor = (length * 25) / 1000;
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                list.Add(i);
            }
            for (int i = 0; i < swapFactor; i++)
            {
                int randNum1 = random.Next(length);
                int randNum2 = random.Next(length);
                int num1 = list[randNum1];
                int num2 = list[randNum2];
                list[randNum1] = num2;
                list[randNum2] = num1;

            }
            return list;
        }
        public static List<double> GenerateNearlySortedDoubleList(int length)
        {
            List<double> list = new List<double>();
            int swapFactor = (length * 25) / 1000;
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                list.Add(i);
            }
            for (int i = 0; i < swapFactor; i++)
            {
                int randNum1 = random.Next(length);
                int randNum2 = random.Next(length);
                double num1 = list[randNum1];
                double num2 = list[randNum2];
                list[randNum1] = num2;
                list[randNum2] = num1;

            }
            return list;
        }
        private static double StandardDeviation(List<double> input)
        {
            var average = input.Average();
            double sumOfSquares = input.Select(x => (average - x) * (average - x)).Sum();

            return Math.Sqrt(sumOfSquares / input.Count);
        }
    }
}
