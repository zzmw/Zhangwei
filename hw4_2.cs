// 写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单功能。
// （按照订单号、商品名称、客户等字段进行查询）
// 在订单删除、修改失败时，能够产生异常并显示给用户错误信息。


using System;
using System.Collections.Generic;

namespace hw4_2
{

    class Record
    {
        public int code;
        public String name;
        public String client;
        public Record(int num, String name, String client)
        {
            this.code = num;
            this.name = name;
            this.client = client;
        }
    }
    

    class Database : List<Record>
    {
        private string dbName;
        
        public Database(String dbName) : base()
        {
            this.dbName = dbName;
        }
        
        public void DisplayDB()
        {
            Console.WriteLine(this.dbName.ToUpper());
            Console.WriteLine("code\tname\t\tclient");
            Console.WriteLine("----------------------------------------");
            this.ForEach(r => Console.WriteLine($"{r.code}\t{r.name}\t\t{r.client}"));
            Console.WriteLine("\n");
        }

    }

    class DatabaseOperation
    {
        public static void CreateRecord(Database db)
        {
            int code = 0;
            String name, client;
            Console.WriteLine("请输入订单号");
            try
            {
                code = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                throw e;
            }
            Console.WriteLine("请输入商品名称");
            name = Console.ReadLine();
            Console.WriteLine("请输入客户名字");
            client = Console.ReadLine();

            db.Add(new Record(code, name, client));

            Console.WriteLine("插入记录成功！\n");
        }
        
        public static void DeleteRecord(Database db)
        {
            int code = 0;
            Console.WriteLine("请输入订单号");
            try
            {
                code = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                throw e;
            }
            Boolean flag = false;
            for (int i = 0; i < db.Count; i++)
            {
                if (db[i].code == code)
                {
                    db.RemoveAt(i);
                    flag = true;
                    Console.WriteLine("成功删除\n");
                }
            }
            if (flag == false)
            {
                Console.WriteLine("订单不存在\n");
            }
        }
        
        public static void SearchRecordByCode(Database db)
        {
            int code = 0;
            Console.WriteLine("请输入订单号");
            try
            {
                code = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                throw e;
            }
            bool flag = false;
            db.ForEach(r =>
            {
                if (r.code == code)
                {
                    if (flag == false)
                    {
                        Console.WriteLine("code\tname\t\tclient");
                        Console.WriteLine("----------------------------------------");
                    }
                    Console.WriteLine($"{r.code}\t{r.name}\t\t{r.client}");
                    flag = true;
                }

            });
            if (flag == false)
            {
                Console.WriteLine("No record matches the query!\n");
            }
            else
            {
                Console.WriteLine("");
            }
        }

        public static void SearchRecordByString(Database db)
        {
            Console.WriteLine("请输入商品名称或客户名字");
            String str = Console.ReadLine();
            bool flag = false;
            db.ForEach(r =>
            {
                if (r.client == str || r.name == str)
                {
                    if (flag == false)
                    {
                        Console.WriteLine("code\tname\t\tclient");
                        Console.WriteLine("----------------------------------------");
                    }
                    Console.WriteLine($"{r.code}\t{r.name}\t\t{r.client}");
                    flag = true;
                }
            });
            if (flag == false)
            {
                Console.WriteLine("No record matches the query!\n");
            }
            else
            {
                Console.WriteLine("");
            }
        }

        public static void AlterRecord(Database db)
        {
            int code = 0;
            Console.WriteLine("请输入订单号");
            try
            {
                code = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + " Program terminated.");
            }
            Console.WriteLine("修改商品名称请输入1，修改客户请输入2");
            int input = 0;
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            if (input == 1)
            {
                Console.WriteLine("请输入商品名称");
                string name = Console.ReadLine();
                db.ForEach(r =>
                {
                    if (r.code == code)
                        r.name = name;
                });
                Console.WriteLine("修改成功！\n");
            }
            else if (input == 2)
            {
                Console.WriteLine("请输入客户名字");
                string client = Console.ReadLine();
                db.ForEach(r =>
                {
                    if (r.code == code)
                        r.client = client;
                });
                Console.WriteLine("修改成功！\n");
            }
            else
            {
                Console.WriteLine("invalid input!\n");
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database("Database");
            Console.WriteLine("当前已经为您建立了一个数据库\n");
            while (true)
            {
                Console.WriteLine("请输入序号以执行相应操作\n1.增加订单\n2.删除订单\n3.查询订单(按照订单号)\n4.查询订单(按照商品名称或客户)\n5.修改订单\n6.展示数据库\n7.连续创建3个示例\n-1.退出\n");
                int input = 0;
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message + " Program terminated.");
                    return;
                }
                try
                {
                    switch (input)
                    {
                        case -1:
                            Console.WriteLine("Program terminated.");
                            return;
                        case 1:
                            Console.WriteLine("");
                            DatabaseOperation.CreateRecord(db);

                            break;
                        case 2:
                            Console.WriteLine("");

                            DatabaseOperation.DeleteRecord(db);

                            break;
                        case 3:
                            Console.WriteLine("");
                            DatabaseOperation.SearchRecordByCode(db);
                            break;
                        case 4:
                            Console.WriteLine("");
                            DatabaseOperation.SearchRecordByString(db);
                            break;
                        case 5:
                            Console.WriteLine("");
                            DatabaseOperation.AlterRecord(db);
                            break;
                        case 6:
                            Console.WriteLine("");
                            db.DisplayDB();
                            break;
                        case 7:
                            Console.WriteLine("");
                            db.Add(new Record(1, "apple", "a"));
                            db.Add(new Record(2, "banana", "apple"));
                            db.Add(new Record(3, "cat", "a"));
                            break;
                        default:
                            Console.WriteLine("invalid number.\n");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " Program terminated.");
                    return;
                }
            }
        }
    }
}
