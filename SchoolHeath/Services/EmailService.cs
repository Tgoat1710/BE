using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SchoolHeath.Services
{
    // Cấu hình từ appsettings.json
    public class EmailSettings
    {
        public string SmtpServer { get; set; }       // smtp.gmail.com
        public int Port { get; set; }                // 587
        public string SenderName { get; set; }       // Tên hiển thị
        public string SenderEmail { get; set; }      // Email gửi
        public string Username { get; set; }         // Email đăng nhập
        public string Password { get; set; }         // Mật khẩu ứng dụng (App Password)
    }

    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value; // Lấy config từ appsettings.json
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MailMessage();
            message.From = new MailAddress(_settings.SenderEmail, _settings.SenderName);
            message.To.Add(toEmail);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using var client = new SmtpClient(_settings.SmtpServer, _settings.Port)
            {
                Credentials = new NetworkCredential(_settings.Username, _settings.Password),
                EnableSsl = true
            };

            await client.SendMailAsync(message);
        }
    }
}
