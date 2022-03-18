using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Divisor_density
{
    class Program
    {
        static void Main(string[] args)
        {
            float value = 0;
            float density = 0f;
            float count = 0f;
            int stop;
            int quotient = 1;
            bool divFit;
            bool densFit;
            List<float> divisorClass = new List<float>();
            List<float> densityClass = new List<float>();
            List<int> divisorClassSize = new List<int>();
            List<int> densityClassSize = new List<int>();

            while (true)
            {
                divisorClass.Clear();
                densityClass.Clear();
                divisorClassSize.Clear();
                densityClassSize.Clear();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\tEnter last value:");
                value = Convert.ToInt32(Console.ReadLine());

                Stopwatch stopwatch = Stopwatch.StartNew(); // <- Stopwatch Start

                //Console.WriteLine();
                //Console.WriteLine("\tValue: \t\tCount: \t\tDensity: ");
                for (int i = 1; i <= value; i++)
                {
                    count = 0f;
                    stop = (int)Math.Floor((double)(i / 2));

                    for (int j = 1; j <= i; j++)
                    {
                        if (i % j == 0)
                        {
                            quotient = i / j;
                            if (j == quotient)
                            {
                                count += (count + 1);
                                break;
                            }         
                            else if (j > quotient)
                            {
                                count *= 2;
                                break;
                            }
                            else if (j > stop)
                            {
                                count++;
                                break;
                            }
                            else
                            {
                                count++;
                            }
                        }
                    }
                    density = (float)Math.Round(count / i, 3);

                    divFit = false;
                    densFit = false;
                    //Console.WriteLine("DivLength: " + divisorClass.Count);
                    //Console.ReadLine();
                    for (int c = 0; c < divisorClass.Count; c++)
                    {
                        if (divisorClass[c] == count)
                        {
                            divisorClassSize[c]++;
                            divFit = true;
                        }
                    }

                    if (divFit == false)
                    {
                        divisorClass.Add(count);
                        divisorClassSize.Add(1);
                    }

                    //Console.WriteLine("DensLength: " + densityClass.Count);
                    //Console.ReadLine();
                    for (int c = 0; c < densityClass.Count; c++)
                    {
                        if (densityClass[c] == density)
                        {
                            densityClassSize[c]++;
                            densFit = true;
                        }
                    }

                    if (densFit == false)
                    {
                        densityClass.Add(density);
                        densityClassSize.Add(1);
                    }

                    //Console.WriteLine("\t" + i + "\t\t" + count + "\t\t" + density);
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\tDivisor Class: \tSize: \t\tProbability:");

                for (int i = 0; i < divisorClass.Count; i++)
                {
                    Console.WriteLine("\t" + divisorClass[i] + "\t\t" + divisorClassSize[i] + "\t\t" + (float)divisorClassSize[i]/value);
                }

                /*Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\tDensity Class: \t\tSize: ");

                for (int i = 0; i < densityClass.Count; i++)
                {
                    Console.WriteLine("\t" + densityClass[i] + "\t\t\t" + densityOccurence[i]);
                }*/

                Console.WriteLine();
                Console.WriteLine("\tNumber of Classes: " + divisorClass.Count() + " (Relative: " + (float)(divisorClass.Count()/value) + ")");

                Console.WriteLine();
                Console.WriteLine("\tExecution Time: " + stopwatch.ElapsedMilliseconds + " ms");
                stopwatch.Stop(); // <- Stopwatch Stop
            }

        }
    }
}
