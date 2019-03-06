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
    public partial class Form1 : Form
    {
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
                Name = "Simulation Examples.Functions.Ramp1",
                Type = OPCTagType.Char
            });
            TagList.Add(new OPCTag()
            {
                Name = "Simulation Examples.Functions.Random1",
                Type = OPCTagType.Long
            });
            TagList.Add(new OPCTag()
            {
                Name = "Simulation Examples.Functions.Sine1",
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
                        break;
                    case 1:
                        textBox_Random_1.Text = item.Value.ToString();
                        break;
                    case 2:
                        textBox_Sin_1.Text = item.Value.ToString();
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
                connectInfo.ClientName = "OPCClient";

                try
                {
                    if (DAServer.IsConnected == false)
                        DAServer.Connect(URL, clientHandle, ref connectInfo, out isOPCConnectionFailed);
                    SubscribeData();
                }
                catch { }
            }
            else
            {
                try
                {
                    UnSubscribeData();
                    if (DAServer.IsConnected == true)
                        DAServer.Disconnect();
                }
                catch { }
            }
        }

        public Form1()
        {
            InitializeComponent();

            KeepAliveTime = 1000;
            RetryAfterConnectionError = true;
            RetryInitialConnection = false;
            ClientName = "OPCClient";
            URL = "opcda://localhost/Kepware.KEPServerEX.V6/";

            SubscribeToOPCDAServerEvents(DAServer_StateChanged, DAServer_DataChanged);

            /*
            try
            {
                if (DAServer.IsConnected == false)
                    DAServer.Connect(URL, clientHandle, ref connectInfo, out isOPCConnectionFailed);
                int tagCount = SubscribeData();
                ModifySubscription(true);
                MessageBox.Show(String.Format("Succesfully connected to {0} tags", tagCount), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            if (DAServer.IsConnected == true)
            {
                ConnectOPCServer(false);
                button_Connect.Text = "Coneect";
            }
            else
            {
                ConnectOPCServer(true);
                ModifySubscription(true);
                button_Connect.Text = "Disconnect";
            }
        }

        private void button_Settings_Click(object sender, EventArgs e)
        {

        }

        private void button_Check_connection_Click(object sender, EventArgs e)
        {
            if (TestConnection() == true)
                MessageBox.Show("Successfully connected");
            else
                MessageBox.Show("Connection attempt failed");
        }

        private void groupBox_Device_1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
