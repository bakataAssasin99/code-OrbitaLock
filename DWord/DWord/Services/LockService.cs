using DWord.Constant;
using DWord.Model;
using DWord.Properties;
using DWord.Services.AnLock;
using DWord.Services.ARCHIE;
using DWord.Services.BTLock;
using DWord.Services.ElockTemic;
using DWord.Services.NovaLock;
using DWord.Services.OrbitaLock;
using DWord.Services.ProUsb;
using DWord.Services.ProUsbNew;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DWord.Services
{
    class LockService
    {

        public static ResultReadCard WriteCard(int port, Card card, bool isUseDupKey) {
            var result = new ResultReadCard();
            switch (Settings.Default.LockSystem)
            {
                case ConstLock.DWORD_CODE:
                    result = DWordLockService.WriteCard(port, card, isUseDupKey);
                    break;
                case ConstLock.PROUSB_CODE:
                    result = ProUsbService.WriteCard(port, card, isUseDupKey);
                    break;
                case ConstLock.PROUSB_NEW_CODE:
                    result = ProUsbNewService.WriteCard(port, card, isUseDupKey);
                    break;
                case ConstLock.ARCHIE_CODE:
                    result = ArchieLockService.WriteCard(port, card, isUseDupKey);
                    break;
                case ConstLock.ANLOCK_CODE:
                    result = AnLockService.WriteCard(card);
                    break;
                case ConstLock.HUNE09_CODE:
                    result = Hune09Service.WriteCard(card, isUseDupKey);
                    break;
                case ConstLock.ELOCKTEMIC_CODE:
                    result = ElockTemicService.WriteCard(card, isUseDupKey);
                    break;
                case ConstLock.NOVA_CODE:
                    result = NovaService.WriteCard(card, isUseDupKey);
                    break;
                case ConstLock.PROUSB_2010_CODE:
                    result = ProUsbService2010.WriteCard(card, isUseDupKey);
                    break;
                case ConstLock.BT_CODE:
                    result = BTLockServices.WriteCard(card);
                    break;
                case ConstLock.ORBITA_CODE:
                    result = OrbitaService.WriteCard(card);
                    break;
            }
            
            return result;
        }

        public static ResultReadCard Cardbuilder(CardInfo request)
        {
            var result = new ResultReadCard();
            Helper.WriteLog("___WRITECARD___ " + Settings.Default.LockSystem);
            switch (Settings.Default.LockSystem)
            {
                case ConstLock.DWORD_CODE:
                    result = DWordLockService.Cardbuilder(request);
                    break;
                case ConstLock.PROUSB_CODE:
                    result = ProUsbService.Cardbuilder(request);
                    break;
                case ConstLock.PROUSB_NEW_CODE:
                    result = ProUsbNewService.Cardbuilder(request);
                    break;
                case ConstLock.ARCHIE_CODE:
                    result = ArchieLockService.Cardbuilder(request);
                    break;
                case ConstLock.ANLOCK_CODE:
                    result = AnLockService.Cardbuilder(request);
                    break;
                case ConstLock.HUNE09_CODE:
                    result = Hune09Service.Cardbuilder(request);
                    break;
                case ConstLock.ELOCKTEMIC_CODE:
                    result = ElockTemicService.Cardbuilder(request);
                    break;
                case ConstLock.NOVA_CODE:
                    result = NovaService.Cardbuilder(request);
                    break;
                case ConstLock.PROUSB_2010_CODE:
                    result = ProUsbService2010.Cardbuilder(request);
                    break;
                case ConstLock.BT_CODE:
                    result = BTLockServices.Cardbuilder(request);
                    break;

                case ConstLock.ORBITA_CODE:
                    result = OrbitaService.Cardbuilder(request);
                    break;
            }

            return result;
        }

        public static ResultReadCard ReadCard(int port)
        {
            Helper.WriteLog("___ReadCard___ " + Settings.Default.LockSystem);
            var result = new ResultReadCard();
            switch (Settings.Default.LockSystem)
            {
                case ConstLock.DWORD_CODE:
                    result = DWordLockService.ReadCard(port);
                    break;
                case ConstLock.PROUSB_CODE:
                    result = ProUsbService.ReadCard();
                    break;
                case ConstLock.PROUSB_NEW_CODE:
                    result = ProUsbNewService.ReadCard();
                    break;
                case ConstLock.ARCHIE_CODE:
                    result = ArchieLockService.ReadCard();
                    break;
                case ConstLock.ANLOCK_CODE:
                    result = AnLockService.ReadCard();
                    break;
                case ConstLock.HUNE09_CODE:
                    result = Hune09Service.ReadCard();
                    break;
                case ConstLock.ELOCKTEMIC_CODE:
                    result = ElockTemicService.ReadCard();
                    break;
                case ConstLock.NOVA_CODE:
                    result = NovaService.ReadCard();
                    break;
                case ConstLock.PROUSB_2010_CODE:
                    result = ProUsbService2010.ReadCard();
                    break;
                case ConstLock.BT_CODE:
                    result = BTLockServices.ReadCard();
                    break;
                case ConstLock.ORBITA_CODE:
                    result = OrbitaService.ReadCard();
                    break;
            }

            return result;
        }

        public static ResultReadCard DeleteCard(int port, Card card)
        {
            var result = new ResultReadCard();
            switch (Settings.Default.LockSystem)
            {
                case ConstLock.DWORD_CODE:
                    result = DWordLockService.DeleteCard(port);
                    break;
                case ConstLock.PROUSB_NEW_CODE:
                    result = ProUsbNewService.DeleteCard();
                    break;
                case ConstLock.PROUSB_CODE:
                    result = ProUsbService.DeleteCard();
                    break;
                case ConstLock.ANLOCK_CODE:
                    result = AnLockService.DeleteCard();
                    break;
                case ConstLock.HUNE09_CODE:
                    result = Hune09Service.DeleteCard();
                    break;
                case ConstLock.ELOCKTEMIC_CODE:
                    result = ElockTemicService.DeleteCard();
                    break;
                case ConstLock.NOVA_CODE:
                    result = NovaService.DeleteCard();
                    break;
                case ConstLock.PROUSB_2010_CODE:
                    result = ProUsbService2010.DeleteCard();
                    break;
                case ConstLock.BT_CODE:
                    result = BTLockServices.DeleteCard(card);
                    break;
                case ConstLock.ORBITA_CODE:
                    result = BTLockServices.DeleteCard(card);
                    break;
            }

            return result;
        }

        public static ResultReadCard StartSession(int softwareIndex, string serverUrl, int port = 0)
        { 
            var result = new ResultReadCard();
            result.status = true;
            result.mess = "Success";

            switch (Settings.Default.LockSystem)
            {
                case ConstLock.DWORD_CODE:
                    if (bool.Parse(ConfigurationManager.AppSettings["isDBACCESS"]))
                    {
                        result = DWordLockService.StartSession(softwareIndex + 1, serverUrl, "DllUser", 0);
                    }
                    else
                    {
                        result = DWordLockService.StartSession(softwareIndex + 1, serverUrl, "DllUser", 1);
                    }
                    break;
                case ConstLock.PROUSB_CODE:
                    result = ProUsbService.ProInitializeUSB(softwareIndex);
                    break;
                case ConstLock.PROUSB_NEW_CODE:
                    result = ProUsbNewService.ProInitializeUSB(softwareIndex);
                    break;
                case ConstLock.ARCHIE_CODE:
                    result = ArchieLockService.StartSession(port, softwareIndex);
                    break;
                case ConstLock.ANLOCK_CODE:
                    result = AnLockService.OpenPortUsb(port);
                    break;
                case ConstLock.ELOCKTEMIC_CODE:
                    result = ElockTemicService.StartSession();
                    break;
                case ConstLock.NOVA_CODE:
                    result = NovaService.StartSession();
                    break;
                case ConstLock.PROUSB_2010_CODE:
                    result = ProUsbService2010.ProInitializeUSB(softwareIndex);
                    break;
                case ConstLock.BT_CODE:
                    result = BTLockServices.StartSession();
                    break;
            }

            return result;
        }

        public static ResultReadCard EndSession()
        {
            var result = new ResultReadCard();
            result.status = true;
            result.mess = "Success";

            switch (Settings.Default.LockSystem)
            {
                case ConstLock.DWORD_CODE:
                    result = DWordLockService.EndSession();
                    break;
                case ConstLock.PROUSB_CODE:
                    break;
                case ConstLock.ARCHIE_CODE:
                    break;
            }

            return result;
        }

        public static bool CheckConnectAccessFile(string url)
        {
            bool result = true; 

            switch (Settings.Default.LockSystem)
            {
                case ConstLock.DWORD_CODE:
                    result = DWordLockService.CheckConnectAccessFile(url);
                    break;
                case ConstLock.PROUSB_CODE:
                    result = ProUsbService.CheckConnectAccessFile(url);
                    break;
                case ConstLock.PROUSB_NEW_CODE:
                    result = ProUsbNewService.CheckConnectAccessFile(url);
                    break;
                case ConstLock.ARCHIE_CODE:
                    result = ArchieLockService.CheckConnectAccessFile(url);
                    break;
                case ConstLock.HUNE09_CODE:
                    result = Hune09Service.CheckConnectAccessFile(url);
                    break;
                case ConstLock.PROUSB_2010_CODE:
                    result = ProUsbService2010.CheckConnectAccessFile(url);
                    break;
                case ConstLock.BT_CODE:
                    result = BTLockServices.CheckConnectAccessFile(url);
                    break;
                case ConstLock.ORBITA_CODE:
                    result = OrbitaService.CheckConnectAccessFile(url);
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
