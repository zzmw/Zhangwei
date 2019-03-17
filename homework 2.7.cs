using System;
public class ArrayProgram1
{
    public static void Main()
    {
        Console.WriteLine("给长度为10的数组赋初值：\n");
        int[] par = new int[10];
        for (int i = 0; i < 10; i++)
        {
            string s = Console.ReadLine();
            par[i] = int.Parse(s);
        }
        int min = par[0], max = par[0], sum = 0, ave = 0;
        for (int i = 0; i < par.Length; i++)
        {
            if (min > par[i])
                min = par[i];
            if (max < par[i])
                max = par[i];
            sum = sum + par[i];
        }
        ave = sum / par.Length;
        Console.WriteLine("最小数：" + min);
        Console.WriteLine("最大数：" + max);
        Console.WriteLine("平均数：" + ave);
        Console.WriteLine("和：" + sum);
    }
}