using CNC.Config;
using Open.Nat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CNC.Core.Helper
{
    class UPnPHelper
    {
        public static void ThreadedForward()
        {
            if(Settings.CNC_USE_UPNP)
            {
                Thread t = new Thread(Forward);
                t.Start();
            }
        }

        public static void Forward()
        {
            var t = Task.Run(async () =>
            {
                var nat = new NatDiscoverer();
                var cts = new CancellationTokenSource(5000);
                var device = await nat.DiscoverDeviceAsync(PortMapper.Upnp, cts);

                var ip = await device.GetExternalIPAsync();

                await device.CreatePortMapAsync(new Mapping(Protocol.Tcp, Settings.CNC_PORT, Settings.CNC_PORT, "CNC (Temporary)"));
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException e)
            {

            }
        }
    }
}
