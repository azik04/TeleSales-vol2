﻿namespace TeleSales.Mail;

public interface IEmailService
{ 
    Task SendEmailAsync(string to, string subject, string content);
}
