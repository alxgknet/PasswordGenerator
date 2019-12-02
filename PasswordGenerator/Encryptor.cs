﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/*
Code is simar to the found on the page:
https://www.godo.dev/tutorials/csharp-md5/
*/

namespace PasswordGenerator
{
    class Encryptor
    {
        static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create(); 
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }


}
