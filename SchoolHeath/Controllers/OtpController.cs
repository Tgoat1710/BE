using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolHealth.Models;
using SchoolHeath.Models;
using SchoolHeath.Services;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SchoolHeath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public OtpController(ApplicationDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendOtp([FromBody] string email)
        {
            // Sinh m? OTP 6 s?
            var otp = RandomNumberGenerator.GetInt32(100000, 999999).ToString();

            // Xóa OTP c? (n?u có)
            var oldOtp = await _context.OtpCodes.FirstOrDefaultAsync(x => x.Email == email);
            if (oldOtp != null)
            {
                _context.OtpCodes.Remove(oldOtp);
                await _context.SaveChangesAsync();
            }

            // Lýu OTP m?i
            var otpCode = new OtpCode
            {
                Email = email,
                Code = otp,
                Expiration = DateTime.UtcNow.AddMinutes(5)
            };
            _context.OtpCodes.Add(otpCode);
            await _context.SaveChangesAsync();

            // G?i email
            await _emailService.SendEmailAsync(email, "Your OTP Code", $"Your OTP code is: <b>{otp}</b>");

            return Ok("OTP sent");
        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyOtp([FromBody] OtpVerifyRequest request)
        {
            var otp = await _context.OtpCodes.FirstOrDefaultAsync(x => x.Email == request.Email && x.Code == request.Code);
            if (otp == null)
                return BadRequest("Invalid OTP");

            if (otp.Expiration < DateTime.UtcNow)
                return BadRequest("OTP expired");

            // Xóa OTP sau khi xác minh thành công
            _context.OtpCodes.Remove(otp);
            await _context.SaveChangesAsync();

            return Ok("OTP verified");
        }
    }

    public class OtpVerifyRequest
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
