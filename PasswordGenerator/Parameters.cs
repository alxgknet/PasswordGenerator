using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public class Parameters
    {

        public Parameters()
        {
            lengthOfPassword = 32;//default
            useSpecialCharacter = false;
        }
        public string webSiteName { get; set; }
        public string userName { get; set; }
        public string keyValue { get; set; }
        public int lengthOfPassword { get; set; }
        public bool useSpecialCharacter { get; set; }

        public string ConcatenatedValue
        {
            get
            {
                string result = string.Format("{0}{1}{2}", webSiteName, userName, keyValue);
                if (result == null || result.Length == 0)//default password if no parameters
                    result = string.Format("no parameters");

                return result;
            }
        }

        public string getAdjustedString(string result)
        {
            string startChars = "St";
            if (webSiteName != null && webSiteName.Length > 0)
            {
                string[] web = webSiteName.Split('.');
                if (web.Length > 2)
                {
                    if (web[1].Length >= 2)
                    {
                        startChars = web[1].Substring(0, 1).ToUpper();
                        startChars += web[1].Substring(1, 1).ToLower();
                    }
                }
            }



            if (useSpecialCharacter)
                lengthOfPassword--;
            if (startChars.Length > 0)
                lengthOfPassword -= startChars.Length;


            if (lengthOfPassword < result.Length)
                result = result.Substring(0, lengthOfPassword);
            else
            {
                while (result.Length < lengthOfPassword)
                {
                    result += "0";
                }
            }

            if (useSpecialCharacter)
                result += "$";


            result = result.ToLower();
            result = startChars + result;
            return result;
        }
        public override string ToString()
        {
            return string.Format("webSiteName={0}\nuserName={1}\nkeyValue={2}\nlengthOfPassword={3}\nuseSpecialCharacter={4}\n", webSiteName, userName, keyValue, lengthOfPassword, useSpecialCharacter);
        }
    }
}
