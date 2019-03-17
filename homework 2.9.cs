using System;
public class SelectPrime
{
    public static void Main()
    {
        int a;
        int[] p = new int[99];
        for (int i=0;i<=98;i++)
        {
            p[i] = i + 2;
        }
        for(int i=0;i<=98;i++)
        {
            if (p[i] != 0)
            {
                a = p[i];
                for (int j = 0; j <= 98; j++)
                {
                    if (p[j] % a == 0)
                        p[j] = 0;
                }
            }
            else
                break;
        }
        for(int t=0;t<=98;t++)
        {
            if (p[t] != 0)
                Console.WriteLine(p[t] + " ");
        }
    }

}