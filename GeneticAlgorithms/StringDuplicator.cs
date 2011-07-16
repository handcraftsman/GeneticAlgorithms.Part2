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
            string geneSet = new String(toMatch.Distinct().ToArray());
            string result = solver.GetBest(toMatch.Length,
                                           geneSet,
                                           toMatch);
            Console.WriteLine(result);
            return result;
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