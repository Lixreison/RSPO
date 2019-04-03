using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kepware.ClientAce.OpcDaClient;

namespace KClient
{
    public partial class FormMain : Form
    {
        const int MAX_POINT_COUNT = 20;

        // Глобальные переменные
        private string URL;
        private int KeepAliveTime;
        private bool RetryAfterConnectionError;
        private bool RetryInitialConnection;
        private string ClientName = "OPCClient";

        public DaServerMgt DAServer = new DaServerMgt();
        private ConnectInfo connectInfo = new ConnectInfo();
        private Boolean isOPCConnectionFailed = false;

        private ItemIdentifier[] itemIdentifiers;

        private int clientHandle = 1;
        private int clientSubscription = 1;
        private int serverSubscription = 0;

        public int UpdateRate = 1000;

        public bool IsConnected { get { return DAServer.IsConnected; } }

        public Settings settings = new Settings();

        List<Double> data = new List<double>();

        // Функция проверки подключеиня к серверу
        public bool TestConnection()
        {
            bool result = false;
            if (String.IsNullOrEmpty(URL)) return false;
            try
            {
                Kepware.ClientAce.OpcDaClient.ConnectInfo connectInfo = new Kepware.ClientAce.OpcDaClient.ConnectInfo();
                Kepware.ClientAce.OpcDaClient.DaServerMgt DAServer = new Kepware.ClientAce.OpcDaClient.DaServerMgt();
                Boolean connectFailed = false;

                connectInfo.LocalId = "en";
                connectInfo.KeepAliveTime = KeepAliveTime;
                connectInfo.RetryAfterConnectionError = RetryAfterConnectionError;
                connectInfo.RetryInitialConnection = RetryInitialConnection;
                connectInfo.ClientName = "OPCClient";

                Int32 clientHandle = 1;

                DAServer.Connect(URL, clientHandle, ref connectInfo, out connectFailed);
                result = !connectFailed;
                DAServer.Disconnect();
                return result;
            }
            catch { return false; }
        }

        // Создание метода подписки на данные
        private int SubscribeData()
        {
            List<OPCTag> TagList = new List<OPCTag>();
            TagList.Add(new OPCTag()
            {
                Name = settings.TagRamp1,
                Type = OPCTagType.Char
            });
            TagList.Add(new OPCTag()
            {
                Name = settings.TagRandom1,
                Type = OPCTagType.Long
            });
            TagList.Add(new OPCTag()
            {
                Name = settings.TagSin1,
                Type = OPCTagType.Float
            });

            TagList.Add(new OPCTag()
            {
                Name = settings.TagRamp2,
                Type = OPCTagType.Char
            });
            TagList.Add(new OPCTag()
            {
                Name = settings.TagRandom2,
                Type = OPCTagType.Long
            });
            TagList.Add(new OPCTag()
            {
                Name = settings.TagSin2,
                Type = OPCTagType.Float
            });

            TagList.Add(new OPCTag()
            {
                Name = settings.TagRamp3,
                Type = OPCTagType.Char
            });
            TagList.Add(new OPCTag()
            {
                Name = settings.TagRandom3,
                Type = OPCTagType.Long
            });
            TagList.Add(new OPCTag()
            {
                Name = settings.TagSin3,
                Type = OPCTagType.Float
            });

            TagList.Add(new OPCTag()
            {
                Name = settings.TagRamp4,
                Type = OPCTagType.Char
            });
            TagList.Add(new OPCTag()
            {
                Name = settings.TagRandom4,
                Type = OPCTagType.Long
            });
            TagList.Add(new OPCTag()
            {
                Name = settings.TagSin4,
                Type = OPCTagType.Float
            });

            // Определение локальных переменных и заполнение переменной itemIdentifiers
            bool active = false;
            int updateRate = UpdateRate;
            Single deadBand = 0;
            int revisedUpdateRate;

            int clientHandleUNQ = 0;
            int index = 0;

            itemIdentifiers = new ItemIdentifier[TagList.Count];

            foreach (OPCTag tag in TagList)
            {
                itemIdentifiers[index] = new ItemIdentifier();
                itemIdentifiers[index].ClientHandle = clientHandleUNQ;
                itemIdentifiers[index].DataType = Type.GetType(tag.Type.ToString());
                itemIdentifiers[index].ItemName = tag.Name;
                index++;
                clientHandleUNQ++;
            }

            // Подписка и подсчет удачныз подписок
            try
            {
                DAServer.Subscribe(clientSubscription, active, updateRate, out revisedUpdateRate, deadBand, ref itemIdentifiers, out serverSubscription);
                int faultCounter = 0;
                for (int itemIndex = 0; itemIndex < TagList.Count; itemIndex++)
                {
                    if (itemIdentifiers[itemIndex].ResultID.Succeeded == false)
                        faultCounter++;
                }
                return TagList.Count - faultCounter;
            }
            catch { return 0; }
        }

        // Создание метода отмены подписки
        private void UnSubscribeData()
        {
            try
            {
                if ((serverSubscription != 0) && (itemIdentifiers.Count() > 0))
                    DAServer.SubscriptionRemoveItems(serverSubscription, ref itemIdentifiers);
            }
            catch { };
        }

        // Метод сигнализации об изменении подписки
        public void ModifySubscription(bool action)
        {
            DAServer.SubscriptionModify(serverSubscription, action);
        }

        // Подписка на обновления данных
        public void ServerStateChanged(int clientHandle, ServerState state)
        {
            try
            {
                switch (state)
                {
                    case ServerState.ERRORSHUTDOWN:
                        label_server_state.Text = "Server State: Server is shutting down";
                        break;
                    case ServerState.ERRORWATCHDOG:
                        label_server_state.Text = "Server State: Server connection is lost";
                        break;
                    case ServerState.CONNECTED:
                        label_server_state.Text = "Server State: Server is connected";
                        break;
                    case ServerState.DISCONNECTED:
                        label_server_state.Text = "Server State: Server is disconnected";
                        break;
                }
            }
            catch { }
        }

        public void DataChanged(int clientSubscription, bool allQualitiesGood, bool noErrors, ItemValueCallback[] ItemValues)
        {
            DateTime itemTimeStamp = DateTime.Now;
            String itemName = String.Empty;

            foreach(ItemValueCallback item in ItemValues)
            {
                switch ((int)item.ClientHandle)
                {
                    case 0:
                        textBox_Ramp_1.Text = item.Value.ToString();
                        opcPanel1.RampValue = Convert.ToDouble(item.Value);
                        data.Add(opcPanel1.RampValue);
                        if (opcPanel1.RampChartPoint.Count > MAX_POINT_COUNT)
                        {
                            opcPanel1.RampChartPoint.RemoveAt(0);
                        }
                        opcPanel1.RampChartPoint.Add(opcPanel1.RampValue);
                        break;

                    case 1:
                        textBox_Random_1.Text = item.Value.ToString();
                        opcPanel1.RandomValue = Convert.ToDouble(item.Value);
                        data.Add(opcPanel1.RandomValue);
                        if (opcPanel1.RandomChartPoint.Count > MAX_POINT_COUNT)
                        {
                            opcPanel1.RandomChartPoint.RemoveAt(0);
                        }
                        opcPanel1.RandomChartPoint.Add(opcPanel1.RandomValue);
                        break;

                    case 2:
                        textBox_Sin_1.Text = item.Value.ToString();
                        opcPanel1.SinValue = Convert.ToDouble(item.Value);
                        data.Add(opcPanel1.SinValue);
                        if (opcPanel1.SinChartPoint.Count > MAX_POINT_COUNT)
                        {
                            opcPanel1.SinChartPoint.RemoveAt(0);
                        }
                        opcPanel1.SinChartPoint.Add(opcPanel1.SinValue);
                        if (opcPanel1.SinValue > 0)
                            opcPanel1.Indicator = IndicatorType.Red;
                        else
                            opcPanel1.Indicator = IndicatorType.Blue;
                        break;

                    case 3:
                        textBox_Ramp_2.Text = item.Value.ToString();
                        opcPanel2.RampValue = Convert.ToDouble(item.Value);
                        data.Add(opcPanel2.RampValue);
                        if (opcPanel2.RampChartPoint.Count > MAX_POINT_COUNT)
                        {
                            opcPanel2.RampChartPoint.RemoveAt(0);
                        }
                        opcPanel2.RampChartPoint.Add(opcPanel2.RampValue);
                        break;

                    case 4:
                        textBox_Random_2.Text = item.Value.ToString();
                        opcPanel2.RandomValue = Convert.ToDouble(item.Value);
                        data.Add(opcPanel2.RandomValue);
                        if (opcPanel2.RandomChartPoint.Count > MAX_POINT_COUNT)
                        {
                            opcPanel2.RandomChartPoint.RemoveAt(0);
                        }
                        opcPanel2.RandomChartPoint.Add(opcPanel2.RandomValue);
                        break;

                    case 5:
                        textBox_Sin_2.Text = item.Value.ToString();
                        opcPanel2.SinValue = Convert.ToDouble(item.Value);
                        data.Add(opcPanel2.SinValue);
                        if (opcPanel2.SinChartPoint.Count > MAX_POINT_COUNT)
                        {
                            opcPanel2.SinChartPoint.RemoveAt(0);
                        }
                        opcPanel2.SinChartPoint.Add(opcPanel2.SinValue);
                        if (opcPanel2.SinValue > 0)
                            opcPanel2.Indicator = IndicatorType.Red;
                        else
                            opcPanel2.Indicator = IndicatorType.Blue;
                        break;

                    case 6:
                        textBox_Ramp_3.Text = item.Value.ToString();
                        opcPanel3.RampValue = Convert.ToDouble(item.Value);
                        data.Add(opcPanel3.RampValue);
                        if (opcPanel3.RampChartPoint.Count > MAX_POINT_COUNT)
                        {
                            opcPanel3.RampChartPoint.RemoveAt(0);
                        }
                        opcPanel3.RampChartPoint.Add(opcPanel3.RampValue);
                        break;

                    case 7:
                        textBox_Random_3.Text = item.Value.ToString();
                        opcPanel3.RandomValue = Convert.ToDouble(item.Value);
                        data.Add(opcPanel3.RandomValue);
                        if (opcPanel3.RandomChartPoint.Count > MAX_POINT_COUNT)
                        {
                            opcPanel3.RandomChartPoint.RemoveAt(0);
                        }
                        opcPanel3.RandomChartPoint.Add(opcPanel3.RandomValue);
                        break;

                    case 8:
                        textBox_Sin_3.Text = item.Value.ToString();
                        opcPanel3.SinValue = Convert.ToDouble(item.Value);
                        data.Add(opcPanel3.SinValue);
                        if (opcPanel3.SinChartPoint.Count > MAX_POINT_COUNT)
                        {
                            opcPanel3.SinChartPoint.RemoveAt(0);
                        }
                        opcPanel3.SinChartPoint.Add(opcPanel3.SinValue);
                        if (opcPanel3.SinValue > 0)
                            opcPanel3.Indicator = IndicatorType.Red;
                        else
                            opcPanel3.Indicator = IndicatorType.Blue;
                        break;

                    case 9:
                        textBox_Ramp_4.Text = item.Value.ToString();
                        opcPanel4.RampValue = Convert.ToDouble(item.Value);
                        data.Add(opcPanel4.RampValue);
                        if (opcPanel4.RampChartPoint.Count > MAX_POINT_COUNT)
                        {
                            opcPanel4.RampChartPoint.RemoveAt(0);
                        }
                        opcPanel4.RampChartPoint.Add(opcPanel4.RampValue);
                        break;

                    case 10:
                        textBox_Random_4.Text = item.Value.ToString();
                        opcPanel4.RandomValue = Convert.ToDouble(item.Value);
                        data.Add(opcPanel4.RandomValue);
                        if (opcPanel4.RandomChartPoint.Count > MAX_POINT_COUNT)
                        {
                            opcPanel4.RandomChartPoint.RemoveAt(0);
                        }
                        opcPanel4.RandomChartPoint.Add(opcPanel4.RandomValue);
                        break;

                    case 11:
                        textBox_Sin_4.Text = item.Value.ToString();
                        opcPanel4.SinValue = Convert.ToDouble(item.Value);
                        data.Add(opcPanel4.SinValue);
                        if (opcPanel4.SinChartPoint.Count > MAX_POINT_COUNT)
                        {
                            opcPanel4.SinChartPoint.RemoveAt(0);
                        }
                        opcPanel4.SinChartPoint.Add(opcPanel4.SinValue);
                        if (opcPanel4.SinValue > 0)
                            opcPanel4.Indicator = IndicatorType.Red;
                        else
                            opcPanel4.Indicator = IndicatorType.Blue;
                        break;
                }
            }
        }

        public void DAServer_StateChanged(int clientHandle, ServerState state)
        {
            object[] SSCevHndArray = new object[2];
            SSCevHndArray[0] = clientHandle;
            SSCevHndArray[1] = state;
            BeginInvoke(new DaServerMgt.ServerStateChangedEventHandler(ServerStateChanged), SSCevHndArray);
        }

        public void DAServer_DataChanged(int clientSubscription, bool allQualitiesGood, bool noErrors, ItemValueCallback[] ItemValues)
        {
            object[] DCevHndlrArray = new object[4];
            DCevHndlrArray[0] = clientSubscription;
            DCevHndlrArray[1] = allQualitiesGood;
            DCevHndlrArray[2] = noErrors;
            DCevHndlrArray[3] = ItemValues;
            BeginInvoke(new DaServerMgt.DataChangedEventHandler(DataChanged), DCevHndlrArray);
        }

        public void SubscribeToOPCDAServerEvents(DaServerMgt.ServerStateChangedEventHandler DAServer_StateChanged, DaServerMgt.DataChangedEventHandler DAServer_DataChanged)
        {
            DAServer.ServerStateChanged += new Kepware.ClientAce.OpcDaClient.DaServerMgt.ServerStateChangedEventHandler(DAServer_StateChanged);
            DAServer.DataChanged += new DaServerMgt.DataChangedEventHandler(DAServer_DataChanged);
        }

        // Функция подключения/отключения к/от серверу(а)
        public void ConnectOPCServer(bool connectToOPC)
        {
            if (connectToOPC)
            {
                connectInfo.LocalId = "en";
                connectInfo.KeepAliveTime = KeepAliveTime;
                connectInfo.RetryAfterConnectionError = RetryAfterConnectionError;
                connectInfo.RetryInitialConnection = RetryInitialConnection;
                connectInfo.ClientName = ClientName;

                try
                {
                    if (DAServer.IsConnected == false)
                        DAServer.Connect(URL, clientHandle, ref connectInfo, out isOPCConnectionFailed);
                    int tagCount = SubscribeData();
                    ModifySubscription(true);
                    MessageBox.Show(String.Format("Succesfully connected to {0} tags", tagCount), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch { }
            }
            else
            {
                try
                {
                    UnSubscribeData();
                    if (DAServer.IsConnected == true) DAServer.Disconnect();
                }
                catch { }
            }
        }
        
        public FormMain()
        {
            InitializeComponent();
            settings.Load();

            KeepAliveTime = 1000;
            RetryAfterConnectionError = true;
            RetryInitialConnection = false;
            URL = settings.OPCServerURL;

            SubscribeToOPCDAServerEvents(DAServer_StateChanged, DAServer_DataChanged);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            opcPanel1.SinTitle = "Sin 1";
            opcPanel1.RampTitle = "Ramp 1";
            opcPanel1.RandomTitle = "Random 1";
            opcPanel1.PanelTitle = "OPC Panel 1";

            opcPanel2.SinTitle = "Sin 2";
            opcPanel2.RampTitle = "Ramp 2";
            opcPanel2.RandomTitle = "Random 2";
            opcPanel2.PanelTitle = "OPC Panel 2";

            opcPanel3.SinTitle = "Sin 3";
            opcPanel3.RampTitle = "Ramp 3";
            opcPanel3.RandomTitle = "Random 3";
            opcPanel3.PanelTitle = "OPC Panel 3";

            opcPanel4.SinTitle = "Sin 4";
            opcPanel4.RampTitle = "Ramp 4";
            opcPanel4.RandomTitle = "Random 4";
            opcPanel4.PanelTitle = "OPC Panel 4";
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            if (IsConnected == false)
            {
                ConnectOPCServer(true);
                button_Connect.Text = "Disconnect";

                opcPanel1.SinChartPoint.Clear();
                opcPanel1.RampChartPoint.Clear();
                opcPanel1.RandomChartPoint.Clear();

                opcPanel2.SinChartPoint.Clear();
                opcPanel2.RampChartPoint.Clear();
                opcPanel2.RandomChartPoint.Clear();

                opcPanel3.SinChartPoint.Clear();
                opcPanel3.RampChartPoint.Clear();
                opcPanel3.RandomChartPoint.Clear();

                opcPanel4.SinChartPoint.Clear();
                opcPanel4.RampChartPoint.Clear();
                opcPanel4.RandomChartPoint.Clear();
            }
            else
            {
                ConnectOPCServer(false);
                button_Connect.Text = "Connect";
            }
        }

        private void button_Settings_Click(object sender, EventArgs e)
        {
            FormSettings frmSettings = new FormSettings();
            if (frmSettings.ShowDialog() == DialogResult.OK) settings.Load();
        }

        private void button_Check_connection_Click(object sender, EventArgs e)
        {
            if (TestConnection() == true)
                MessageBox.Show("Successfully connected");
            else
                MessageBox.Show("Connection attempt failed");
        }
    }
}
