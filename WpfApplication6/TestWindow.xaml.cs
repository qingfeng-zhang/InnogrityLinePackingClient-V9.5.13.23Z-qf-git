using BCReader;
using IGTwpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace InnogrityLinePackingClient
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        NetworkThread networkthread;
        System.Windows.Threading.DispatcherTimer dispatcherTimer = null;
        int counter = 0;
        public TestWindow(MainWindow mainWindow)
        // public TestWindow(NetworkThread networkthread)
        //public TestWindow(Object networkthread)
        {
            InitializeComponent();
             this.networkthread = (NetworkThread)mainWindow.DataContext;
         //   this.DataContext = networkthread;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            counter++;
            String Errmessage8 = "[CT]" + counter;
            networkthread.Station1Barcode1 = Errmessage8;
           // this.networkthread.networkmain.UpdateErrorMsg((int)Station.StationNumber.Station01, Errmessage8,true);

           // networkthread.networkmain.Station1Barcode1 = Errmessage8;
            networkthread.networkmain.CriticalErrors0 = Errmessage8;
            networkthread.networkmain.CriticalErrors1 = Errmessage8;
            networkthread.networkmain.CriticalErrors2 = Errmessage8;

           // this.networkthread.UpdateErrorMsg((int)Station.StationNumber.Station08, Errmessage8);
            
        }

        private void testLabel_click(object sender, RoutedEventArgs e)
        {
            
            int OEEID;
            //string TLtoOEEID = "0S30ZX";
            string TLtoOEEID = "0S30ZX #x0 R";

            //         String flXL = "<LABEL><ID>BY34G7Z.21</ID><TYPE>TR</TYPE><OEEid>160500</OEEid><ST02Rotary>RC</ST02Rotary><REELHEIGHT>24</REELHEIGHT><TRAYNO>0</TRAYNO><TRAY_THICKNESS>0</TRAY_THICKNESS><TOTAL_TRAY_HEIGHT>0</TOTAL_TRAY_HEIGHT><HIC_REQUIRED>YES</HIC_REQUIRED><DESICCANT_REQUIRED>YES</DESICCANT_REQUIRED><AQL>NO</AQL><MBBTYPE>TRMSTL25A</MBBTYPE><SEALER>240</SEALER><STATION02PRINTNO>1</STATION02PRINTNO><STATION04PRINTNO>2</STATION04PRINTNO><STATION07PRINTNO>2</STATION07PRINTNO><IMAGE_FILENAME>TR_Micron.jpg</IMAGE_FILENAME><MESSAGE>This is Micron TR product.</MESSAGE><CUST_SPECIFIC_FLOW>NA</CUST_SPECIFIC_FLOW><SPTK_MARKED></SPTK_MARKED><TrackingLabel>0S30ZX&#x0;R</TrackingLabel><PackageStatus>NA</PackageStatus><ErrorCode>NA</ErrorCode><St4vision>PASS</St4vision><St7Result>NA</St7Result><SealerNumber>2</SealerNumber><SealerResult>PASS</SealerResult><SealerResultReason>NA</SealerResultReason></LABEL><LABEL><ID>BYVWP7Z.21</ID><TYPE>TR</TYPE><OEEid>160502</OEEid><ST02Rotary>NA</ST02Rotary><REELHEIGHT>32</REELHEIGHT><TRAYNO>0</TRAYNO><TRAY_THICKNESS>0</TRAY_THICKNESS><TOTAL_TRAY_HEIGHT>0</TOTAL_TRAY_HEIGHT><HIC_REQUIRED>YES</HIC_REQUIRED><DESICCANT_REQUIRED>YES</DESICCANT_REQUIRED><AQL>NO</AQL><MBBTYPE>TRMSTL25A</MBBTYPE><SEALER>320</SEALER><STATION02PRINTNO>1</STATION02PRINTNO><STATION04PRINTNO>2</STATION04PRINTNO><STATION07PRINTNO>2</STATION07PRINTNO><IMAGE_FILENAME>TR_Micron.jpg</IMAGE_FILENAME><MESSAGE>This is Micron TR product.</MESSAGE><CUST_SPECIFIC_FLOW>NA</CUST_SPECIFIC_FLOW><SPTK_MARKED></SPTK_MARKED><TrackingLabel>0S300W&#x0;Q</TrackingLabel><PackageStatus>NA</PackageStatus><ErrorCode>NA</ErrorCode><St4vision>PASS</St4vision><St7Result>NA</St7Result><SealerNumber>1</SealerNumber><SealerResult>PASS</SealerResult><SealerResultReason>NA</SealerResultReason></LABEL>";
            // add <LABELS> </LABELS>
            String flXL = "<LABELS><LABEL><ID>BY34G7Z.21</ID><TYPE>TR</TYPE><OEEid>160500</OEEid><ST02Rotary>RC</ST02Rotary><REELHEIGHT>24</REELHEIGHT><TRAYNO>0</TRAYNO><TRAY_THICKNESS>0</TRAY_THICKNESS><TOTAL_TRAY_HEIGHT>0</TOTAL_TRAY_HEIGHT><HIC_REQUIRED>YES</HIC_REQUIRED><DESICCANT_REQUIRED>YES</DESICCANT_REQUIRED><AQL>NO</AQL><MBBTYPE>TRMSTL25A</MBBTYPE><SEALER>240</SEALER><STATION02PRINTNO>1</STATION02PRINTNO><STATION04PRINTNO>2</STATION04PRINTNO><STATION07PRINTNO>2</STATION07PRINTNO><IMAGE_FILENAME>TR_Micron.jpg</IMAGE_FILENAME><MESSAGE>This is Micron TR product.</MESSAGE><CUST_SPECIFIC_FLOW>NA</CUST_SPECIFIC_FLOW><SPTK_MARKED></SPTK_MARKED><TrackingLabel>0S30ZX&#x0;R</TrackingLabel><PackageStatus>NA</PackageStatus><ErrorCode>NA</ErrorCode><St4vision>PASS</St4vision><St7Result>NA</St7Result><SealerNumber>2</SealerNumber><SealerResult>PASS</SealerResult><SealerResultReason>NA</SealerResultReason></LABEL><LABEL><ID>BYVWP7Z.21</ID><TYPE>TR</TYPE><OEEid>160502</OEEid><ST02Rotary>NA</ST02Rotary><REELHEIGHT>32</REELHEIGHT><TRAYNO>0</TRAYNO><TRAY_THICKNESS>0</TRAY_THICKNESS><TOTAL_TRAY_HEIGHT>0</TOTAL_TRAY_HEIGHT><HIC_REQUIRED>YES</HIC_REQUIRED><DESICCANT_REQUIRED>YES</DESICCANT_REQUIRED><AQL>NO</AQL><MBBTYPE>TRMSTL25A</MBBTYPE><SEALER>320</SEALER><STATION02PRINTNO>1</STATION02PRINTNO><STATION04PRINTNO>2</STATION04PRINTNO><STATION07PRINTNO>2</STATION07PRINTNO><IMAGE_FILENAME>TR_Micron.jpg</IMAGE_FILENAME><MESSAGE>This is Micron TR product.</MESSAGE><CUST_SPECIFIC_FLOW>NA</CUST_SPECIFIC_FLOW><SPTK_MARKED></SPTK_MARKED><TrackingLabel>0S300W&#x0;Q</TrackingLabel><PackageStatus>NA</PackageStatus><ErrorCode>NA</ErrorCode><St4vision>PASS</St4vision><St7Result>NA</St7Result><SealerNumber>1</SealerNumber><SealerResult>PASS</SealerResult><SealerResultReason>NA</SealerResultReason></LABEL></LABELS>";

            //      String flXL = "<LABELS >< LABEL >< ID > BY34G7Z.21 </ ID >< TYPE > TR </ TYPE >< OEEid > 160500 </ OEEid >< ST02Rotary > RC </ ST02Rotary >< REELHEIGHT > 24 </ REELHEIGHT >< TRAYNO > 0 </ TRAYNO >< TRAY_THICKNESS > 0 </ TRAY_THICKNESS >< TOTAL_TRAY_HEIGHT > 0 </ TOTAL_TRAY_HEIGHT >< HIC_REQUIRED > YES </ HIC_REQUIRED >< DESICCANT_REQUIRED > YES </ DESICCANT_REQUIRED >< AQL > NO </ AQL >< MBBTYPE > TRMSTL25A </ MBBTYPE >< SEALER > 240 </ SEALER >< STATION02PRINTNO > 1 </ STATION02PRINTNO >< STATION04PRINTNO > 2 </ STATION04PRINTNO >< STATION07PRINTNO > 2 </ STATION07PRINTNO >< IMAGE_FILENAME > TR_Micron.jpg </ IMAGE_FILENAME >< MESSAGE > This is Micron TR product.</ MESSAGE >< CUST_SPECIFIC_FLOW > NA </ CUST_SPECIFIC_FLOW >< SPTK_MARKED ></ SPTK_MARKED >< TrackingLabel > 0S30ZX & x0 R </ TrackingLabel >< PackageStatus > NA </ PackageStatus >< ErrorCode > NA </ ErrorCode >< St4vision > PASS </ St4vision >< St7Result > NA </ St7Result >< SealerNumber > 2 </ SealerNumber >< SealerResult > PASS </ SealerResult >< SealerResultReason > NA </ SealerResultReason ></ LABEL >< LABEL >< ID > BYVWP7Z.21 </ ID >< TYPE > TR </ TYPE >< OEEid > 160502 </ OEEid >< ST02Rotary > NA </ ST02Rotary >< REELHEIGHT > 32 </ REELHEIGHT >< TRAYNO > 0 </ TRAYNO >< TRAY_THICKNESS > 0 </ TRAY_THICKNESS >< TOTAL_TRAY_HEIGHT > 0 </ TOTAL_TRAY_HEIGHT >< HIC_REQUIRED > YES </ HIC_REQUIRED >< DESICCANT_REQUIRED > YES </ DESICCANT_REQUIRED >< AQL > NO </ AQL >< MBBTYPE > TRMSTL25A </ MBBTYPE >< SEALER > 320 </ SEALER >< STATION02PRINTNO > 1 </ STATION02PRINTNO >< STATION04PRINTNO > 2 </ STATION04PRINTNO >< STATION07PRINTNO > 2 </ STATION07PRINTNO >< IMAGE_FILENAME > TR_Micron.jpg </ IMAGE_FILENAME >< MESSAGE > This is Micron TR product.</ MESSAGE >< CUST_SPECIFIC_FLOW > NA </ CUST_SPECIFIC_FLOW >< SPTK_MARKED ></ SPTK_MARKED >< TrackingLabel > 0S300W & x0 Q </ TrackingLabel >< PackageStatus > NA </ PackageStatus >< ErrorCode > NA </ ErrorCode >< St4vision > PASS </ St4vision >< St7Result > NA </ St7Result >< SealerNumber > 1 </ SealerNumber >< SealerResult > PASS </ SealerResult >< SealerResultReason > NA </ SealerResultReason ></ LABEL> </LABELS>";


            flXL = flXL.Replace(";", " ");

         //   flXL = flXL.Replace("#", " ");
            flXL = flXL.Replace("&", " ");
            networkthread.networkmain.FLTrackingdoc.LoadXml(flXL);


            //    --ConfigEventcodeSource.xml  
            //   
            // DM6290-6100=280    2*280+11=591
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(networkthread.EnterStation_DoWorks);

            bw.RunWorkerAsync(new int[] { 4, 591 });


            //bool GetFLok = networkthread. GetFLByTL(TLtoOEEID, out OEEID);
            //if (GetFLok && OEEID > 0)
            //{
            //    networkthread.rq.UpdStNobyID(7, OEEID);
            //   // EvtLog.Info("OEEID = " + OEEID.ToString());
            //}
            //else
            //{
            //    //EvtLog.Info("OEEID REQ FAIL");
            //}

            /* <?xml version="1.0"?>

-<LABELS>


-<LABEL>

<ID>BY34G7Z.21</ID>

<TYPE>TR</TYPE>

<OEEid>160500</OEEid>

<ST02Rotary>RC</ST02Rotary>

<REELHEIGHT>24</REELHEIGHT>

<TRAYNO>0</TRAYNO>

<TRAY_THICKNESS>0</TRAY_THICKNESS>

<TOTAL_TRAY_HEIGHT>0</TOTAL_TRAY_HEIGHT>

<HIC_REQUIRED>YES</HIC_REQUIRED>

<DESICCANT_REQUIRED>YES</DESICCANT_REQUIRED>

<AQL>NO</AQL>

<MBBTYPE>TRMSTL25A</MBBTYPE>

<SEALER>240</SEALER>

<STATION02PRINTNO>1</STATION02PRINTNO>

<STATION04PRINTNO>2</STATION04PRINTNO>

<STATION07PRINTNO>2</STATION07PRINTNO>

<IMAGE_FILENAME>TR_Micron.jpg</IMAGE_FILENAME>

<MESSAGE>This is Micron TR product.</MESSAGE>

<CUST_SPECIFIC_FLOW>NA</CUST_SPECIFIC_FLOW>

<SPTK_MARKED/>

<TrackingLabel>0S30ZX #x0 R</TrackingLabel>

<PackageStatus>NA</PackageStatus>

<ErrorCode>NA</ErrorCode>

<St4vision>PASS</St4vision>

<St7Result>NA</St7Result>

<SealerNumber>2</SealerNumber>

<SealerResult>PASS</SealerResult>

<SealerResultReason>NA</SealerResultReason>

</LABEL>


-<LABEL>

<ID>BYVWP7Z.21</ID>

<TYPE>TR</TYPE>

<OEEid>160502</OEEid>

<ST02Rotary>NA</ST02Rotary>

<REELHEIGHT>32</REELHEIGHT>

<TRAYNO>0</TRAYNO>

<TRAY_THICKNESS>0</TRAY_THICKNESS>

<TOTAL_TRAY_HEIGHT>0</TOTAL_TRAY_HEIGHT>

<HIC_REQUIRED>YES</HIC_REQUIRED>

<DESICCANT_REQUIRED>YES</DESICCANT_REQUIRED>

<AQL>NO</AQL>

<MBBTYPE>TRMSTL25A</MBBTYPE>

<SEALER>320</SEALER>

<STATION02PRINTNO>1</STATION02PRINTNO>

<STATION04PRINTNO>2</STATION04PRINTNO>

<STATION07PRINTNO>2</STATION07PRINTNO>

<IMAGE_FILENAME>TR_Micron.jpg</IMAGE_FILENAME>

<MESSAGE>This is Micron TR product.</MESSAGE>

<CUST_SPECIFIC_FLOW>NA</CUST_SPECIFIC_FLOW>

<SPTK_MARKED/>

<TrackingLabel>0S300W #x0 Q</TrackingLabel>

<PackageStatus>NA</PackageStatus>

<ErrorCode>NA</ErrorCode>

<St4vision>PASS</St4vision>

<St7Result>NA</St7Result>

<SealerNumber>1</SealerNumber>

<SealerResult>PASS</SealerResult>

<SealerResultReason>NA</SealerResultReason>

</LABEL>

</LABELS>
*/

        }

        private void ST1Error_Click(object sender, RoutedEventArgs e)
        {
            networkthread.networkmain.CriticalErrors1 = "STN2: BUFFER SERVO ALARM[JAM]";
            networkthread.ScannerStatus = BarcodeStatus.NotScanned;
        }
        private void ST2Error_Click(object sender, RoutedEventArgs e)
        {

            //          Array.Copy(networkthread.PLCQueryRx, 371, tmparrayER2_, 0, 2);  //180=371,181=373,182=375,183=377,184=379,185=381,186=383,187=385

            //180=371,181=373,182=375,183=377,184=379,185=381,186=383,187=385
            networkthread.Set_PLC_Error(371, 2918);// St2 Door 
            networkthread.ST2_Error();
            networkthread.SafetyStatus = AreaStatus.Block;
            networkthread.SafetyStatus2 = AreaStatus.Block;

            //dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            //dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            //dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            //dispatcherTimer.Start();
        }
        private void ST4Error_Click(object sender, RoutedEventArgs e)
        {
            //  < E4140 > STN4:CAMERA CONTINUOUS REJECT[ALM] </ E4140 >
             // < E4145 > STN4:LABEL PRINTER SERVICE REQUIRED[ALM]</ E4145 >
            networkthread.Set_PLC_Error(401, 4145);// St4    //195=401
            networkthread.ST4_Error();
            networkthread.ScannerStatus = BarcodeStatus.NotScanned;
            networkthread.SafetyStatus2 = AreaStatus.Block;
        }

        private void ST7Error_Click(object sender, RoutedEventArgs e)
        {
            //  <E7741>STN7: LABEL VACUUM SENSOR FAILED [JAM]</E7741>
            networkthread.Set_PLC_Error2(405, 7714);// St7   405
            networkthread.ST7_Error();
            networkthread.ScannerStatus = BarcodeStatus.NotScanned;
            networkthread.SafetyStatus2 = AreaStatus.Block;
        }
        private void ST8Error_Click(object sender, RoutedEventArgs e)
        {
            //  <E8802>STN8:CURTAIN SENSOR ACTIVATED [JAM]</E8802>
           // networkthread.Set_PLC_Error2(407, 8802);// St8   407
            networkthread.Set_PLC_Error2(407, 8823);// St8   407
            networkthread.ST8_Error();
            networkthread.ScannerStatus = BarcodeStatus.NotScanned;
            networkthread.SafetyStatus2 = AreaStatus.Block;
  //          networkthread.networkmain.CriticalErrors8= "CT888 ";
        }

        private void ST2Direct_Click(object sender, RoutedEventArgs e)
        {
            networkthread.networkmain.CriticalErrors2 = "CT2 ";
            networkthread.networkmain.CriticalErrors4 = "CT4 ";
            networkthread.ST2_Error();
            networkthread.ScannerStatus = BarcodeStatus.NotScanned;

            if (dispatcherTimer != null)
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;
            };
        }

        private void NoCritical_Click(object sender, RoutedEventArgs e)
        {
            networkthread.networkmain.CriticalErrors0 = "";
            networkthread.networkmain.CriticalErrors1 = "";
            networkthread.networkmain.CriticalErrors2 = "";
            networkthread.networkmain.CriticalErrors3 = "";
            networkthread.networkmain.CriticalErrors4 = "";
            networkthread.networkmain.CriticalErrors5 = "";
            networkthread.networkmain.CriticalErrors6 = "";
            networkthread.networkmain.CriticalErrors7 = "";
            networkthread.networkmain.CriticalErrors8 = "";
            networkthread.Set_PLC_Error(371, 0);// St2 Door 
            networkthread.ST2_Error();

            networkthread.ScannerStatus = BarcodeStatus.Null;
            networkthread.SafetyStatus2 = AreaStatus.Null;
        }

        private void AllError_Click(object sender, RoutedEventArgs e)
        {
            networkthread.networkmain.CriticalErrors0 = "CT0";
            networkthread.networkmain.CriticalErrors1 = "CT1";
            networkthread.networkmain.CriticalErrors2 = "CT2";
            networkthread.networkmain.CriticalErrors3 = "CT3";
            networkthread.networkmain.CriticalErrors4 = "CT4";
            networkthread.networkmain.CriticalErrors5 = "CT5";
            networkthread.networkmain.CriticalErrors6 = "CT6";
            networkthread.networkmain.CriticalErrors7 = "CT7";
            networkthread.networkmain.CriticalErrors8 = "CT8";
        }

        private void ClearError_Click(object sender, RoutedEventArgs e)
        {
            networkthread.networkmain.CriticalErrors0 = "";
            networkthread.networkmain.CriticalErrors1 = "";
            networkthread.networkmain.CriticalErrors2 = "";
            networkthread.networkmain.CriticalErrors3 = "";
            networkthread.networkmain.CriticalErrors4 = "";
            networkthread.networkmain.CriticalErrors5 = "";
            networkthread.networkmain.CriticalErrors6 = "";
            networkthread.networkmain.CriticalErrors7 = "";
            networkthread.networkmain.CriticalErrors8 = "";
 

            networkthread.ScannerStatus = BarcodeStatus.Null;
            networkthread.SafetyStatus2 = AreaStatus.Null;
        }

        private void vision7_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Config.xml");
            XmlNode VisionIPAddress = doc.SelectSingleNode(@"/CONFIG/LABELVISIONST07/ADD");
            XmlNode VisionPortNo = doc.SelectSingleNode(@"/CONFIG/LABELVISIONST07/PORT");

            LinePackInspection OmronSt07Barcode = new LinePackInspection()
            {
                HostAddress = VisionIPAddress.InnerText,//"192.168.3.122", 
                PortNumber = int.Parse(VisionPortNo.InnerText)//9877 

            };

         //   OmronSt07Barcode.networkthread = this.networkthread;
            OmronSt07Barcode.InitVision();
        }

        private void vision2_Click(object sender, RoutedEventArgs e)
        {
            networkthread.evt_Station02InspectionReq.Set();
        }

 
        private void setLabel3_click(object sender, RoutedEventArgs e)
        {
            //networkthread.Set_FL(331, "BY1Y29Z.21");// ST3 
            networkthread.Set_FL(331, txtLabel.Text);// ST3 
        }
        private void setLable2_click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            networkthread.Set_Event1(195,4145);// label request fail DM195, 196, DM196
            
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
