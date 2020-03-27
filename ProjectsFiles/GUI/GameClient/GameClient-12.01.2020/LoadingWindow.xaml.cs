using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GameBLL.BLL_Classess;
using GameBLL;
using GameBLL.GameComponents;
using GameClient_12._01._2020.AdminServiceReference;
using System.ComponentModel;
using System.Data;

namespace GameClient_12._01._2020
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        private BackgroundWorker backgroundWorker;
        private GameBL game;
        
        public LoadingWindow(GameBL game)
        {
            InitializeComponent();
            this.game = game;
            this.backgroundWorker = new BackgroundWorker();
            this.backgroundWorker.DoWork += bg_DoWork;
            this.backgroundWorker.RunWorkerCompleted += bg_RunWorkerCompleted;
        }

        private void TopPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            using (AdminServiceClient client = new AdminServiceClient())
            {
                DataTable dataTable = client.GetAdminPercentageTable();
                GameConstants.InitializeVariables(dataTable);
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }


    }
}
