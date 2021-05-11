﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using igxFormFieldsToolbar.MembershipService;

namespace igxFormFieldsToolbar.Controllers
{
    class UserAuthController
    {
        public static List<string> getMembershipProviders(UserAuthInput authInput)
        {
            List<string> membershipProviders = new List<string>();

            string cmsURL = "bdsandbox";
            WSHttpBinding httpBinding = new WSHttpBinding(SecurityMode.None);
            EndpointAddress endpoint = new EndpointAddress($"http://{cmsURL}/soap/MembershipProvidersServices.svc");
            httpBinding.MaxReceivedMessageSize = 2147483647;

            string token = string.Empty;
            using (MembershipProvidersServicesClient mservice = new MembershipProvidersServicesClient(httpBinding, endpoint))
            {
                token = mservice.Login(authInput.username, authInput.password, authInput.membershipProvier).message;
                var response = mservice.GetMembershipProviders().message.Providers.ToArray();
                
                foreach (KeyValuePairOfstringMembershipProviderChoiceO5HAFep4 provider in response)
                {
                    membershipProviders.Add(provider.value.displayName);
                }
            }

            return membershipProviders;
        }
    }
}
