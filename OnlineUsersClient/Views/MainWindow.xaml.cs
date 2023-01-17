using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OnlineUsersClient.Helper;
using OnlineUsersClient.ViewModels;

namespace OnlineUsersClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AppViewModel();
        }

        //private void ConnectBtn_Click(object sender, RoutedEventArgs e)
        //{

        //    var client = new TcpClient();
        //    var ip = IPAddress.Parse(IPHelper.GetLocalIpAddress());
        //    var port = 80;
        //    var ep = new IPEndPoint(ip, port);

        //    try
        //    {
        //        client.Connect(ep);
        //        if (client.Connected)
        //        {
        //            var writer = Task.Run(() =>
        //            {
        //                var text = Name;
        //                var stream = client.GetStream();
        //                var bw = new BinaryWriter(stream);
        //                bw.Write(text);

        //            });

        //            //var reader = Task.Run(() =>
        //            //{
        //            //    while (true)
        //            //    {
        //            //        //var stream = client.GetStream();
        //            //        //var br = new BinaryReader(stream);
        //            //        //MessageBox.Show($"FROM Server : {br.ReadString()}");
        //            //    }
        //            //});
        //            //Task.WaitAll();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}
    }
}
