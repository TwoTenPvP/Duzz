﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC.Config
{
    class Settings
    {
        //---------------CONNECTION---------------//
        public static int CNC_PORT = 5860;

        //--------------CRYPTOGRAPHY--------------//

        public static string CONNECTION_ENCRYPTION_KEY = "123";
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        public static int CONNECTION_ENCRYPTION_KEYSIZE = 256;
        // This constant determines the number of iterations for the password bytes generation function.
        public static int CONNECTION_ENCRYPTION_DERIVACTION_ITERATIONS = 5000;
    }
}
