using EDSystems.Application.Interfaces;
using EDSystems.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace EDSystems.Persistence.Services
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _configuration;

        public SmsService(IConfiguration configuration) => _configuration = configuration;

        public void SendSmsToRecepient(SmsDetails smsDetails)
        {
            if (smsDetails.Status == 2)
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(_configuration["UrlSms"]);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                bool isPhoneValid = IsPhoneValid(smsDetails.PhoneNumber);
                string textno = "";

                switch (smsDetails.Status)
                {
                    case 2:
                        textno = "POSILKA: " + smsDetails.Code + "\nPrinyat na sklad Ethno Delivery\nhttps://ethno.asia/" + smsDetails.Code;
                        break;

                    case 26:
                        textno = "POSILKA: " + smsDetails.Code + "\nDostavlena poluchatelyu\nhttps://ethno.asia/" + smsDetails.Code;
                        break;

                    default:
                        textno = "POSILKA: " + smsDetails.Code + "\nDostavlena poluchatelyu\nhttps://ethno.asia/" + smsDetails.Code;
                        break;
                }
                if (isPhoneValid)
                {
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string myJsonRecepient = JsonSerializer.Serialize(new
                        {
                            login = _configuration["Login"],
                            pwd = _configuration["Password"],
                            CgPN = _configuration["CgPN"],
                            CdPN = smsDetails.PhoneNumber.Replace("+", string.Empty),
                            text = textno
                        });
                        streamWriter.Write(myJsonRecepient);
                    }
                    var response = (HttpWebResponse)httpWebRequest.GetResponse();

                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                    }
                }
            }
        }

        public bool IsPhoneValid(string phone)
        {
            try
            {
                if (string.IsNullOrEmpty(phone))
                    return false;
                string newPhone = phone.Replace("+", string.Empty);
                var r = new Regex(@"^998[8-9]{1}[012345789][0-9]{7}$");
                return r.IsMatch(newPhone);
            }
            catch (Exception exc)
            {
                byte[] bytes = Encoding.Default.GetBytes(exc.Message);
                string utf8_String = Encoding.UTF8.GetString(bytes);
                //Log4net quyaman
                throw;
            }
        }
    }
}