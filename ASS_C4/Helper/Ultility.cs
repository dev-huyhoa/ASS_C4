using System.Net.Mail;
using System.Net;
using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.IO;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
namespace ASS_C4.Helper
{
    public class Ultility
    {
        private const string CLOUD_NAME = "ddv2idi9d";
        private const string API_KEY = "687389283419199";
        private const string API_SECRET = "BOCNwD1_s-DwP67WIkwNkuURBtE";
        private static Cloudinary cloudinary;
        private static string publicId;
        private static string link;
        //up image to cloudinary
        public static string WriteFile(IFormFile file, string type, string idService)
        {
            int orderby = 1;
            var folder = Directory.GetCurrentDirectory() + @"\wwwroot";
            string path = Path.Combine(folder, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string pathType = Path.Combine(path, type);

            if (!Directory.Exists(pathType))
            {
                Directory.CreateDirectory(pathType);
            }

            string pathId = Path.Combine(pathType, idService.ToString());

            if (!Directory.Exists(pathId))
            {
                Directory.CreateDirectory(pathId);
            }
            var date = FormatDateToInt(DateTime.Now, "DDMMYYYY").ToString();

            string pathDate = Path.Combine(pathId, date);
            if (!Directory.Exists(pathDate))
            {
                Directory.CreateDirectory(pathDate);
            }
            //get file extension
            //string[] str = file.FileName.Split('.');
            string fileName = "";
            if (orderby > 0)
            {
                fileName = orderby.ToString() + "_" + FormatDateToInt(DateTime.Now, "DDMMYYYYHHMMSS").ToString() + Path.GetExtension(file.FileName);
            }
            else
            {
                fileName = FormatDateToInt(DateTime.Now, "DDMMYYYYHHMMSS").ToString() + Path.GetExtension(file.FileName);
            }
            string fullpath = Path.Combine(pathDate, fileName);
            string folderPath = "/Uploads/" + type + "/" + idService + "/" + date;
            string serverPath = "/Uploads/" + type + "/" + idService + "/" + date + "/" + fileName;
            if (Directory.Exists(fullpath))
            {
                System.IO.File.Delete(fullpath);

            }
            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            //up lên cloud
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);
            string imagePath = Path.GetFullPath(fullpath);
            return uploadImage(imagePath, folderPath);
        }

        public static string uploadImage(string filePath, string folderPath)
        {
            var uploadParams = new ImageUploadParams()
            {
                Folder = folderPath,
                File = new FileDescription(filePath),
                UseFilename = true
            };

            var uploadResult = cloudinary.Upload(uploadParams);
            publicId = $"lia/Folder/{uploadResult.PublicId}";
            return uploadResult.Uri.ToString();
        }
        public static long FormatDateToInt(DateTime datetime, string type)
        {
            var dateTimeNow = datetime;
            string year = dateTimeNow.Year.ToString();
            string month = dateTimeNow.Month.ToString();
            string day = dateTimeNow.Day.ToString();
            string hour = dateTimeNow.Hour.ToString();
            string mi = dateTimeNow.Minute.ToString();
            string sec = dateTimeNow.Second.ToString();
            try
            {
                if (type == "DDMMYYYY")
                {
                    //29/01/2001 
                    return int.Parse(year + month + day);
                }
                else if (type == "YYYYMMDD")
                {
                    //2001/01/29
                    return int.Parse(year + month + day);
                }
                else if (type == "YYYYMMDDHHMM")
                {
                    ////2001/01/29 23:12
                    return int.Parse(year + month + day + hour + mi);
                }
                else if (type == "DDMMYYYYHHMM")
                {
                    ////29/01/2001 23:12
                    return int.Parse(year + month + day + hour + mi);
                }
                else if (type == "YYYYMMDDHHMMSS")
                {
                    ////2001/01/29 23:12:12
                    return Int64.Parse(year + month + day + hour + mi + sec);
                }
                else
                {
                    ////29/01/2001 23:12:12
                    return Int64.Parse(year + month + day + hour + mi + sec);
                }
            }
            catch (Exception)
            {
                return 1;
            }
        }


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
