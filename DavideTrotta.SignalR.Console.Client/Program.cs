using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace DavideTrotta.SignalR.Console.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IHubProxy _hub;
            string url = @"http://localhost:6969/";
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("customHub");
            connection.Start().Wait();

            _hub.Invoke("Send", "test", "response");
            _hub.Invoke("Send", "test2", "response5");
            _hub.Invoke("Send", "test3", "response4");
            _hub.Invoke("Send", "test4", "response3");
            _hub.Invoke("Send", "test5", "response2");

            _hub.On("addMessage", (string x,string y) => System.Console.WriteLine(string.Format("{0} - {1}"),x,y));

            System.Console.ReadLine();
        }

    }
}
