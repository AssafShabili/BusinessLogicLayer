﻿using System;
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
using GameClient_12._01._2020.GameServiceReference;
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
        private UserBL UserBL;

        private DataTable dataTableProperties;


        private bool error = false;

        public LoadingWindow(GameBL gameBL, UserBL userBL)
        {
            InitializeComponent();
            this.game = gameBL;
            this.UserBL = userBL;

            //GameWindow gameWindow = new GameWindow(this.game,userBL);
            //this.Hide();
            //gameWindow.Show();

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
            if (!this.error)
            {
                labelLoading.Content = "finishing up ...";
                System.Threading.Thread.Sleep(1500);// 5 sec of sleeping to delay the task opening
                GameWindow gameWindow = new GameWindow(this.game, UserBL);
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
                        labelLoading.Content = "Fetching the info ..";
                    });
                    System.Threading.Thread.Sleep(5000);// 5 sec of sleeping to delay the task opening
                    GameConstants.InitializeVariables(dataTable);
                    this.Dispatcher.Invoke(() =>
                    {
                        ProgressBarLoading.Value += 30;
                        labelLoading.Content = "Initializing the info ...";
                    });
                    System.Threading.Thread.Sleep(5000);// 5 sec of sleeping to delay the task opening
                }

                using (ServiceClient gameClient = new ServiceClient())
                {
                    DataTable dataTable = gameClient.GetOtherUsersGameInfo();
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        GameDAL.DAL_Classess.Properties.UpdateProperties(
                             (int)dataTable.Rows[i]["Property_ID"],
                             (int)dataTable.Rows[i]["Wave_ID"],
                             (int)dataTable.Rows[i]["numbers_of_wins"],
                             (int)dataTable.Rows[i]["numbers_of_losess"],
                             (int)dataTable.Rows[i]["numbers_of_water_towers"],
                             (int)dataTable.Rows[i]["numbers_of_fire_towers"],
                             (int)dataTable.Rows[i]["numbers_of_air_towers"],
                             (int)dataTable.Rows[i]["numbers_of_earth_towers"]);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
