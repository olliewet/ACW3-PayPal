using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Core;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;


namespace PaypalACW3.PayPal
{
    public class PayPalClient
    {
        // Place these static properties into a settings area.
        public static string SandboxClientId { get; set; } =
            "AYUMEewur6ChNqBT-8Rlq1c7PC2QX9rA8rVaUZ3Ntx6i8UQjQdMFgbNarkH9fY5IJ52CYps1pTNpIpyE";
        public static string SandboxClientSecret { get; set; } =
            "ELzS0lChwJNON4WUGQACxo6YrENgcAYUe2ABnowk0sQV7-0GslZ9ahDHg4LOTNf49rSs1twGYZpfurBq";

        public static string LiveClientId { get; set; } =
            "<alert>{PayPal LIVE Client Id}</alert>";
        public static string LiveClientSecret { get; set; } =
            "<alert>{PayPal LIVE Client Secret}</alert>";


        ///<summary>
        /// Set up PayPal environment with sandbox credentials.
        /// In production, use LiveEnvironment.
        ///</summary>
        public static PayPalEnvironment Environment()
        {
            return new SandboxEnvironment(SandboxClientId,
                SandboxClientSecret);
        }

        ///<summary>
        /// Returns PayPalHttpClient instance to invoke PayPal APIs.
        ///</summary>
        public static PayPalCheckoutSdk.Core.PayPalHttpClient Client()
        {
            return new PayPalHttpClient(Environment());
        }

        public static PayPalCheckoutSdk.Core.PayPalHttpClient Client(string refreshToken)
        {
            return new PayPalHttpClient(Environment(), refreshToken);
        }

        ///<summary>
        /// Use this method to serialize Object to a JSON string.
        ///</summary>
        public static String ObjectToJSONString(Object serializableObject)
        {
            MemoryStream memoryStream = new MemoryStream();
            var writer = JsonReaderWriterFactory.CreateJsonWriter(memoryStream,
                Encoding.UTF8,
                true,
                true,
                "  ");

            var ser = new DataContractJsonSerializer(serializableObject.GetType(),
                new DataContractJsonSerializerSettings
                {
                    UseSimpleDictionaryFormat = true
                });

            ser.WriteObject(writer,
                serializableObject);

            memoryStream.Position = 0;
            StreamReader sr = new StreamReader(memoryStream);

            return sr.ReadToEnd();
        }
    }
}
