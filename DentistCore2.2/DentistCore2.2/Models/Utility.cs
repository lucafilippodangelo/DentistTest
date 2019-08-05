using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MailClassLibrary
{
    public static class Utility
    {
        public static bool SentMailTest()
        {


            //LD START MAIL SENDING
            string subject = "Appointment Confirmation Request";
            string urlAction = "An Url Action Received from controller";//Url.Action("ResetPasswordCustomReceive", "Account", new { rt = token }, "http").ToString();

            //RestorePasswordVM viewModelRestore = new RestorePasswordVM
            //{
            //    User = user,
            //    ResetLink = urlAction,
            //    ConfirmationCode = tokenCp
            //};

            //var composedMail = CustomMailRestoreManagement.CreateRestoreMail(viewModelRestore, this.ControllerContext);

            try
            {
                CustomJwt  CTR = new CustomJwt();
                CTR.Appointment = "";// LdDevWebApp.Models.Entities.Appointment.Id;
                CTR.DateTime = DateTime.Now.ToString();
                string toPass = JSONSerialize(CTR);
                //LD generate an encripted reset token
                var token = CustomSecurity.EncryptString(toPass, getUserCriptEncriptTokenString());

                ProcessMail.SendMail("info@lucadangelo.it", subject, "body content");//LD parm 1 -> user dest mail
            }
            catch (Exception ex)
            {
                //CustomLogErrorStoring.storeErrorLog(ex, "Account", "PResetPasswordCustom", true);
                //messageToView = "Error occured while sending email." + ex.Message;
                return false;
            }
            return true;
            //LD END MAIL SENDING
        }

        #region REGION JESON Encription/Decription METHODS TO MOVE IN A SPECIFIC CLASS

        private static string JSONSerialize(CustomJwt ctrObj)
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(CustomJwt));
            jsonSer.WriteObject(stream, ctrObj);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }

        private static CustomJwt JSONDesrilize(string JSONdata)
        {
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(CustomJwt));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(JSONdata));
            CustomJwt ctrObj = (CustomJwt)jsonSer.ReadObject(stream);
            return ctrObj;
        }

        public static string getUserCriptEncriptTokenString()
        {
            return "cod9ice#Per'Crip4tare@Speci(fico%Id*Uten£te:";
        }

        public static string getPasswordDoubleTokenCheck()
        {
            return "co%de^7To*h!Pa:@-ssADP09#oub~@~@leTo000))kenCeck";
        }

        #endregion
    }
}
