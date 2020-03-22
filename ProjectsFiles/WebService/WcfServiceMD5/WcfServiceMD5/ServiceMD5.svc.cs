using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceMD5
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IServiceMD5
    {      
        /// <summary>
        /// פעולה לקבלת הסיסמא בהצפנה
        /// </summary>      
        /// <param name="password">סיסמא להצפנה</param>
        /// <returns>MD5 hash
        /// של אותה סיסמא</returns>
        public string GetMd5Hash(string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }


        /// <summary>
        /// פעולה לקבלת הסיסמא בהצפנה
        /// </summary>
        /// <param name="md5Hash">מחלקת שמטלפת באופן ההצפנה</param>
        /// <param name="password">סיסמא להצפנה</param>
        /// <returns>MD5 hash
        /// של אותה סיסמא</returns>
        public  string GetMd5HashWithMD5Hash(MD5 md5Hash, string password)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();

        }


        /// <summary>
        /// פעולה לבדיקה אם הסיסמא שהתקבלה שווה להש של התקבל
        /// </summary>
        /// <param name="password">הסיסמא הרגילה</param>
        /// <param name="hashedPassword">הסיסמא המוצפנת</param>
        /// <returns>אמת אם הסיסמא המוצפנת היא שווה לסיסמא הרגילה</returns>
        public  bool VerifyMd5Hash(string password, string hashedPassword)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Hash the input.
                string hashOfInput = GetMd5HashWithMD5Hash(md5Hash,password);

                // Create a StringComparer an compare the hashes.
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                return (0 == comparer.Compare(hashOfInput, hashedPassword));
            }

        }
    }
}
