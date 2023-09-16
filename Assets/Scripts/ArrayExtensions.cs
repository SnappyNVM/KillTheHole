using System;

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
}
