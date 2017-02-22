using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;

namespace TVProgramChecker.Managers
{
    class VKManager
    {
        public void UploadPhoto()
        {
            
            string password = ""; // password for Vk page.
            ulong appId = 5888960;
            int groupId = -130518437;
            string email = ""; // email or number for Vk page.

            if (password.Length < 5 || email.Length < 5)
                throw new ArgumentException("Pasword and Email can not be less than 5 characters. Change it above.");
              
            Settings settings = Settings.All;

            var api = new VkApi();
            api.Authorize(new ApiAuthParams
            {
                ApplicationId = appId,
                Login = email,
                Password = password,
                Settings = settings
            });
            var wc = new WebClient();

            var getOwnerPhotoUploadServer = api.Photo.GetOwnerPhotoUploadServer(groupId);
            var response = Encoding.ASCII.GetString(wc.UploadFile(getOwnerPhotoUploadServer.UploadUrl, @"result.jpg"));
            var saveOwnerPhoto = api.Photo.SaveOwnerPhoto(response);

        }   
    }
}
