using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace hw7
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Good apple = new Good("Apple", 1);
            Good banana = new Good("Banana", 2);
            Good catFood = new Good("Cat Food", 3);

            Console.WriteLine("商品");
            Console.WriteLine(apple.Name);
            Console.WriteLine(banana.Name);
            Console.WriteLine(catFood.Name);
            Console.WriteLine("");

            Guest aaron = new Guest("Aaron");
            Guest billy = new Guest("Billy");
            Guest catherine = new Guest("Catherine");

            Console.WriteLine("用户");
            Console.WriteLine(aaron);
            Console.WriteLine(billy);
            Console.WriteLine(catherine);
            Console.WriteLine("");

            Order order1 = new Order(aaron);
            Order order2 = new Order(billy);
            Order order3 = new Order(catherine);


            order1.AddItem(apple, "None", 1);
            order1.AddItem(banana, "fresh!", 2);
            order2.AddItem(catFood, "My cat loves it!", 3);


            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
            //用deserialize取代原本的addorder
            //service.Import("data.xml");

            Console.WriteLine("订单数据库");
            service.Display();
            Console.WriteLine("");
            //方法用Linq语言编写
            Console.WriteLine("通过orderid:" + 300001 + " 查找订单");
            service.SearchOrderById(300001);
            Console.WriteLine("");
            
            //方法用Linq语言编写
            Console.WriteLine("通过username:" + billy.Name + " 查找订单");
            service.SearchOrderByUsername(billy.Name);
            Console.WriteLine("");

            //service.DeleteOrderById(3333);
            //...可以检验查询异常、删除异常、添加异常等

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

            service.Export("data.xml");
            
           
            
        }
    }
}
