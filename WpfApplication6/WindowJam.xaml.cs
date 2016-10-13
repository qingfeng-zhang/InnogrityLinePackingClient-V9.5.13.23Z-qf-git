using IGTwpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace InnogrityLinePackingClient
{
    /// <summary>
    /// Interaction logic for WindowJam.xaml
    /// </summary>
    public partial class WindowJam : Window
    {
        NetworkThread networkthread;
        public WindowJam(MainWindow mainWindow)
        // public TestWindow(NetworkThread networkthread)
        //public TestWindow(Object networkthread)
        {
            InitializeComponent();
            this.networkthread = (NetworkThread)mainWindow.DataContext;
            //LoadJamData();

            this.DataContext = mainWindow.DataContext;
 
        }

        private void LoadJamData()
        {
           
            XmlDocument all = networkthread.GetAllJam();

            if (all != null)
            {
                String iXML = all.InnerXml;
                iXML = iXML.Replace("DocumentElement", "LABELS");

                XmlElement element = all.DocumentElement;

                XmlNode x = all.FirstChild;

                XmlNodeList xx = all.SelectNodes(@"/*/LABEL");

                XmlDocument labels = new XmlDocument();
                //           labels.LoadXml(@"<LABELS></LABELS>");

                labels.LoadXml(iXML);

                Jamdataprovider.Document = labels;

                //Jamdataprovider.Document = new XmlDocument();

                //Jamdataprovider.Document.AppendChild(x);

                //Jamdataprovider.Document.ImportNode(x, true);
            }

        }

        private void listbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.ListView listView = sender as System.Windows.Controls.ListView;
            XmlElement item = (XmlElement)listView.SelectedItem;
            XmlDocument labels = new XmlDocument();
            labels.LoadXml(@"<LABELS><LABEL>" + item.InnerXml + "</LABEL></LABELS>");
            XmlNodeList nodeList = item.GetElementsByTagName("FL");
            if (nodeList != null)
            {
                String fl = nodeList[0].InnerText;
                //DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(fl, "Are you sure to delete?", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning);
                //if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                //{
                    try
                    {
                        string RJCODE = "996";
                        XmlDocument doc = new XmlDocument();
                        doc.Load(@"ConfigEvent.xml");
                        XmlNode node = doc.SelectSingleNode(@"/EVENT/R" + RJCODE);
                        string RJName = node.InnerText;

                        networkthread.networkmain.Client_SendEventMessage("66", RJName, "BOX_ID", fl);


                        networkthread.MyEventQ.AddQ("3;FinishingLabelDataCleared;Lotnumber;" + fl);
                        networkthread.EvtLog.Info("3;FinishingLabelDataCleared;Lotnumber;" + fl);

                    }
                    catch (Exception ex)
                    {

                    }


                    networkthread.networkmain.Client_sendFG01_FG02_MOVE(fl, "FG01_FG02_MOVE,TECHNICIAN  MANUAL REJECT");


                //}
                //else if (dialogResult == System.Windows.Forms.DialogResult.OK)
                //{

                //}
            }
        }

        private void listJam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ListView listView = sender as ListView;

            //XmlElement item =(XmlElement)listView.SelectedItem;
            //XmlDocument labels = new XmlDocument();
            //labels.LoadXml(@"<LABELS><LABEL>"+ item.InnerXml+ "</LABEL></LABELS>");
            //XmlNodeList nodeList=item.GetElementsByTagName("FL");
            //if (nodeList!=null)
            //{
            //    String fl = nodeList[0].InnerText;
            //}
            
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                Rect workArea = SystemParameters.WorkArea;
                this.Left = (workArea.Width - e.NewSize.Width) / 2 + workArea.Left;
                this.Top = (workArea.Height - e.NewSize.Height) / 2 + workArea.Top;

                txtPassword.Focus();
            }
            catch (Exception ex) {
               // ... Handel exception;
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
 

            int micronpass = networkthread.networkmain.Token3;
            string micPass = micronpass.ToString();

            //          if ((passwordBox.Password == "Innogrity" || passwordBox.Password == micPass)  )
            //          if ( passwordBox.Password == "Innogrity")
            if (  true  )
            {
                popup.IsOpen = false;

                LoadJamData();

            }
            else
            {
                popup.IsOpen = false;
                System.Windows.Forms.MessageBox.Show("Wrong Password,try againg!");
                this.Close();
            }

        }

        private void Cancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
