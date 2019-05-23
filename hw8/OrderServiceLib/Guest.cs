using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderServiceLib
{
    [Serializable]
    public class Guest
    {

        //属性Id、Name
        public uint Id { get; set; }
        public string Name { get; set; }
        //构造函数
        public Guest()
        {

        }
        public Guest(uint id, string name)
        {
            this.Name = name;
            this.Id = id;
        }

        public override string ToString()
        {
            return $"{this.Id}-{this.Name}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Guest)
            {
                Guest guest = (Guest)obj;
                return guest.Id == this.Id;
            }
            return false;
        }
    }
}
