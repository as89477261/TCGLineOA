using System;
using System.Threading;

public static class RandomManager
{
    private static int seed;
    private static readonly Random _random = new Random();
    private static readonly ThreadLocal<Random> threadLocal = new ThreadLocal<Random>
        (() => new Random(Interlocked.Increment(ref seed)));

    static RandomManager()
    {
        seed = Environment.TickCount;
    }
    public static int RandomNumber(int min, int max)
    {
        return _random.Next(min, max);
    }
    public static Random Instance => threadLocal.Value;
}