using Newtonsoft.Json;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml.Linq;
using System.Xml;

namespace TS_LRS.Utilities.Util
{
    public static class Util
    {
        public static string GetRandomNumber1()
        {
            Random r = new Random();
            int num1 = r.Next(1, 13);
            return num1.ToString();
        }
        public static string GetRandomNumber2()
        {
            Random r = new Random();
            int num2 = r.Next(0, 9);
            return num2.ToString();
        }

        public static string ModelToXMLGenerate(string Model, string Node, string Root)
        {
            XDocument doc;
            try
            {
                var node = JsonConvert.DeserializeXmlNode(Model, Node);
                Model = JsonConvert.SerializeObject(node);
                node = JsonConvert.DeserializeXmlNode(Model, Root);
                using (StringReader s = new StringReader(node.InnerXml.ToString()))
                {
                    doc = XDocument.Load(s);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return doc.ToString();
        }
        public static string JsonStringToXMLGenerate(string json, string Node, string Root)
        {
            XDocument doc;
            try
            {
                XNode node = JsonConvert.DeserializeXNode(json);
                XmlDocument xdoc = new XmlDocument();
                string xml = "<" + Root + "> " + node.ToString() + "</" + Root + "> ";
                using (StringReader s = new StringReader(xml))
                {
                    doc = XDocument.Load(s);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return doc.ToString();
        }

        public static string generatePassword()
        {

            int lenthofpass = 6;
            string allowedChars = "";
            //allowedChars = "a,c,d,e,f,g,h,i,n,o,p,q,r,s,t,u,x,y,z,";
            //allowedChars += "A,C,D,E,F,G,I,K,L,M,N,P,Q,R,S,T,U,V,X,Z,";
            allowedChars += "1,2,3,4,5,6,7,8,9,0";
            char[] sep =
        {
        ','
    };
            string[] arr = allowedChars.Split(sep);
            string passwordString = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < lenthofpass; i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                passwordString += temp;
            }

            return passwordString;

        }     

        public static string encryptedPasswod(string password)
        {
            byte[] encPwd = Encoding.UTF8.GetBytes(password);
            //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
            byte[] pp = sha1.ComputeHash(encPwd);
            // static string result =
            Encoding.UTF8.GetString(pp);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in pp)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        public static string hashGenerator(string Username, string sender_id, string message, string secure_key)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);
            byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
            //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
            byte[] sec_key = sha1.ComputeHash(genkey);
            StringBuilder sb1 = new StringBuilder();
            for (int i = 0; i < sec_key.Length; i++)
            {
                sb1.Append(sec_key[i].ToString("x2"));
            }
            return sb1.ToString();
        }
    }
}
