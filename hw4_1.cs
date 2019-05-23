using System;
using System.Threading;

namespace hw4_1{

    //定义事件消息类型
    public class TimerEventArgs: EventArgs{
        private String user = "(DEFAULT)UNKNOWN";
        private String source = "(DEFAULT)UNKONWN";

        public void AcknowledgeUser(String user){
            this.user = user;
        }
        public void AcknowledgeSource(String source){
            this.source = source;
        }
        public String GetUser(){
            return this.user;
        }
        public String GetSource(){
            return this.source;
        }
    }

    //定义委托类型
    public delegate void TimerEventHandler(object self, TimerEventArgs e);

    //定义事件源
    public class Clock{
        public event TimerEventHandler timerEventHandler=null;
        private String clockName;

        public Clock(String clockName){
            this.clockName = clockName;
        }

        public void StartTimer(int time, String user){
            for(int i=time; i>0; i--){
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            TimerEventArgs e = new TimerEventArgs();
            e.AcknowledgeSource(this.clockName);
            e.AcknowledgeUser(user);
            timerEventHandler(this, e);
        }
        
    }


    class Program{
        static void Main(string[] args){
            Clock clockA = new Clock("Clock A");
            //注册事件
            clockA.timerEventHandler += Program.Message;
            clockA.StartTimer(5, "Felix");
        }
        //定义事件处理方法
        public static void Message(object sender, TimerEventArgs e){
            Console.WriteLine(e.GetUser()+"'s "+e.GetSource()+" says: time is up!");
        }
    }
}
