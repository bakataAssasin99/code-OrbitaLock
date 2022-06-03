using DWord.Constant;
using DWord.Model;
using DWord.Properties;
using DWord.Services;
using ServiceStack.WebHost.Endpoints;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DWord.View
{
    public partial class Home : Form
    {
        public static string[] LOCK_LIST = { 
            ConstLock.DWORD_CODE, 
            ConstLock.PROUSB_CODE, 
            ConstLock.PROUSB_NEW_CODE, 
            ConstLock.ARCHIE_CODE, 
            ConstLock.ANLOCK_CODE, 
            ConstLock.HUNE09_CODE,
            ConstLock.ELOCKTEMIC_CODE,
            ConstLock.NOVA_CODE,
            ConstLock.PROUSB_2010_CODE,
            ConstLock.BT_CODE,
            ConstLock.ORBITA_CODE
        };
        private int indexLock = 0;
        string listeningOn = "http://*:2000/";
        public static AppHost appHost = new AppHost();

        public Home()
        {
            InitializeComponent();
        }

        public void Home_Load(object sender, EventArgs e)
        {
            try
            {
                appHost.Init();
                appHost.Start(listeningOn);
            }
            catch (Exception ex)
            {
                Helper.WriteLog("err: " + ex.ToString());
                MessageBox.Show("Phần mềm đã được bật, vui lòng kiểm tra lại.");
                Application.Exit();
            }
            
            indexLock = Array.IndexOf(LOCK_LIST,Settings.Default.LockSystem);
            MessageBox.Show(indexLock.ToString());
            LockSystem.SelectedIndex = indexLock;
        }            

        private void Software_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(indexLock != LockSystem.SelectedIndex)
            //{
                indexLock = LockSystem.SelectedIndex;
                Settings.Default.LockSystem = LOCK_LIST[indexLock];
                Settings.Default.Save();
                openChildFormInPanel(GetFormLock(indexLock));
            //}
        }

        private Form GetFormLock(int index)
        {
            Form formLock =  null;
            switch (LOCK_LIST[index])
            {
                case ConstLock.DWORD_CODE:
                    formLock = new DWordLock();
                    break;
                case ConstLock.PROUSB_CODE:
                case ConstLock.PROUSB_NEW_CODE:
                    formLock = new ProUsb();
                    break;
                case ConstLock.ARCHIE_CODE:
                    formLock = new ArchieLock();
                    break;
                case ConstLock.ANLOCK_CODE:
                    formLock = new AnLock();
                    ResultReadCard result = new ResultReadCard();
                    result = LockService.StartSession(0, "",0);
                    break;
                case ConstLock.HUNE09_CODE:
                    formLock = new HuneLock();
                    break;
                case ConstLock.ELOCKTEMIC_CODE:
                    formLock = new ElockTemic();
                    break;
                case ConstLock.NOVA_CODE:
                    formLock = new NovaLock();
                    break;
                case ConstLock.PROUSB_2010_CODE:
                    formLock = new ProUsb();
                    break;
                case ConstLock.BT_CODE:
                    formLock = new BTLock();
                    break;
                case ConstLock.ORBITA_CODE:
                    formLock = new OrbitaLock();
                    break;
            }

            return formLock;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show(); 
        }

        //Define the Web Services AppHost
        public class AppHost : AppHostHttpListenerBase
        {
            public AppHost()
            : base("HttpListener Self-Host", typeof(MainService).Assembly)
            { }

            public override void Configure(Funq.Container container)
            {
                base.SetConfig(new EndpointHostConfig
                {
                    GlobalResponseHeaders = {
                    { "Access-Control-Allow-Origin", "*" },
                    { "Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS" },
                    { "Access-Control-Allow-Headers", "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With" },
                },
                });

                Routes
                .Add<CardInfo>("/readcard")
                .Add<CardInfo>("/deletecard")
                .Add<CardInfo>("/writecard");
            }
        }
         
    }
}
