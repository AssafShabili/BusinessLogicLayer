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

        private bool error = false;
        
        public LoadingWindow()
        {
            InitializeComponent();
            this.game = new GameBL(1);
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
            if(!this.error)
            {
                GameWindow gameWindow = new GameWindow(this.game);
                ProgressBarLoading.Value += 10;
                gameWindow.Show();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (AdminServiceClient client = new AdminServiceClient())
                {
                    DataTable dataTable = client.GetAdminPercentageTable();
                    this.Dispatcher.Invoke(() =>
                    {
                        ProgressBarLoading.Value += 60;
                    });
                    GameConstants.InitializeVariables(dataTable);
                    this.Dispatcher.Invoke(() =>
                    {
                        ProgressBarLoading.Value += 30;
                    });
                }
            }
            catch(Exception)
            {
                this.error = true;
                MessageBox.Show("[ERROR] There was a unexpacted error with the web-service pleace try again later");
                return;
            }

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.backgroundWorker.RunWorkerAsync();

            //using (AdminServiceClient client = new AdminServiceClient())
            //{
            //    ProgressBarLoading.Value += 30;
            //    DataTable dataTable = client.GetAdminPercentageTable();
            //    ProgressBarLoading.Value += 30;
            //    GameConstants.InitializeVariables(dataTable);
            //    ProgressBarLoading.Value += 30;
            //}

            //GameWindow gameWindow = new GameWindow(this.game);
            //ProgressBarLoading.Value += 10;
            //gameWindow.Show();
            //this.Close();


        }

        private void ProgressBarLoading_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.backgroundWorker.RunWorkerAsync();
        }
    }
}
