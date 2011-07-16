//  * **********************************************************************************
//  * Copyright (c) Clinton Sheppard
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution. 
//  * By using this source code in any fashion, you are agreeing to be bound by 
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **********************************************************************************

using System;
using System.Diagnostics;
using System.Linq;

using FluentAssert;

using NUnit.Framework;

namespace GeneticAlgorithms
{
    public class StringDuplicator
    {
        public string Duplicate(string toMatch)
        {
            var solver = new GeneticSolver();
            int geneCount = toMatch.Length;
            Func<string, int> getFitness = child =>
                {
                    int matches = Enumerable.Range(0, geneCount)
                        .Count(x => child[x] == toMatch[x]);
                    return matches;
                };
            string geneSet = new String(toMatch.Distinct().ToArray());
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Action<int, int, string> displayCurrentBest =
                (generation, fitness, item) =>
                Console.WriteLine("generation\t{0} fitness\t{1} {2}\telapsed: {3}",
                                  generation.ToString().PadLeft(5, ' '),
                                  fitness.ToString().PadLeft(TotalWidth(toMatch), ' '),
                                  item,
                                  stopwatch.Elapsed);

            string result = solver.GetBest(toMatch.Length,
                                           geneSet,
                                           getFitness,
                                           displayCurrentBest);
            Console.WriteLine(result);
            return result;
        }

        private static int TotalWidth(string expected)
        {
            return (int)Math.Floor(Math.Log10(Math.Abs(expected.Length != 0 ? expected.Length : 1))) + 1;
        }
    }

    [TestFixture]
    public class StringDuplicatorTests
    {
        [Test]
        public void Given__Hello_world()
        {
            const string input = "Hello world!";
            string result = new StringDuplicator().Duplicate(input);
            result.ShouldBeEqualTo(input);
        }
    }
}