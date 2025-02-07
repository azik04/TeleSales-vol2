using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace TeleSales.Mail;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtpSettings;

    public EmailService(IConfiguration config)
    {
        _smtpSettings = config.GetSection("SmptSettings").Get<SmtpSettings>();
    }
    public async Task SendEmailAsync(string to, string subject, string content)
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.Login));

        message.To.Add(MailboxAddress.Parse(to));

        message.Subject = subject;

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = content,
            TextBody = "This is a plain text version of the email content."
        };
        message.Body = bodyBuilder.ToMessageBody();

        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_smtpSettings.SmtpServer, _smtpSettings.Port, SecureSocketOptions.SslOnConnect);
            await client.AuthenticateAsync(_smtpSettings.Login, _smtpSettings.Password);
            await client.SendAsync(message);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"An error occurred while sending email: {ex.Message}", ex);
        }
        finally
        {
            await client.DisconnectAsync(true);
        }
    }
}
