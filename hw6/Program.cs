// 写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单功能。
// （按照订单号、商品名称、客户等字段进行查询）
// 在订单删除、修改失败时，能够产生异常并显示给用户错误信息。
// 提示：需要写order、orderdetails、orderservice这几个类，订单数据可以保存在orderservice中一个list中
//
// 为order和orderdetails重写equals方法，确保订单不重复，订单明细不重复
// 为订单、订单明细、客户、货物等类添加tostring方法，用来显示订单信息
// 为订单实现icomparable接口，实现按照订单号给订单排序
// 使用lambda表达式实现订单按照订单总金额排序的功能
//
// 第六次作业:
// 1、使用LINQ语言实现OrderService中的查询算法。
// 2、在OrderService中添加一个Export方法，可以将所有的订单序列化为XML文件；添加一个Import方法可以从XML文件中载入订单。
using System;
using System.Linq;

namespace hw5
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
            // service.AddOrder(order1);
            // service.AddOrder(order2);
            // service.AddOrder(order3);
            // 用deserialize取代原本的addorder
            service.Import("data.xml");

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
