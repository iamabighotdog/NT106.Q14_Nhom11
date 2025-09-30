using System.Linq;
using System;
using System.Collections.Generic;
//Bai 1: Calculate BMI
public class Kata1
{
    public static string Bmi(double weight, double height)
    {
        double bmi;
        bmi = weight / (height * height);
        if (bmi <= 18.5) return "Underweight";
        else if (bmi <= 25.0) return "Normal";
        else if (bmi <= 30.0) return "Overweight";
        else return "Obese";
    }
}
//Bai 2: Invert values
namespace Solution
{
    public static class ArraysInversion
    {
        public static int[] InvertValues(int[] input)
        {
            return input.Select(x => -x).ToArray();
        }
    }
}
//Bai 3: MakeUpperCase
public class Kata2
{
    public static string MakeUpperCase(string str)
    {
        return str.ToUpper();
    }

}
//Bai 4: Returning Strings
public static class Kata
{
    public static string Greet(string name)
    {
        return $"Hello, {name} how are you doing today?";
    }
}
//Bai 5: Grasshopper - Personalized Message
public class Kata3
{
    public static string Greet(string name, string owner)
    {
        if (name == owner)
        {
            return "Hello boss";
        }
        return "Hello guest";
    }
}
//Bai 6: You only need one - Beginner. x co trong mang a hay khong?
public class Kata4
{
    public static bool Check(object[] a, object x)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (object.Equals(a[i], x)) return true;
        }
        return false;
    }
}
//Bai 7: Grasshopper - Summation. Tinh tong cac so tu 1 den num

public static class Kata5
{
    public static int summation(int num)
    {
        return num * (num + 1) / 2;
    }
}
//Bai 8: Find Maximum and Minimum Values of a List
public class Kata6
{
    public int Min(int[] list)
    {
        return list.Min();
    }

    public int Max(int[] list)
    {
        return list.Max();
    }
}
//Bai 9: Fake Binary. x[i] < 5 ? 0 : 1
public class Kata7
{
    public static string FakeBin(string x)
    {
        return string.Concat(x.Select(a => a < '5' ? "0" : "1"));
    }
}
//Bai 10: Total amount of points
public static class Kata8
{
    public static int TotalPoints(string[] games)
    {
        return games.Sum(g => {
            var parts = g.Split(':');
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            return x > y ? 3 : x == y ? 1 : 0;
        });
    }
}
//Bai 11: Convert a String to a Number
public class Kata9
{
    public static int StringToNumber(String str)
{
    int x = int.Parse(str);
    return x;
}
}
//Bai 12: Remove String Spaces
namespace Solution
{
    public static class SpacesRemover
    {
        public static string NoSpace(string input)
        {
            return input.Replace(" ", "");
        }
    }
}
//Bai 13: Thinkful - Logic Drills: Traffic light
public class Kata10
{
    public static string UpdateLight(string current)
    {
        if (current == "green") return "yellow";
        else if (current == "yellow") return "red";
        else return "green";
    }
}
//Bai 14: Reversed sequence. Build a function that returns an array of integers from n to 1 where n>0.
public static class Kata11
{
    public static int[] ReverseSeq(int n)
    {
        int[] result = new int[n];
        for (int i = 0; i < n; i++)
        {
            result[i] = n - i;
        }
        return result;
    }
}
//Bai 15: Even or Odd
namespace Solution
{
    public class SolutionClass
    {
        public static string EvenOrOdd(int number)
        {
            return number % 2 == 0 ? "Even" : "Odd";
        }
    }
}
//Bai 16: Sum Arrays
public class Kata12
{
    public static double SumArray(double[] array)
    {
        return array.Sum();
    }
}
//Bai 17: Ones and Zeros. Chuyen mang nhi phan thanh so thap phan
namespace Solution
{
    class Kata
    {
        public static int binaryArrayToNumber(int[] BinaryArray)
        {
            int result = 0;
            foreach (int bit in BinaryArray)
            {
                result = (result << 1) | bit;
            }
            return result;
        }
    }
}
//Bai 18: Function 1 - hello world
public static class Kata13
{
    public static string greet()
    {
        return "hello world!";
    }
}
//Bai 19: Count by X
public static class Kata14
{
    public static int[] CountBy(int x, int n)
    {
        int[] z = new int[n];
        z[0] = x;
        for (int i = 1; i < n; i++)
        {
            z[i] = z[i - 1] + x;
        }
        return z;
    }
}
//Bai 20: You're a square! Tim so chinh phuong.
public class Kata15
{
    public static bool IsSquare(int n)
    {
        if (n < 0) return false;

        int root = (int)Math.Sqrt(n);
        return root * root == n;
    }
}

