﻿using Aiursoft.Pylon.Exceptions;
using Aiursoft.Pylon.Models;
using Aiursoft.Pylon.Models.API;
using Aiursoft.Pylon.Models.API.ApiViewModels;
using Aiursoft.Pylon.Models.API.UserAddressModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aiursoft.Pylon.Services.ToAPIServer
{
    public class UserService
    {
        private readonly ServiceLocation _serviceLocation;
        private readonly HTTPService _http;

        public UserService(
            ServiceLocation serviceLocation,
            HTTPService http)
        {
            _serviceLocation = serviceLocation;
            _http = http;
        }

        public async Task<AiurProtocal> ChangeProfileAsync(string openId, string accessToken, string newNickName, string newIconAddress, string newBio)
        {
            var url = new AiurUrl(_serviceLocation.API, "User", "ChangeProfile", new ChangeProfileAddressModel
            {
                AccessToken = accessToken,
                OpenId = openId,
                NewNickName = newNickName,
                NewIconAddress = newIconAddress,
                NewBio = newBio
            });
            var result = await _http.Get(url);
            var JResult = JsonConvert.DeserializeObject<AiurProtocal>(result);

            if (JResult.Code != ErrorType.Success)
                throw new AiurUnexceptedResponse(JResult);
            return JResult;
        }

        public async Task<AiurProtocal> ChangePasswordAsync(string openId, string accessToken, string oldPassword, string newPassword)
        {
            var url = new AiurUrl(_serviceLocation.API, "User", "ChangePassword", new ChangePasswordAddressModel
            {
                AccessToken = accessToken,
                OpenId = openId,
                OldPassword = oldPassword,
                NewPassword = newPassword
            });
            var result = await _http.Get(url);
            var JResult = JsonConvert.DeserializeObject<AiurProtocal>(result);

            if (JResult.Code != ErrorType.Success && JResult.Code != ErrorType.WrongKey)
                throw new AiurUnexceptedResponse(JResult);
            return JResult;
        }

        public async Task<AiurValue<string>> ViewPhoneNumberAsync(string openId, string accessToken)
        {
            var url = new AiurUrl(_serviceLocation.API, "User", "ViewPhoneNumber", new ViewPhoneNumberAddressModel
            {
                AccessToken = accessToken,
                OpenId = openId
            });
            var result = await _http.Get(url);
            var JResult = JsonConvert.DeserializeObject<AiurValue<string>>(result);
            if (JResult.Code != ErrorType.Success)
                throw new AiurUnexceptedResponse(JResult);
            return JResult;
        }

        public async Task<AiurProtocal> SetPhoneNumberAsync(string penId, string accessToken, string phoneNumber)
        {
            var url = new AiurUrl(_serviceLocation.API, "User", "SetPhoneNumber", new SetPhoneNumberAddressModel
            {
                AccessToken = accessToken,
                OpenId = penId,
                Phone = phoneNumber
            });
            var result = await _http.Get(url);
            var JResult = JsonConvert.DeserializeObject<AiurProtocal>(result);
            if (JResult.Code != ErrorType.Success)
                throw new AiurUnexceptedResponse(JResult);
            return JResult;
        }

        public async Task<AiurCollection<AiurUserEmail>> ViewAllEmailsAsync(string accessToken, string openId)
        {
            var url = new AiurUrl(_serviceLocation.API, "User", "ViewAllEmails", new ViewAllEmailsAddressModel
            {
                AccessToken = accessToken,
                OpenId = openId
            });
            var result = await _http.Get(url);
            var JResult = JsonConvert.DeserializeObject<AiurCollection<AiurUserEmail>>(result);
            if (JResult.Code != ErrorType.Success)
                throw new AiurUnexceptedResponse(JResult);
            return JResult;
        }

        public async Task<AiurProtocal> SendConfirmationEmailAsync(string accessToken, string userId, string email)
        {
            var url = new AiurUrl(_serviceLocation.API, "User", "SendConfirmationEmail", new SendConfirmationEmailAddressModel
            {
                AccessToken = accessToken,
                Id = userId,
                Email = email
            });
            var result = await _http.Get(url);
            var jresult = JsonConvert.DeserializeObject<AiurProtocal>(result);
            return jresult;
        }
    }
}
