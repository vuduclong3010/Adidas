using AdidasModels.Solution.DTO;
using AdidasModels.Solution.DTO.Appsetting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AdidasModels.Solution.Common
{
    public class MailHelper
    {
        private readonly Appsettings _appSettings;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MailHelper(IOptionsSnapshot<Appsettings> appSettings, IWebHostEnvironment webHostEnvironment)
        {
            _appSettings = appSettings.Value;
            _webHostEnvironment = webHostEnvironment;
        }
        public bool SendMail(SendMailViewModel model)
        {
            var FromEmailAddress = _appSettings.FromEmailAddress;
            var FromEmailPassword = _appSettings.FromEmailPassword;
            var FromEmailDisplayName = _appSettings.FromEmailDisplayName;
            var SMTPHost = _appSettings.SMTPHost;
            var SMTPPort = _appSettings.SMTPPort;
            var EnabledSSL = _appSettings.EnabledSSL;
            try
            {
                using (MailMessage mail = new MailMessage(FromEmailAddress, model.To))
                {
                    mail.Subject = FromEmailDisplayName;
                    AlternateView view = AlternateView.CreateAlternateViewFromString(PopulateBody("hihi"), null, "text/html");
                    LinkedResource resource = new LinkedResource(Path.Combine(_webHostEnvironment.WebRootPath, "user-content", "20c28b85-16a4-4d67-961c-758e6762eba4.jpg"));
                    resource.ContentId = "imgpath";
                    view.LinkedResources.Add(resource);
                    mail.AlternateViews.Add(view);
                    mail.Body = resource.ContentId;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient
                    {
                        Host = SMTPHost,
                        EnableSsl = bool.Parse(EnabledSSL),
                        Port = int.Parse(SMTPPort)
                    };
                    NetworkCredential networkCredential = new NetworkCredential(FromEmailAddress, FromEmailPassword);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Send(mail);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string PopulateBody(string message)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine("Content", "Template", "EmailPage.html")))
            {
                body = reader.ReadToEnd();
                body = body.Replace("{message}", message);
            }
            return body;
        }

        public static void MailLog(Exception ex)
        {
            string lines = "Error occured at " + DateTime.Now.ToString("MM/dd/yyyy h:mm tt") + "\r\n";
            lines += "****************************************************************** \r\n";
            lines += "StackTrace: " + ex.StackTrace?.ToString() + " \r\n";
            lines += "ErrorMessage: " + ex.Message?.ToString() + " \r\n";
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Mail Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\Mail Logs\\" + "MailLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + "_" + DateTime.Now.Ticks.ToString() + ".txt";
            if (!System.IO.File.Exists(filePath))
            {
                using (StreamWriter sw = System.IO.File.CreateText(filePath))
                {
                    sw.WriteLine(lines);
                }
            }
            else
            {
                using (StreamWriter sw = System.IO.File.AppendText(filePath))
                {
                    sw.WriteLine(lines);
                }
            }
        }
    }
}
