using System;

namespace hw5
{
    [Serializable]
    public class Good
    {
        //当前最大的id号，商品从100001开始编号

        private static uint idGenerator = 100000;
        //属性Price、Id、Name、Detail。其中前三个一旦确认，不能更改；最后一个可以更改。
        public double Price { get; set; }
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }

        //构造方法
        public Good()
        {

        }


        public Good(string name, double price)
        {
            this.Name = name;
            this.Price = price;
            idGenerator++;
            this.Id = idGenerator;
            this.Detail = "UNSET";

        }

        public override bool Equals(object obj)
        {
            if (obj is Good)
            {
                Good good = (Good)obj;
                return this.Id == good.Id;
            }
            return false;
        }

        //调用ToString的时候输出当前商品的所有信息
        public override string ToString()
        {
            return $"ID: {this.Id}  Name: {this.Name}  Price: {this.Price}  Detail: {this.Detail}";
        }
    }
}
