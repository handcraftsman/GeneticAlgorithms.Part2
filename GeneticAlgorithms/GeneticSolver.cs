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
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithms
{
    public class GeneticSolver
    {
        private readonly Random _random = new Random();

        private Individual Crossover(Individual parentA, Individual parentB, string geneSet)
        {
            int crossOverPoint = _random.Next(parentA.Genes.Length);
            var childGenes = parentA.Genes.ToCharArray();
            var parentBGenes = parentB.Genes.ToCharArray();
            childGenes[crossOverPoint] = parentBGenes[crossOverPoint];
            var child = new Individual
                {
                    Genes = new String(childGenes)
                };
            return child;
        }

        private IEnumerable<Individual> GenerateChildren(
            IList<Individual> parents,
            Func<Individual, Individual, string, Individual> strategy,
            string geneSet)
        {
            int count = 0;
            while (count < parents.Count)
            {
                int parentAIndex = _random.Next(parents.Count);
                int parentBIndex = _random.Next(parents.Count);
                if (parentAIndex == parentBIndex)
                {
                    continue;
                }
                var parentA = parents[parentAIndex];
                var parentB = parents[parentBIndex];
                yield return strategy(parentA, parentB, geneSet);
                count++;
            }
        }

        private IEnumerable<Individual> GenerateParents(int length, string geneSet)
        {
            Func<Individual> next = () => new Individual
                {
                    Genes = GenerateSequence(length, geneSet)
                };
            var initial = next();
            return initial.Generate(next);
        }

        private string GenerateSequence(int length, string geneSet)
        {
            Func<char> next = () => geneSet[_random.Next(0, geneSet.Length)];
            char initial = next();
            return new String(initial.Generate(next).Take(length).ToArray());
        }

        public string GetBest(int length,
                              string geneSet,
                              Func<string, int> getFitness,
                              Action<int, int, string> displayChild)
        {
            int maxIndividualsInPool = geneSet.Length * 3;
            int generationCount = 1;
            var uniqueIndividuals = new HashSet<string>();
            var parents = GenerateParents(length, geneSet)
                .Where(x => uniqueIndividuals.Add(x.Genes))
                .Take(maxIndividualsInPool)
                .ToList();
            foreach (var individual in parents)
            {
                individual.Fitness = getFitness(individual.Genes);
            }
            parents = parents.OrderBy(x => x.Fitness).ToList();

            displayChild(generationCount, parents.Last().Fitness, parents.Last().Genes);

            int worstParentFitness = parents.Last().Fitness;
            var children = GenerateChildren(parents, Crossover, geneSet);
            do
            {
                var improved = new List<Individual>();
                foreach (var child in children.Where(x => uniqueIndividuals.Add(x.Genes)))
                {
                    child.Fitness = getFitness(child.Genes);
                    if (worstParentFitness >= child.Fitness)
                    {
                        improved.Add(child);
                        if (worstParentFitness > child.Fitness)
                        {
                            displayChild(generationCount, child.Fitness, child.Genes);
                            worstParentFitness = child.Fitness;
                        }
                    }
                }
                generationCount++;
                if (improved.Any())
                {
                    parents = parents
                        .Concat(improved)
                        .OrderBy(x => x.Fitness)
                        .Take(maxIndividualsInPool)
                        .ToList();
                    children = GenerateChildren(parents, Crossover, geneSet);
                }
                else
                {
                    children = GenerateChildren(parents, Mutate, geneSet);
                }
            } while (parents[0].Fitness > 0);
            return parents[0].Genes;
        }

        private Individual Mutate(Individual parentA, Individual parentB, string geneSet)
        {
            var parentGenes = parentA.Genes.ToCharArray();
            int location = _random.Next(0, parentGenes.Length);
            parentGenes[location] = geneSet[_random.Next(0, geneSet.Length)];
            return new Individual
                {
                    Genes = new String(parentGenes)
                };
        }
    }
}