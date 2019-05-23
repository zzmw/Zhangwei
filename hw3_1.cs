using System;

namespace facade_pattern
{
    abstract class Drink{
        abstract public void GiveIntro();
        abstract public void ProvideDrink(int volume);
    }

    class Tea: Drink{
        private String name="tea";
        private String intro="Tea is a kind of beverage from the Orient.";
        override public void GiveIntro(){
            Console.WriteLine(intro);
        }
        override public void ProvideDrink(int volume)
        {   
            Console.WriteLine($"Here you are. This is a {volume.ToString()}ml cup of {name}.");
        }
        

    }
    
    class Coffee: Drink{
        private String name="coffee";
        private String intro="Coffee can help you stay awake.";
        override public void GiveIntro()
        {
            Console.WriteLine(intro);
        }
        override public void ProvideDrink(int volume)
        {
            Console.WriteLine($"Here you are. This is a {volume.ToString()}ml bottle of {name}.");
        }

    }

    class Milk: Drink{
        private String name="milk";
        private String intro="Milk is abundant in protein.";
        override public void GiveIntro()
        {
            Console.WriteLine(intro);
        }
        override public void ProvideDrink(int volume)
        {
            Console.WriteLine($"Here you are. This is a {volume.ToString()}ml bottle of {name}.");
        }

    }

    class OrangeJuice: Drink{
        private String name="orange juice";
        private String intro="Orange is abundant in Vitamin C.";
        override public void GiveIntro()
        {
            Console.WriteLine(intro);
        }
        override public void ProvideDrink(int volume)
        {
            Console.WriteLine($"Here you are. This is a {volume.ToString()}ml bottle of {name}.");
        }

    }


    class Facade{
        Tea tea=new Tea();
        Coffee coffee=new Coffee();
        Milk milk=new Milk();
        OrangeJuice orangeJuice=new OrangeJuice();

        public void AskForInformation(String arg){
            if(arg.ToLower()=="tea"){
                tea.GiveIntro();
            }else if(arg.ToLower()=="coffee"){
                coffee.GiveIntro();
            }else if(arg.ToLower()=="milk"){
                milk.GiveIntro();
            }else if(arg.ToLower()=="orange juice"){
                orangeJuice.GiveIntro();
            }else{
                Console.WriteLine($"There is no {arg} you requested.");
            }

        }

        public void AskForDrink(String arg, int volume){
            if (arg.ToLower() == "tea"){
                tea.ProvideDrink(volume);
            }else if (arg.ToLower() == "coffee"){
                coffee.ProvideDrink(volume);
            }else if (arg.ToLower() == "milk"){
                milk.ProvideDrink(volume);
            }else if (arg.ToLower() == "orange juice"){
                orangeJuice.ProvideDrink(volume);
            }else{
                Console.WriteLine($"There is no {arg} you requested.");
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade=new Facade();
            int input=3;
            int vol=0;
            String drink=null;
            

            Console.WriteLine("We have 4 types of drink: tea, coffee, milk and orange juice.");
            Console.WriteLine("1. Give an introduction of a specific kind of drink.");
            Console.WriteLine("2. Request a specific volume of a specific drink.");
            Console.WriteLine("3. Quit.\n");
            Console.WriteLine("Please input a number");
            try{
                input=Convert.ToInt32(Console.ReadLine());
            }catch(System.FormatException e){
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            while(input!=3){
                switch(input){
                    case 1: 
                        Console.WriteLine("Which drink's introduction do you want?");
                        drink=Console.ReadLine();
                        facade.AskForInformation(drink);
                        break;
                    case 2:
                        Console.WriteLine("Which type of drink do you want?");
                        drink = Console.ReadLine();
                        Console.WriteLine("How much do you want? (ml)");
                        try{  
                            vol = Convert.ToInt32(Console.ReadLine());
                        }catch(System.FormatException e){
                            Console.WriteLine(e.Message);
                        }
                        facade.AskForDrink(drink, vol);
                        break;
                }
                Console.WriteLine("\nPlease input a number");
                input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }
            Console.WriteLine("Program closed.");

            


        }
    }
}
