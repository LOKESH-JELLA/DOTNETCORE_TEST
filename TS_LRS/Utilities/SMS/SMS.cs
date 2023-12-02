using System.Net;
using System.Text;
using System.Web;

using TS_LRS.Utilities.Util;

namespace TS_LRS.Utilities.SMS
{
    public class SMS
    {
        public static void SendSMS(string templateId, string smsText, string mobile, string senderId)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            // Create a request using a URL that can receive a post.
            WebRequest request = WebRequest.Create("https://api.imiconnect.in/resources/v1/messaging");
            // Set the Method property of the request to POST.
            request.Method = "POST";

            // Create POST data and convert it to a byte array.
            string postData = "{\"deliverychannel\":\"sms\",\"channels\":{	\"sms\":{\"type\":\"1\",\"senderid\":\"" + senderId + "\",\"text\":\"" + smsText + "\",\"extras\":{\"dlt_templateid\":\"" + templateId + "\"}}},\"destination\":[{\"msisdn\":[\"" + mobile + "\"],\"correlationid\":\"Test_API_Optional\"}]}";
            //"{\"deliverychannel\":\"sms\",\"channels\":{	\"sms\":{\"type\":\"1\",\"senderid\":\"TSMIVS\",\"text\":\"You Received a new Booking. Vehicle No:123 Customer Name:abc Booking ID:asas Delivery Location:asas Mndl: asas Customer Mobile:asass Alternate Mobile:2323 On 32dsd.\r\n Please confirm your acceptance for delivery by confirm in Mobile app or by giving missed call to : 343344 ,other wise it will be cancelled automatically after 60 minutes.\",\"extras\":{\"dlt_templateid\":\"1407159881304596148\"}}},\"destination\":[{\"msisdn\":[\"8374172949\"],\"correlationid\":\"Test_API_Optional\"}]}";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/json";
            request.Headers.Add("Key", "70871f87-dee3-11eb-9c5d-0abea36e3286");
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.


            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();

            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
            }

            // Close the response.
            response.Close();

        }

        public static string sendOTPMSG(string smsText, string mobile)
        {
            try
            {
                string url = "https://manage.smssolutions.in/smsapi/index?key=46511AD69B5FF4&campaign=0&routeid=6&type=text&contacts=" + mobile + "&senderid=RERATS&msg=" + smsText;

                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                StreamReader respStreamReader = new StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();
                myResp.Close();
                if (!string.IsNullOrEmpty(responseString))
                    return "success";
                else
                    return "fail";

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static string sendOTPMSGCgg(string templateid, string message, string mobileNo)
        {

            string username = "cgg-tsrerq";
            string password = "Tsrera@#2023";
            string secureKey = "b21463cc-b1f6-44e0-b652-58677b58d102";
            string senderid = "CGGHYD";

            string responseFromServer = "";

            // mobileNo = "8374172949";
            Stream dataStream;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; //forcing .Net framework to use TLSv1.2

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;

            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";

            request.Method = "POST";
            //System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();

            string encryptedPassword = Util.Util.encryptedPasswod(password);
            string key = Util.Util.hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());

            string smsservicetype = "otpmsg"; //For OTP message.

            string query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
                "&password=" + HttpUtility.UrlEncode(encryptedPassword) +

                "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +

                "&content=" + HttpUtility.UrlEncode(message.Trim()) +

                "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +

                "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
              "&key=" + HttpUtility.UrlEncode(key.Trim()) +
             "&templateid=" + HttpUtility.UrlEncode(templateid.Trim());



            byte[] byteArray = Encoding.ASCII.GetBytes(query);

            request.ContentType = "application/x-www-form-urlencoded";

            request.ContentLength = byteArray.Length;



            dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            WebResponse response = request.GetResponse();

            string Status = ((HttpWebResponse)response).StatusDescription;

            dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            responseFromServer = reader.ReadToEnd();

            reader.Close();

            dataStream.Close();

            response.Close();

            return responseFromServer;

        }
    }
}
