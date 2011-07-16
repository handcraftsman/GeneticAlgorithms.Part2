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
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace GeneticAlgorithms
{
    public class EightQueensSolver
    {
        private const int GeneCount = 8;
        private const string GeneSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@#";
        public static int BoardHeight = 8;
        public static int BoardWidth = 8;

        public static int XOffsetEast = 1;
        public static int XOffsetWest = -1;

        public static int YOffsetNorth = -1;
        public static int YOffsetSouth = 1;

        private static int CountQueensAttacked(
            IEnumerable<IEnumerable<Point>> attackablePoints,
            ICollection<Point> queenLocations)
        {
            return attackablePoints.Count(direction => direction.Any(queenLocations.Contains));
        }

        public static Point CreatePoint(Point point, int xOffset, int yOffset)
        {
            return new Point(point.X + xOffset, point.Y + yOffset);
        }

        public static IEnumerable<IEnumerable<Point>> GetAttackablePoints(Point queenPosition)
        {
            return new Func<Point, Point>[]
                {
                    GoNorth, GoNorthEast, GoEast, GoSouthEast,
                    GoSouth, GoSouthWest, GoWest, GoNorthWest
                }
                .Select(direction => queenPosition
                                         .GenerateFrom(direction)
                                         .Skip(1)
                                         .TakeWhile(IsOnTheBoard));
        }

        public static Point GoEast(Point point)
        {
            return CreatePoint(point, XOffsetEast, 0);
        }

        public static Point GoNorth(Point point)
        {
            return CreatePoint(point, 0, YOffsetNorth);
        }

        public static Point GoNorthEast(Point point)
        {
            return CreatePoint(point, XOffsetEast, YOffsetNorth);
        }

        public static Point GoNorthWest(Point point)
        {
            return CreatePoint(point, XOffsetWest, YOffsetNorth);
        }

        public static Point GoSouth(Point point)
        {
            return CreatePoint(point, 0, YOffsetSouth);
        }

        public static Point GoSouthEast(Point point)
        {
            return CreatePoint(point, XOffsetEast, YOffsetSouth);
        }

        public static Point GoSouthWest(Point point)
        {
            return CreatePoint(point, XOffsetWest, YOffsetSouth);
        }

        public static Point GoWest(Point point)
        {
            return CreatePoint(point, XOffsetWest, 0);
        }

        public static bool IsOnTheBoard(Point point)
        {
            return point.X >= 0 && point.X < BoardWidth && point.Y >= 0 && point.Y < BoardHeight;
        }

        public string Solve()
        {
            Func<string, int> getFitness = child =>
                {
                    var queenLocations = new HashSet<Point>(child.Select(x => x.ToPoint(GeneSet, BoardWidth)));
                    int fitness = queenLocations.Sum(x => CountQueensAttacked(GetAttackablePoints(x), queenLocations));
                    fitness += 10000 * (GeneCount - queenLocations.Count);
                    return fitness;
                };

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Action<int, int, string> displayCurrentBest =
                (generation, fitness, item) =>
                    {
                        var board = new char?[BoardHeight,BoardWidth];

                        foreach (var queenLocation in item.Select(x => x.ToPoint(GeneSet, BoardWidth)))
                        {
                            board[queenLocation.X, queenLocation.Y] = 'Q';
                        }

                        for (int i = 0; i < BoardHeight; i++)
                        {
                            for (int j = 0; j < BoardWidth; j++)
                            {
                                Console.Write(board[i, j] ?? '.');
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("generation\t{0} fitness\t{1} elapsed: {2}",
                                          generation.ToString().PadLeft(5, ' '),
                                          fitness.ToString().PadLeft(2, ' '),
                                          stopwatch.Elapsed);
                    };
            string result = new GeneticSolver().GetBest(GeneCount,
                                                        GeneSet,
                                                        getFitness,
                                                        displayCurrentBest);
            Console.WriteLine(result);
            return result;
        }
    }
}