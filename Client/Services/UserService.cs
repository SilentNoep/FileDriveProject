using Client.Infra;
using Common;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class UserService : IUserService
    {
        
        public string BaseUri;
        public UserService()
        {
            BaseUri = "https://localhost:44339/api/user";
        }
        public async Task<User> Register(User user)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{BaseUri}/register", content);
                    var result = await response.Content.ReadAsStringAsync();
                    var UserFromDB = JsonConvert.DeserializeObject<User>(result);
                    if (response.IsSuccessStatusCode == true)
                        return UserFromDB;
                    return null;
                }
                catch(Exception)
                {
                    return null;
                }
            }
        }

        public async Task<User> SignIn(User user)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    var response = client.PostAsync($"{BaseUri}/logIn", content).Result;
                    var result = await response.Content.ReadAsStringAsync();
                    var UserFromDB = JsonConvert.DeserializeObject<User>(result);
                    if (response.IsSuccessStatusCode == true)
                        return UserFromDB;
                    return null;
                }
                catch(Exception)

                {
                    return null;
                }
      
            }
        }
        
    }
}
