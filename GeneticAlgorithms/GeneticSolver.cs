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

namespace GeneticAlgorithms
{
    public class GeneticSolver
    {
        private readonly Random _random = new Random();

        private string GenerateSequence(int length, string geneSet)
        {
            Func<char> next = () => geneSet[_random.Next(0, geneSet.Length)];
            char initial = next();
            return new String(initial.Generate(next).Take(length).ToArray());
        }

        public string GetBest(int length, string geneSet, Func<string, int> getFitness, Action<int, int, string> displayChild)
        {
            int generationCount = 1;
            var parent = GenerateSequence(length, geneSet);
            var parentScore = getFitness(parent);
            displayChild(generationCount, parentScore, parent);
            while (parentScore != length)
            {
                var child = Mutate(parent, geneSet);
                var childScore = getFitness(child);
                if (childScore > parentScore)
                {
                    parentScore = childScore;
                    parent = child;
                    displayChild(generationCount, parentScore, parent);
                }
                generationCount++;
            }
            return parent;
        }

        private string Mutate(string parent, string geneSet)
        {
            int location = _random.Next(0, parent.Length);
            var parentGenes = parent.ToCharArray();
            parentGenes[location] = geneSet[_random.Next(0, geneSet.Length)];
            return new String(parentGenes);
        }
    }
}