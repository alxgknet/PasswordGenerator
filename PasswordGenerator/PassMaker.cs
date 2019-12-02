using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public class PassMaker
    {
        public static string GetPassword(Parameters parameter)
        {
            if (parameter.lengthOfPassword < 3)
                throw new Exception("lengthOfPassword must be greater than 3");

            string password = string.Empty;
            Encryptor enc = new Encryptor();
            if (parameter.ConcatenatedValue.Length>0)
                password = enc.GetHashString(parameter.ConcatenatedValue);

            return parameter.getAdjustedString(password);
        }
    }
}
