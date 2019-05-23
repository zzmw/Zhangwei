using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderServiceLib;

namespace OrderService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //TestLib();

        }

        private static void TestLib()
        {
            Good apple = new Good(100001, "Apple", 1);
            Good banana = new Good(100002, "Banana", 2);
            Good catFood = new Good(100003, "Cat Food", 3);

            Console.WriteLine("商品");
            Console.WriteLine(apple.ToString());
            Console.WriteLine(banana.ToString());
            Console.WriteLine(catFood.ToString());
            Console.WriteLine("");

            Guest aaron = new Guest(200001, "Aaron");
            Guest billy = new Guest(200002, "Billy");
            Guest catherine = new Guest(200003, "Catherine");

            Console.WriteLine("用户");
            Console.WriteLine(aaron);
            Console.WriteLine(billy);
            Console.WriteLine(catherine);
            Console.WriteLine("");

            Order order1 = new Order(300001, "aaron");
            Order order2 = new Order(300002, "billy");
            Order order3 = new Order(300003, "catherine");


            order1.AddItem("apple", 1, 1, "apple*1");
            order1.AddItem("banana", 2, 2);
            order2.AddItem("catFood", 3, 1);


            OrderServiceLib.OrderService service = new OrderServiceLib.OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
            // 用deserialize取代原本的addorder


            Console.WriteLine("订单数据库");
            service.Display();
            Console.WriteLine("");
            //方法用Linq语言编写
            Console.WriteLine("通过orderid:" + 300001 + " 查找订单");
            service.SearchOrderById(300001).ForEach(o => Console.WriteLine(o));
            Console.WriteLine("");
            //方法用Linq语言编写
            Console.WriteLine("通过username:" + billy.Name + " 查找订单");
            service.SearchOrderByUsername(billy.Name).ForEach(o => Console.WriteLine(o));
            Console.WriteLine("");

            Console.WriteLine("根据订单价格排列");
            service.orderDatabase.Sort(
                (Order a, Order b) => { return (int)(a.Price - b.Price); }
                );
            service.Display();
            Console.WriteLine("");

            Console.WriteLine("根据订单号排列");
            service.orderDatabase.Sort();
            service.Display();
            Console.WriteLine("");

            //service.Export("data.xml");
        }
    }
}
