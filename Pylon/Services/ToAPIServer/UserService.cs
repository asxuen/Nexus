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
        public readonly ServiceLocation _serviceLocation;
        public UserService(ServiceLocation serviceLocation)
        {
            _serviceLocation = serviceLocation;
        }

        public async Task<AiurProtocal> ChangeProfileAsync(string openId, string accessToken, string newNickName, string newIconAddress, string newBio)
        {
            var HTTPContainer = new HTTPService();
            var url = new AiurUrl(_serviceLocation.API, "User", "ChangeProfile", new ChangeProfileAddressModel
            {
                AccessToken = accessToken,
                OpenId = openId,
                NewNickName = newNickName,
                NewIconAddress = newIconAddress,
                NewBio = newBio
            });
            var result = await HTTPContainer.Get(url);
            var JResult = JsonConvert.DeserializeObject<AiurProtocal>(result);

            if (JResult.Code != ErrorType.Success)
                throw new AiurUnexceptedResponse(JResult);
            return JResult;
        }

        public async Task<AiurProtocal> ChangePasswordAsync(string openId, string accessToken, string oldPassword, string newPassword)
        {
            var HTTPContainer = new HTTPService();
            var url = new AiurUrl(_serviceLocation.API, "User", "ChangePassword", new ChangePasswordAddressModel
            {
                AccessToken = accessToken,
                OpenId = openId,
                OldPassword = oldPassword,
                NewPassword = newPassword
            });
            var result = await HTTPContainer.Get(url);
            var JResult = JsonConvert.DeserializeObject<AiurProtocal>(result);

            if (JResult.Code != ErrorType.Success && JResult.Code != ErrorType.WrongKey)
                throw new AiurUnexceptedResponse(JResult);
            return JResult;
        }

        public async Task<AiurValue<string>> ViewPhoneNumberAsync(string openId, string accessToken)
        {
            var HTTPContainer = new HTTPService();
            var url = new AiurUrl(_serviceLocation.API, "User", "ViewPhoneNumber", new ViewPhoneNumberAddressModel
            {
                AccessToken = accessToken,
                OpenId = openId
            });
            var result = await HTTPContainer.Get(url);
            var JResult = JsonConvert.DeserializeObject<AiurValue<string>>(result);
            if (JResult.Code != ErrorType.Success)
                throw new AiurUnexceptedResponse(JResult);
            return JResult;
        }

        public async Task<AiurProtocal> SetPhoneNumberAsync(string penId, string accessToken, string phoneNumber)
        {
            var HTTPContainer = new HTTPService();
            var url = new AiurUrl(_serviceLocation.API, "User", "SetPhoneNumber", new SetPhoneNumberAddressModel
            {
                AccessToken = accessToken,
                OpenId = penId,
                Phone = phoneNumber
            });
            var result = await HTTPContainer.Get(url);
            var JResult = JsonConvert.DeserializeObject<AiurProtocal>(result);
            if (JResult.Code != ErrorType.Success)
                throw new AiurUnexceptedResponse(JResult);
            return JResult;
        }

        public async Task<AiurCollection<IUserEmail>> ViewAllEmailsAsync(string accessToken, string openId)
        {
            var HTTPContainer = new HTTPService();
            var url = new AiurUrl(_serviceLocation.API, "User", "ViewAllEmails", new ViewAllEmailsAddressModel
            {
                AccessToken = accessToken,
                OpenId = openId
            });
            var result = await HTTPContainer.Get(url);
            var JResult = JsonConvert.DeserializeObject<AiurCollection<IUserEmail>>(result);
            if (JResult.Code != ErrorType.Success)
                throw new AiurUnexceptedResponse(JResult);
            return JResult;
        }
    }
}