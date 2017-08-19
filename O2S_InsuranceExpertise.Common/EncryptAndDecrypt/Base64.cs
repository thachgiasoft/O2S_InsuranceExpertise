using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Common.EncryptAndDecrypt
{
    public class Base64
    {
        /// <summary>
        /// Ma Hoa
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Base64Encode(string plainText)
        {
            string result = "";
            try
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                return System.Convert.ToBase64String(plainTextBytes);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Fatal(ex);
            }
            return result;
        }

        /// <summary>
        /// Giai ma
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        public static string Base64Decode(string base64EncodedData)
        {
            string result = "";
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Fatal(ex);
            }
            return result;
        }

    }
}
