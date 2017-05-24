using NetworkCommsDotNet.Connections.TCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Config
{
    class Settings
    {
        //---------------CONNECTION---------------//

        public static string CNC_ADDRESS = "127.0.0.1";
        public static int CNC_PORT = 8661;

        //--------------CRYPTOGRAPHY--------------//

        public static string CONNECTION_ENCRYPTION_KEY;
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        public static int CONNECTION_ENCRYPTION_KEYSIZE = 512;
        // This constant determines the number of iterations for the password bytes generation function.
        public static int CONNECTION_ENCRYPTION_DERIVACTION_ITERATIONS = 5000;
    }
}
