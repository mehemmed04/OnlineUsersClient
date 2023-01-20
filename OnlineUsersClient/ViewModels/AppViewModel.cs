using OnlineUsersClient.Commands;
using OnlineUsersClient.Helper;
using OnlineUsersClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineUsersClient.ViewModels
{
    public class AppViewModel:BaseViewModel
    {
        public RelayCommand ConnectCommand { get; set; }
        public RelayCommand SendMessageCommand { get; set; }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public AppViewModel()
        {
            LoadCommands(); 
        }

        public TcpClient client { get; set; }

        private void LoadCommands()
        {
            ConnectCommand = new RelayCommand((o) =>
            {
                client = new TcpClient();
                var ip = IPAddress.Parse(IPHelper.GetLocalIpAddress());
                var port = 80;
                var ep = new IPEndPoint(ip, port);

                try
                {
                    client.Connect(ep);
                    if (client.Connected)
                    {
                        var writer = Task.Run(() =>
                        {
                            Message msg = new Message
                            {
                                Client = client,
                                 Owner =Name,
                                  Content = "Connected"
                            };
                            var messaage = JsonHelper.GetJsonStringOfClass(msg);
                            byte[] data = Encoding.ASCII.GetBytes(messaage);
                            NetworkStream stream = client.GetStream();
                            stream.Write(data, 0, data.Length);
                        });
                        MessageBox.Show("Connected");
                        //var reader = Task.Run(() =>
                        //{
                        //    while (true)
                        //    {
                        //        //var stream = client.GetStream();
                        //        //var br = new BinaryReader(stream);
                        //        //MessageBox.Show($"FROM Server : {br.ReadString()}");
                        //    }
                        //});
                        //Task.WaitAll();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });


            SendMessageCommand = new RelayCommand((o) =>
            {
                var ip = IPAddress.Parse(IPHelper.GetLocalIpAddress());
                var port = 80;
                var ep = new IPEndPoint(ip, port);

                try
                {
                    if (client.Connected)
                    {
                        var writer = Task.Run(() =>
                        {
                            Message msg = new Message
                            {
                                Client = client,
                                Owner = Name,
                                Content = Message
                            };
                            var messaage = JsonHelper.GetJsonStringOfClass(msg);
                            byte[] data = Encoding.ASCII.GetBytes(messaage);
                            NetworkStream stream = client.GetStream();
                            stream.Write(data, 0, data.Length);
                            MessageBox.Show("Sended");
                        });

                        //var reader = Task.Run(() =>
                        //{
                        //    while (true)
                        //    {
                        //        //var stream = client.GetStream();
                        //        //var br = new BinaryReader(stream);
                        //        //MessageBox.Show($"FROM Server : {br.ReadString()}");
                        //    }
                        //});
                        //Task.WaitAll();
                    }
                    else
                    {
                        MessageBox.Show("You are not connected");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });

        }
    }
}
