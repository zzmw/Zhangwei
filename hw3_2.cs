/*
本程序实现的是简单工厂模式
问题描述：假设某唱片商店要进货album，按照歌手进货，但是进货的歌手未知，可能在未来改变，尝试设计类来实现这一个功能。
*/
using System;

namespace simple_factory_pattern
{

    //定义一个具体商品的父类——抽象类
    abstract class Singer{
        public int costPerAlbum;
        public String name;
        public void PurchaseCost(int num)
        {
            Console.WriteLine($"The cost of purchasing {this.name}'s albums is {num * this.costPerAlbum}.");
        }
    }

    class TaylorSwift: Singer{
        public TaylorSwift(){
            this.costPerAlbum=10;
            this.name="Taylor Swift";
            Console.WriteLine($"You are going to purchase {this.name}'s albums.");
        }
        
    }

    class EdSheeran: Singer{
        public EdSheeran()
        {
            this.costPerAlbum = 9;
            this.name = "Ed Sheeran";
            Console.WriteLine($"You are going to purchase {this.name}'s albums.");
        }
        
    }


    class Maroon5: Singer{
        public Maroon5()
        {
            this.costPerAlbum = 8;
            this.name = "Maroon 5";
            Console.WriteLine($"You are going to purchase {this.name}'s albums.");
        }
        
    }

    class CdShopPurchase{
        public static Singer PurchaseAlbum(String arg){
            Singer singer=null;
            if(arg.ToLower()=="taylor swift"){
                singer=new TaylorSwift();
            }
            else if(arg.ToLower()== "ed sheeran"){
                singer = new EdSheeran();
            }
            else if(arg.ToLower()=="maroon 5"){
                singer = new Maroon5();
            }
            else{
                Console.WriteLine("We don't have the album you requested.");
            }
            return singer;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入你要选购的歌手名称");
            String arg=Console.ReadLine();
            Console.WriteLine("请输入你要选购的专辑数量");
            int num=0;
            try{
                num = Convert.ToInt32(Console.ReadLine());
            }catch(System.FormatException e){
                Console.WriteLine(e.Message);
            }
            Singer singer=CdShopPurchase.PurchaseAlbum(arg);
            if(singer!=null)
            {
                singer.PurchaseCost(num);
            }

        }
    }
}
