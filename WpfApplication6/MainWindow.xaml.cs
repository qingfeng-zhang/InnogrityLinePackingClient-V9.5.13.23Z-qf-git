﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Xml;
using IGTwpf.views;
using IGTwpf.views.Base;
using InnogrityLinePackingClient.views.Base;
using InnogrityLinePackingClient.views;
using InnogrityLinePackingClient;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Input;
using System.Text;

namespace IGTwpf
{
    public partial class MainWindow : Window
    {
        NetworkThread networkthread;
        MainNetworkClass mainCls;

        private operator1window op1win;
        private operator2window op2win;

        public MainWindow()
        {
            //Prevent multiple instances 
            Process thisProc = Process.GetCurrentProcess();
            if (Process.GetProcessesByName(thisProc.ProcessName).Length > 1)
            {
                System.Windows.MessageBox.Show("Innogrity Client is already running.", "Innogrity - IGT");
                System.Windows.Application.Current.Shutdown();
                return;
            }

            //Initialize
            InitializeComponent();


            byte[] bytes = { 130, 200, 234, 23 }; // A byte array contains non-ASCII (or non-readable) characters

            string s1 = Encoding.UTF8.GetString(bytes); // ���
            byte[] decBytes1 = Encoding.UTF8.GetBytes(s1);  // decBytes1.Length == 10 !!
                                                            // decBytes1 not same as bytes
                                                            // Using UTF-8 or other Encoding object will get similar results

            string s2 = BitConverter.ToString(bytes);   // 82-C8-EA-17
            String[] tempAry = s2.Split('-');
            byte[] decBytes2 = new byte[tempAry.Length];
            for (int i = 0; i < tempAry.Length; i++)
                decBytes2[i] = Convert.ToByte(tempAry[i], 16);
            // decBytes2 same as bytes

            string s3 = Convert.ToBase64String(bytes);  // gsjqFw==
            byte[] decByte3 = Convert.FromBase64String(s3);
            // decByte3 same as bytes

      //      string s4 = HttpServerUtility.UrlTokenEncode(bytes);    // gsjqFw2
        //    byte[] decBytes4 = HttpServerUtility.UrlTokenDecode(s4);
            // decBytes4 same as bytes




            // MainNetworkClass network = new MainNetworkClass();
            networkthread = new NetworkThread();

            //Copy Station 6 Images
            networkthread.CopyStn6Images();

            //delete zpl files
            networkthread.RemoveZPLfiles();

            networkthread.NkThreadInit();
            this.DataContext = networkthread;

            //What is this 'str' for? #QuestionforPom 
            string str = ((NetworkThread)DataContext).ToString();

            this.ViewSide = new pageMainPanelDisplay(this);
            this.ViewTopSideHeader = new Header(this);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string str = ((NetworkThread)DataContext).ToString();
            this.ViewSide = new pageFinishingLabelInformation(this);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string str = ((NetworkThread)DataContext).ToString();
            this.ViewSide = new pageprinterfilelist(this);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string str = ((NetworkThread)DataContext).ToString();
            this.ViewSide = new pageMainPanelDisplay(this);
        }

        public Page ViewSide
        {
            get { return (Page)this.ViewSideFrame.Content; }
            set
            {
                this.ViewSideFrame.Navigate(value);
                this.ViewSideFrame.NavigationService.RemoveBackEntry();
                TranslateTransform scale = new TranslateTransform(-5, 0);
                this.ViewSideFrame.SetValue(RenderTransformProperty, scale);
                scale.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation(0, TimeSpan.FromMilliseconds(200)));
            }
        }

        public Header ViewTopSideHeader
        {
            get
            {
                return null;
                // return (Header)this.ViewTopSideHeader.Content;  //This was causing a weird error -Eugene
            }
            set
            {
                this.ViewHeaderFrame.Navigate(value);
                this.ViewHeaderFrame.NavigationService.RemoveBackEntry();
                TranslateTransform scale = new TranslateTransform(-5, 0);
                this.ViewHeaderFrame.SetValue(RenderTransformProperty, scale);
                scale.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation(0, TimeSpan.FromMilliseconds(200)));
            }

        }
        public Page ViewMain
        {
            get { return (Page)this.ViewMainFrame.Content; }
            set
            {
                this.ViewMainFrame.Navigate(value);
                this.ViewMainFrame.NavigationService.RemoveBackEntry();
                TranslateTransform scale = new TranslateTransform(-5, 0);
                this.ViewMainFrame.SetValue(RenderTransformProperty, scale);
                scale.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation(0, TimeSpan.FromMilliseconds(200)));
            }
        }

        public Page ViewBottom
        {
            get { return (Page)this.ViewBottomFrame.Content; }
            set
            {
                this.ViewBottomFrame.Navigate(value);
                this.ViewBottomFrame.NavigationService.RemoveBackEntry();
                TranslateTransform scale = new TranslateTransform(0, 5);
                this.ViewBottomFrame.SetValue(RenderTransformProperty, scale);
                scale.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation(0, TimeSpan.FromMilliseconds(200)));
            }
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Closes both operator windows when main window closes
            try
            {

            


                MessageBoxResult sureanot = System.Windows.MessageBox.Show(
               "Are you sure you want to Close?", "Main Window Close", System.Windows.MessageBoxButton.YesNo);
                if (sureanot == MessageBoxResult.Yes)
                {
                    networkthread.MyEventQ.AddQ("2;InnogrityServerApplicationClosed");//Push message to stack
                    networkthread.EvtLog.Info("2;InnogrityServerApplicationClosed");

                    networkthread.shutdown();
                    op1win.Close();
                    op2win.Close();
                    Thread.Sleep(1000);
                    System.Windows.Application.Current.Shutdown();

                }
                else
                {
                    e.Cancel = true;


                } 
                

            }
            catch
            {

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str = ((NetworkThread)DataContext).ToString();
            this.ViewSide = new pageFG01_FG02_MOVE(this);
        }

        private void ServerButton_Click_1(object sender, RoutedEventArgs e)
        {
            string str = ((NetworkThread)DataContext).ToString();
            this.ViewSide = new ServerCheck(this);
        }

        private void stationinputdata_Click_1(object sender, RoutedEventArgs e)
        {
            string str = ((NetworkThread)DataContext).ToString();
            this.ViewSide = new InnogrityLinePackingClient.views.TechnicianPage(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Window tow Screen Loaded
            //What is mainCLs #QuestionforPom
            mainCls = new MainNetworkClass();

            Screen[] sc;
            sc = Screen.AllScreens;
            op1win = new operator1window(this);
            op2win = new operator2window(this);

            if (sc.Length > 1)
            {
                op2win.Left = sc[1].Bounds.Left;
                op2win.Top = sc[1].Bounds.Top;
                op2win.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
            }

            if (sc.Length > 2)
            {
                op1win.Left = sc[2].Bounds.Left;
                op1win.Top = sc[2].Bounds.Top;
                op1win.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
            }

            op1win.Show();
            op2win.Show();

            op2win.WindowState = WindowState.Maximized;
            op1win.WindowState = WindowState.Maximized;
        }

        private void Omron_Setting(object sender, RoutedEventArgs e)
        {
            string str = ((NetworkThread)DataContext).ToString();
            this.ViewSide = new InnogrityLinePackingClient.views.OmronVision(this);
        }

        private void IGTReport_Click(object sender, RoutedEventArgs e)
        {
            string str = ((NetworkThread)DataContext).ToString();
            this.ViewSide = new InnogrityLinePackingClient.views.IGTReport();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if (e.Key == Key.F1)
            {
                WindowJam windowJam = new WindowJam(this);

                windowJam.Show();
            }
            else if (e.Key == Key.F5)
            {
                //TestWindow  testWin = new TestWindow((NetworkThread)DataContext);
                //TestWindow testWin = new TestWindow(this.networkthread);
                TestWindow testWin = new TestWindow(this);

                testWin.Show();
            }
        }
    }
}