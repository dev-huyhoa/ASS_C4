using System.Net.Mail;
using System.Net;
using System;
using System.Text;

namespace ASS_C4.Helper
{
    public class Ultility
    {

        //Send mail
        public static void sendEmail(string htmlString, string toEmail, string mailSubject, string emailSend, string keySecurity)
        {
            try
            {
                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(emailSend);
                    message.To.Add(new MailAddress(toEmail));
                    message.Subject = mailSubject;
                    message.IsBodyHtml = true; //to make message body as html  
                    message.Body = htmlString;

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Port = 587;
                        smtp.Host = "smtp.gmail.com"; //for gmail host  
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("professional8778781@gmail.com", keySecurity);
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(message);
                    }

                }
            }
            catch (Exception)
            {

            }
        }



        public static long ConvertDatetimeToUnixTimeStampMiliSecond(DateTime date)
        {
            try
            {
                var dateTimeOffset = new DateTimeOffset(date);
                var unixDateTime = dateTimeOffset.ToUnixTimeMilliseconds();
                return unixDateTime;
            }
            catch
            {
                return 0;
            }

        }
    }
}
