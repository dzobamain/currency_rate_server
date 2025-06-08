using System;
using System.Net.Sockets;
using System.Text;

class CurrencyClient
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Enter two currencies (e.g. USD/EUR) or 'q' to quit: ");
            string request = Console.ReadLine();

            if (request.ToLower() == "q") break;

            TcpClient client = new TcpClient("127.0.0.1", 5050);
            NetworkStream stream = client.GetStream();

            byte[] data = Encoding.UTF8.GetBytes(request);
            stream.Write(data, 0, data.Length);

            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine($"Response: {response}");
            client.Close();
        }
    }
}
