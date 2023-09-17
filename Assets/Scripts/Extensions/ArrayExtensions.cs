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

    public static Tuple<int, int> FoundAnIndexByValue<T>(this T[,] source, T value)
    {
        for (int i = 0; i < source.GetLength(0); i++)
            for (int j = 0; j < source.GetLength(1); j++)
                if (source[i, j].Equals(value)) return new Tuple<int, int>(i, j);
        return new Tuple<int, int>(0, 0);
    }
}
