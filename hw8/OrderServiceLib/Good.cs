using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServiceLib
{
    [Serializable]
    public class Good
    {
        
        //属性Price、Id、Name、Detail
        public double Price { get; set; }
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }

        //构造方法
        public Good()
        {

        }
        public Good(uint id, string name, double price, string detail="UNSET")
        {
            this.Name = name;
            this.Price = price;
            this.Id = id;
            this.Detail = detail;
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
        public override string ToString()
        {
            return $"ID: {this.Id}  Name: {this.Name}  Price: {this.Price}  Detail: {this.Detail}";
        }
    }
}


