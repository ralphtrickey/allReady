﻿using System.Threading.Tasks;
using AllReady.Areas.Admin.Features.Site;
using AllReady.Services;
using Moq;
using Xunit;

namespace AllReady.UnitTest.Areas.Admin.Features.Site
{
    public class SendResetPasswordEmailHandlerShould
    {
        [Fact]
        public async Task InvokeSendEmailAsyncWithTheCorrectParameters()
        {
            var message = new SendResetPasswordEmail { Email = "email", CallbackUrl = "callBackUrl" };
            var emailMessage = $"Please reset your password by clicking here: <a href=\"{message.CallbackUrl}\">link</a>";

            var emailSender = new Mock<IEmailSender>();
            var sut = new SendResetPasswordEmailHandler(emailSender.Object);
            await sut.Handle(message);

            emailSender.Verify(x => x.SendEmailAsync(message.Email, "Reset Password", emailMessage), Times.Once);
        }
    }
}
