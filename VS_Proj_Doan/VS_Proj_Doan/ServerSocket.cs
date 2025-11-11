using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VS_Proj_Doan
{
    public class ServerSocket
    {
        private TcpListener server;
        private Thread listenthread;

        public void start(int port)
        {
            try
            {
                server = new TcpListener(System.Net.IPAddress.Any, port);
                server.Start();
                MessageBox.Show($"server is listening on port {port}");
                listenthread = new Thread(WaitClient);
                listenthread.IsBackground = true;
                listenthread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error start server", ex.Message);
            }
        }
        public void WaitClient()
        {
            while (true)
            {


                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    MessageBox.Show("client connected");
                    Thread clientthread = new Thread(() => HandleClient(client));
                    clientthread.IsBackground = true;
                    clientthread.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error acceting client", ex.Message);
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytecount;
            try
            {
                while ((bytecount = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string data = Encoding.UTF8.GetString(buffer, 0, bytecount);
                    MessageBox.Show($"form client: {data}");
                    string response = $"server receive:{data}";
                    byte[] msg = Encoding.UTF8.GetBytes(response);
                    stream.Write(msg, 0, msg.Length);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("client disconnected", ex.Message);
            }
            finally
            {
                client.Close();
            }
        }

    }
}
