using System;

public class PortableCinema
{
    static int n, e;
    static int[] p;
    static double[] a;

    // Функция, проверяющая, можно ли поддерживать кинотеатр в работоспособном состоянии в течение заданного времени
    static bool CanMaintain(double t)
    {
        double[] charge = new double[n];
        for (int i = 0; i < n; i++)
        {
            charge[i] = a[i] - p[i] * t;
            if (charge[i] < 0) return false;
        }
        Array.Sort(charge);
        double remaining = e;
        for (int i = n - 1; i >= 0; i--)
        {
            while (charge[i] > 0 && remaining > 0)
            {
                double delta = Math.Min(remaining / 2, charge[i]);
                remaining -= delta;
                charge[i] -= delta;
            }
            if (charge[i] > 0) return false;
        }
        return true;
    }

    // Бинарный поиск по времени
    static double BinarySearch(double left, double right)
    {
        while (left < right - 1e-9)
        {
            double mid = (left + right) / 2;
            if (CanMaintain(mid)) left = mid;
            else right = mid;
        }
        return left;
    }

    public static void Main()
    {
        string[] input = Console.ReadLine().Split();
        n = int.Parse(input[0]);
        e = int.Parse(input[1]);
        p = new int[n];
        a = new double[n];
        for (int i = 0; i < n; i++)
        {
            input = Console.ReadLine().Split();
            p[i] = int.Parse(input[0]);
            a[i] = double.Parse(input[1]);
        }
        double result = BinarySearch(0, 1e9);
        if (result >= 1e9) Console.WriteLine("{0:F9}", result);
    }
}
