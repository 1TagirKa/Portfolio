using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Misc.Services.EmailSender;
using PortfolioNew.Models;
using IEmailService = NETCore.MailKit.Core.IEmailService;

namespace PortfolioNew.Controllers;

public class ContactMeController : Controller
{
    private IEmailService EmailSender;

    public ContactsController(IEmailService _emailSender)
    {
        EmailSender = _emailSender;
    }

    [HttpGet]
    // GET
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Contacts([FromForm] User userData)
    {

        var message = new Message(new string[] {"gmail.com"}, "Users Data",
            $"Email:{userData.Email}\nName:{userData.Name}\nSubject:{userData.Subject}\nMessage:\n{userData.Message}");
        await EmailSender.SendEmailAsync(message);
        return Ok();

    }
}