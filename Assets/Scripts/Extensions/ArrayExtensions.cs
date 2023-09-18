using System;
using UnityEngine;

public static class ArrayExtensions
{
    public static T[] ConvertToOneDimensional<T>(this T[,] source)
    {
        if (source == null) throw new ArgumentNullException();

        var result = new T[source.GetLength(0) * source.GetLength(1)];
        int index = 0;
        for (int x = 0; x < source.GetLength(0); x++)
            for (int y = 0; y < source.GetLength(1); y++)
            {
                result[index] = source[x, y];
                index++;
            }
        return result;
    }

    public static Tuple<int, int> FoundAnIndexByCoordiates(this Vector3[,] source,  Vector3 value)
    {
        for (int i = 0; i < source.GetLength(0); i++)
            for (int j = 0; j < source.GetLength(1); j++)
                if (source[i, j].x == value.x && source[i, j].z == value.z) return new Tuple<int, int>(i, j);
        throw new ArgumentException($"Cannot find {value} in source");
    }
}
