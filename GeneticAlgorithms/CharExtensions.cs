//  * **********************************************************************************
//  * Copyright (c) Clinton Sheppard
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution. 
//  * By using this source code in any fashion, you are agreeing to be bound by 
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **********************************************************************************
using System.Drawing;

namespace GeneticAlgorithms
{
    public static class CharExtensions
    {
        public static Point ToPoint(this char gene, string geneSet, int width)
        {
            int index = geneSet.IndexOf(gene);
            int row = index / width;
            int column = index % width;
            return new Point(row, column);
        }
    }
}