using System;
using System.Diagnostics;

namespace Altkom.Shop.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Sender sender = new Sender();

            MotorolaRadio motorolaRadio = new MotorolaRadio();
            motorolaRadio.Log += sender.SendFacebook;
            motorolaRadio.Log += sender.SendEmail;
            motorolaRadio.Log += content => Console.WriteLine($"Send sms {content}");

            // motorolaRadio.Log += sender.SendInstragram;

            Delegate[] delegates = motorolaRadio.Log.GetInvocationList();

            motorolaRadio.Call(255);
           

            sender.Send = sender.SendConsole;
            sender.Send += sender.SendEmail;
            sender.Send += sender.SendFacebook;

            sender.Send?.Invoke("Hello World!");

            sender.Send -= sender.SendFacebook;

            if (sender.Send != null)
                sender.Send("Hello WPF!");

            sender = null;
            
            if (sender.Send!=null)
                sender.Send("Hello .NET Core!");

            //sender.SendConsole("Hello World!");
            //sender.SendEmail("Hello World!");
            //sender.SendFacebook("Hello World!");            
            //sender.SendTweeter("Hello World!");

        }
    }

    public class MotorolaRadio
    {
        public delegate void LogDelegate(string content);

        public LogDelegate Log { get; set; }

        public void Call(byte channel)
        {
            Log?.Invoke($"LOG: selected {channel}");

            // ..

            Log?.Invoke($"LOG: missing call");

        }

    }

    class Sender
    {
        public delegate void SendDelegate (string message);

        public SendDelegate Send;

        public void SendConsole(string message)
        {
            Console.WriteLine(message);
        }

        public void SendEmail(string message)
        {
            Console.WriteLine($"Send email {message}");
        }

        public void SendFacebook(string post)
        {
            Console.WriteLine($"Send post {post}");
        }

        public void SendTweeter(string tweet)
        {
            Console.WriteLine($"Send tweet {tweet}");
        }

        public void SendInstragram(byte[] picture)
        {

        }

    }
}
