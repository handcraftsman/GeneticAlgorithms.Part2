﻿//  * **********************************************************************************
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

namespace GeneticAlgorithms
{
    public static class TExtensions
    {
        public static IEnumerable<T> Generate<T>(this T initial, Func<T> next)
        {
            var current = initial;
            while (true)
            {
                yield return current;
                current = next();
            }
        }

        public static IEnumerable<T> GenerateFrom<T>(this T initial, Func<T, T> next)
        {
            var current = initial;
            while (true)
            {
                yield return current;
                current = next(current);
            }
        }
    }
}