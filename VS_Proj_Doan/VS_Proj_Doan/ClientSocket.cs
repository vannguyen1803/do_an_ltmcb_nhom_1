using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VS_Proj_Doan
{
    public class ClientSocket
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread listenthread;
        public void connect(string ip, int port)
        {
            try
            {
                client = new TcpClient();
                client.Connect(ip, port);
                stream = client.GetStream();
                MessageBox.Show($"connected to {ip}:{port}");
                listenthread = new Thread(ListenServer);
                listenthread.IsBackground = true;
                listenthread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("connect fail", ex.Message);

            }
        }
        public void send(string message)
        {
            if (stream == null || !client.Connected)
            {
                MessageBox.Show("not connected to server");
                return;
            }
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }
        private void ListenServer()
        {
            byte[] buffer = new byte[1024];
            int bytes;
            try
            {
                while ((bytes = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string response = Encoding.UTF8.GetString(buffer, 0, bytes);
                    MessageBox.Show($"form server{response}");
                }
            }
            catch
            {
                MessageBox.Show("disconnected from server");
            }
        }
        public void dsiconnected()
        {
            try
            {
                stream?.Close();
                client?.Close();
            }
            catch
            {

            }
        }
    }
}
