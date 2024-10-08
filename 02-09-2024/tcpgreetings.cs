using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tcpgreeting
{
    public class SimpleServer
    {
        public void service(string ipAddr = "127.0.0.1", int port = 13000)
        {
            TcpListener server = new TcpListener(IPAddress.Parse(ipAddr), port);// Create a TCP listener
            server.Start();// Start listening for client requests
            Console.WriteLine($"Server is listening on port {port}...");
            byte[] bytes = new byte[1024];// Buffer for reading data
            string personName = null;//request param
            TcpClient client = server.AcceptTcpClient();// Enter the listening loop
            Console.WriteLine("Connected!");
            NetworkStream stream = client.GetStream();
            // Loop to receive all the data sent by the client
            //while (true)
            //{
            int i = stream.Read(bytes, 0, bytes.Length);
            personName = Encoding.ASCII.GetString(bytes, 0, i).Trim();
            Console.WriteLine($"person name: {personName}");//INFO
                                                            //if (data.ToLower() == "end"){ break;}
                                                            //}
                                                            // Send back a response
            string greetName = $"Hello {personName}";
            byte[] msg = Encoding.ASCII.GetBytes(greetName);
            stream.Write(msg, 0, msg.Length);
            Console.WriteLine($"greetings:{greetName}, sent.");//DEBUG
            client.Close();// Shutdown and end connection
            server.Stop();// Stop server 
        }
    }
    public class SimpleClient
    {
        public void service(string serverAddress = "127.0.0.1", int port = 13000)
        {
            TcpClient client = new TcpClient(serverAddress, port);
            NetworkStream stream = client.GetStream();
            //while (true)
            //{
            Console.Write("Person Name:");
            string personName = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(personName);
            stream.Write(data, 0, data.Length);
            //}
            // Buffer to store the response bytes
            byte[] responseBytes = new byte[1024];
            // Read the server's response
            int bytes = stream.Read(responseBytes, 0, responseBytes.Length);
            string greetName = Encoding.ASCII.GetString(responseBytes, 0, bytes);
            Console.WriteLine($"greetings: {greetName}");
            stream.Close();
            client.Close();
        }
    }
    internal class Program
    {
        static void Main()
        {
            Console.Write("Option[1-Run Server, 2-Run Client]:");
            int option = int.Parse(Console.ReadLine());
            int port = 13000;//change it 
            string serverAddress = "127.0.0.1";
            switch (option)
            {
                case 1:
                    Console.WriteLine("Server Service to get started...");
                    SimpleServer server = new SimpleServer();
                    server.service(port: port);
                    break;
                case 2:
                    Console.WriteLine("Client Service to get started...");
                    SimpleClient client = new SimpleClient();
                    client.service(serverAddress: serverAddress, port: port);
                    break;
            }
            Console.WriteLine("\nPress Enter to exit...");
            Console.Read();
        }
    }
}

//op

//Option[1 - Run Server, 2 - Run Client]:1
//Server Service to get started...
//Server is listening on port 13000...
//Connected!
//person name: Dijol
//greetings:Hello Dijol, sent.

//Press Enter to exit...

//Option[1-Run Server, 2-Run Client]:2
//Client Service to get started...
//Person Name:Dijol
//greetings: Hello Dijol

//Press Enter to exit...Option[1-Run Server, 2-Run Client]:2
//Client Service to get started...
//Person Name:Dijol
//greetings: Hello Dijol

//Press Enter to exit...
