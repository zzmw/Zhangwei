namespace order
{
    public class Item{
        public long Id {get;set;}
        public string Name{get;set;}
        public string Good{get;set;}
        public double Price{get;set;}

        public Item(){

        }

        public Item(long id,string name,string good,double price){
            Id=id;
            Name=name;
            Good=good;
            Price=price;
        }
    }
}