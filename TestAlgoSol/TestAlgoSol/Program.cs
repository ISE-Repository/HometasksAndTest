using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TestAlgoSol
{
class Program
{
        #region T1
        static int FactorialRecursion(int input)
        {
            if (input == 0 | input == 1)
            {
                return 1;
            }
            else
            {
                return input * FactorialRecursion(input - 1);
            }
        }
        static int FactorialIteration(int input)
        {
            int result = 1;
            if (input != 0)
            {
                result = input;
                while (input > 1)
                {
                    result = result * (input - 1);
                    input--;
                }
            }
            return result;
        }


        static int FibonacciRecursion(int input)
        {
            if (input <= 2)
            {
                return 1;
            }
            else
            {
                return FibonacciRecursion(input - 1) + FibonacciRecursion(input - 2);
            }
        }
        static int FibonacciIteration(int input)
        {
            int result = 1;
            if (input > 2)
            {
                int a = 1;
                int b = 1;
                for (int i = 3; i <= input; i++)
                {
                    result = a + b;
                    a = b;
                    b = result;
                }
            }
            return result;
        }

        static int GreatestCommonDivisior(int a, int b)
        {
            while (a != 0 & b != 0)
            {
                if (a >= b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }
            return a + b;
        }

        static List<double> QuadericEquationSolving(int a, int b, int c)
        {
            List<double> result = new List<double>();
            double discriminant = Math.Sqrt(b * b - 4 * a * c);
            if (discriminant >= 0)
            {
                result.Add((-b + discriminant) / (2 * a));
                result.Add((-b - discriminant) / (2 * a));
            }
            return result;
        }

        static string HexadecimalConvert(int input)
        {
            StringBuilder result = new StringBuilder();
            int modulo = 0;
            while (input > 0)
            {
                modulo = input % 16;
                input = (input - modulo) / 16;
                if (modulo < 10)
                {
                    result.Insert(0, modulo);
                }
                else
                {
                    switch (modulo)
                    {
                        case 10:
                            result.Insert(0, "A");
                            break;
                        case 11:
                            result.Insert(0, "B");
                            break;
                        case 12:
                            result.Insert(0, "C");
                            break;
                        case 13:
                            result.Insert(0, "D");
                            break;
                        case 14:
                            result.Insert(0, "E");
                            break;
                        case 15:
                            result.Insert(0, "F");
                            break;
                    }
                }
            }
            return result.ToString();
        }
        #endregion
        #region T2
        //Insert sort realization
        static void InsertSort(double[] array)
        {
            int i = 0;
            double key = 0;

            for (int j = 1; j < array.Length; j++)
            {
                key = array[j];
                i = j - 1;
                while (i >= 0 && array[i] > key)
                {
                    array[i + 1] = array[i];
                    i--;
                }
                array[i + 1] = key;
            }
        }

        //Merge sort realization
        static double[] Merge(double[] arr1, double[] arr2)
        {
            int a = 0, b = 0;
            double[] merged = new double[arr1.Length + arr2.Length];

            for (int i = 0; i < arr1.Length + arr2.Length; i++)
            {
                if (a < arr1.Length && b < arr2.Length)
                {
                    if (arr1[a] > arr2[b])
                    {
                        merged[i] = arr2[b];
                        b++;
                    }
                    else
                    {
                        merged[i] = arr1[a];
                        a++;
                    }
                }
                else
                {
                    if (a < arr1.Length)
                    {
                        merged[i] = arr1[a];
                        a++;
                    }
                    else
                    {
                        merged[i] = arr2[b];
                        b++;
                    }
                }
            }
            return merged;
        }
        static double[] MergeSort(double[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }
            else
            {
                int midPoint = array.Length / 2;
                return Merge(MergeSort(array.Take(midPoint).ToArray()),
                    MergeSort(array.Skip(midPoint).ToArray()));
            }
        }

        //Heap sort realization
        static void Heapify(double[] array, int heapSize, int position)
        {
            int left = (position + 1) * 2 - 1;
            int right = (position + 1) * 2;
            int largest = 0;
            if (left < heapSize && array[left] > array[position])
            {
                largest = left;
            }
            else
            {
                largest = position;
            }
            if (right < heapSize && array[right] > array[largest])
            {
                largest = right;
            }
            if (largest != position)
            {
                double temp = array[position];
                array[position] = array[largest];
                array[largest] = temp;
                Heapify(array, heapSize, largest);
            }

        }
        static void BuildMaxHeap(double[] array)
        {
            for (int i = (array.Length - 1) / 2; i >= 0; i--)
            {
                Heapify(array, array.Length, i);
            }
        }
        static void HeapSort(double[] array)
        {
            BuildMaxHeap(array);
            int heapSize = array.Length;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                double temp = array[i];
                array[i] = array[0];
                array[0] = temp;
                heapSize--;
                Heapify(array, heapSize, 0);
            }
        }

        //Quick sort realization
        static void QuickSort(double[] arr, int first, int last)
        {
            double p = arr[(int)((last - first) / 2 + first)];
            double temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (arr[i] < p && i <= last) ++i;
                while (arr[j] > p && j >= first) --j;
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++i; --j;
                }
            }
            if (j > first) QuickSort(arr, first, j);
            if (i < last) QuickSort(arr, i, last);
        }
        #endregion

        static void Main(string[] args)
        {
            SortTask();
            //ClassicAlgorithms();

            Console.ReadKey();
        }

        private static void ClassicAlgorithms()
        {
            int a = 10;

            Console.WriteLine("FactorialRecursion {0}", FactorialRecursion(a));
            Console.WriteLine("FactorialIteration {0}", FactorialIteration(a));
            Console.WriteLine("FibonacciRecursion {0}", FibonacciRecursion(a));
            Console.WriteLine("FibonacciIteration {0}", FibonacciIteration(a));
            Console.WriteLine("GreatestCommonDivisior 100,3 {0}", GreatestCommonDivisior(a, 3));

            List<double> b = QuadericEquationSolving(1, 3, 2);
            foreach (double i in b)
            {
                Console.WriteLine("QuadericEquationSolving 1,3,2 {0}", i);
            }

            Console.WriteLine("HexadecimalConvert {0}", HexadecimalConvert(a * a * a));

            Console.ReadKey();
        }

        private static void SortTask()
        {
            Random r;
            //число значений в массиве
            int num = 20000;
            //инициализация массива
            double[] a = new double[num];
            double[] answer;

            for (int i = 0; i < num; i++)
            {
                r = new Random(i);
                double random_num = (double)r.Next(0, 1000);
                a[i] = random_num;
            }

            Stopwatch sw = new Stopwatch();
            PrintArray(a, 0);

            answer = a;
            sw.Start();
            InsertSort(answer);
            sw.Stop();
            PrintArray(answer, 1);
            Console.WriteLine(sw.Elapsed.TotalMilliseconds.ToString());

            sw = new Stopwatch();
            answer = a;
            sw.Start();
            answer = MergeSort(answer);
            PrintArray(answer, 2);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds.ToString());

            sw = new Stopwatch();
            sw.Start();
            answer = a;
            QuickSort(answer, 0, answer.Length - 1);
            PrintArray(answer, 3);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds.ToString());

            sw = new Stopwatch();
            sw.Start();
            answer = a;
            HeapSort(answer);
            PrintArray(answer, 4);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds.ToString());
        }

        static void PrintArray(double[] array, uint val)
        {
            string s;
            s = string.Empty;
            foreach (int i in array)
            {
                s += i.ToString() + " ";
            }

            switch (val)
            {
                case 1:
                    Console.WriteLine("После сортировки вставками");
                    break;
                case 2:
                    Console.WriteLine("После сортировки слиянием");
                    break;
                case 3:
                    Console.WriteLine("После быстрой сортировки");
                    break;
                case 4:
                    Console.WriteLine("После пирамидальной сортировки");
                    break;
                case 0:
                    Console.WriteLine("Исходный массив значений");
                    break;
            }
            //Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
