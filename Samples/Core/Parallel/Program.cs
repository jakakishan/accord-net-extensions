﻿using System;
using Accord.Extensions;

namespace Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestParallelProcessor.Test();
            //testParallelWhile();
            testParallelRandom();
        }

        static void testParallelWhile()
        {
            //adds support for parallel while (missing in .NET)

            int i = 0;
            ParallelExtensions.While(() => i < 1, (loopState) => 
            {
                Console.WriteLine("Iteration: {0}", i);
                System.Threading.Interlocked.Increment(ref i);
            });
        }

        static void testParallelRandom()
        {
            //System.Radnom class can not generate numbers in parallel. Solution: ParallelRandom<> and ParalellRandom 
            //parallel random creates few instances of Random class and initializes them with seed generated by RNGCryptoServiceProvieder random generator class.

            System.Threading.Tasks.Parallel.For(0, 100, (i) => 
            {
                Console.Write(ParallelRandom.Next() + " ");
            });

            //try generic class also (enables parallel rand generation for any random generator)
            //ParallelRandom<Random>.Initialize((seed) => new Random(seed));
            //ParallelRandom<Random>.Local.Next();
        }
    }
}