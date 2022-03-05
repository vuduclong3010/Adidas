using AdidasModels.Solution.DTO;
using AdidasModels.Solution.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdidasModels.Solution.Common;
using AdidasModels.Solution.DTO.Appsetting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using System.IO;
using System;
using AdidasModels.Solution;

namespace AdidasSolutionService
{
    public class OrderService : IOrderService
    {
        private readonly AdidasDbContext _context;
        private readonly Appsettings _appSettings;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public OrderService(AdidasDbContext context, IOptionsSnapshot<Appsettings> appSettings, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _appSettings = appSettings.Value;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<OrdersPaging> GetListOrders(OrderPagingRequest request)
        {
            var res = new List<OrderViewModel>();
            var query = await _context.Orders.Where(x => x.Deleted == 0).ToListAsync();
            if (request.ShipPhoneNumber != null)
            {
                query = await _context.Orders.Where(x => x.ShipPhoneNumber == request.ShipPhoneNumber && x.Deleted == 0).ToListAsync();
            }
            res = query.Select(g => new OrderViewModel
            {
                Id = g.Id,
                OrderDate = g.OrderDate,
                ShipName = g.ShipName,
                ShipAddress = g.ShipAddress,
                ShipEmail = g.ShipEmail,
                ShipPhoneNumber = g.ShipPhoneNumber,
                Status = g.Status
            }).Skip(request.PageSize * (request.PageIndex - 1))
                               .Take(request.PageSize).ToList();
            var totalItem = query.Count();
            return new OrdersPaging
            {
                Data = res,
                TotalItems = totalItem
            };
        }

        public async Task<IApiResult> SendMail(SendMailViewModel model)
        {
            var FromEmailAddress = "adidas.solution.mail@gmail.com";
            var FromEmailPassword = "123@123a";
            var FromEmailDisplayName = "Order Confirmation - Order";
            var SMTPHost = "smtp.gmail.com";
            var SMTPPort = 587;
            var EnabledSSL = true;
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
                        EnableSsl = EnabledSSL,
                        Port = SMTPPort
                    };
                    NetworkCredential networkCredential = new NetworkCredential(FromEmailAddress, FromEmailPassword);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Send(mail);
                }
                return ApiResult.Ok("Successfully to send mail");
            }
            catch (Exception ex)
            {
                return ApiResult.NotOk("Failed to send mail");
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
    }
}
