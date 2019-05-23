namespace hw5
{
    class Guest
    {
        //当前最大的id号，用户从200001开始编号
        private static uint idGenerator = 200000;
        //属性Id、Name，都只可读不可写
        public uint Id { get; }
        public string Name { get; }
        //构造函数
        public Guest(string name)
        {
            this.Name = name;
            idGenerator++;
            this.Id = idGenerator;
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