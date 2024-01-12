using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;


namespace BusinessLayer.Abstract
{
    public interface IEpostaService
    {
        Task EPostaGonder(EPostaBilgi ePostaBilgi);

    }

    public class EPostaService : IEpostaService
    {
        private readonly string senderadress = "l2012729008@isparta.edu.tr";
        public async Task EPostaGonder(EPostaBilgi ePostaBilgi)
        {
            var eposta = new MimeMessage();

            eposta.Sender = MailboxAddress.Parse(senderadress); 

            eposta.To.Add(MailboxAddress.Parse(ePostaBilgi.AlıcıAdres));
            eposta.Subject = "Şifre Sıfırlama Bağlantısı";

            var builder = new BodyBuilder();
            string link = ePostaBilgi.Link; 
            builder.HtmlBody = $"<p>Şifre sıfırlama bağlantısı için lütfen <a href='{link}'>TIKLAYINIZ</a>.</p>";

            eposta.Body = builder.ToMessageBody();

            eposta.Headers.Replace("from", senderadress);

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("eposta.isparta.edu.tr", 587, MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);

            await smtp.AuthenticateAsync("l2012729008@isparta.edu.tr", "31884234");

            await smtp.SendAsync(eposta);
            await smtp.DisconnectAsync(true);
        }

    }

}
