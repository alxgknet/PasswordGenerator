using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{



    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length==0)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("-w:<web site>");
                Console.WriteLine("-u:<user name>");
                Console.WriteLine("-k:<key value>");
                Console.WriteLine("-l:<length of password>");
                Console.WriteLine("-s:<y - use special charactar, n - don't use special character (default n - don't use)>");
                return;
            }

            Parameters parameter = new Parameters();

            foreach (string param in args)
            {
                string[] p = param.Split(':');
                switch(p[0])
                {
                    case "-w":
                        parameter.webSiteName = p[1];
                        break;
                    case "-u":
                        parameter.userName = p[1];
                        break;
                    case "-k":
                        parameter.keyValue = p[1];
                        break;
                    case "-l":
                        try
                        {
                            parameter.lengthOfPassword = Convert.ToInt16(p[1]);
                        }
                        catch(Exception x)
                        {
                            Console.WriteLine("length paramater must be a number!");
                        }
                        break;
                    case "-s":
                        if (p[1].ToLower() == "y")
                        {
                            parameter.useSpecialCharacter = true;
                        }
                        else
                            parameter.useSpecialCharacter = false;
                        break;
                    default:
                        Console.WriteLine("Unknown Parameter {0}", param);
                        break;
                }
            }
            Console.WriteLine("Collected parameters:\n{0}",parameter.ToString());

            string password = PassMaker.GetPassword(parameter);

            Console.WriteLine(password);
        }
    }
}
