using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace martesbiblio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        private String apikey = "3028328cf7734aecb7217b2843daa5f0";
        private string access_token;
        List<DestinyMemberships> model = new List<DestinyMemberships>();
       
        public class DemoAPi
        {
            public string LastSeenDisplayName { get; set; }
            public int LastSeenDisplayNameType { get; set; }
            public string iconPath { get; set; }
            public int crossSaveOverride { get; set; }
            public List<int> applicableMembershipTypes { get; set; }
            public bool isPublic { get; set; }
            public int membershipType { get; set; }
            public string membershipId { get; set; }
            public string displayName { get; set; }
            public string bungieGlobalDisplayName { get; set; }
            public int bungieGlobalDisplayNameCode { get; set; }
            public int id { get; set; }
            public String title { get; set; }
        }

        public class DestinyMemberships
        {
            public string LastSeenDisplayName { get; set; }
            public int LastSeenDisplayNameType { get; set; }
            public string iconPath { get; set; }
            public int crossSaveOverride { get; set; }
            public List<int> applicableMembershipTypes { get; set; }
            public bool isPublic { get; set; }
            public int membershipType { get; set; }
            public string membershipId { get; set; }
            public string displayName { get; set; }
            public string bungieGlobalDisplayName { get; set; }
            public int bungieGlobalDisplayNameCode { get; set; }
        }

        public class BungieNetUser
        {
            public string membershipId { get; set; }
            public string uniqueName { get; set; }
            public string displayName { get; set; }
            public int profilePicture { get; set; }
            public int profileTheme { get; set; }
            public int userTitle { get; set; }
            public string successMessageFlags { get; set; }
            public bool isDeleted { get; set; }
            public string about { get; set; }
            public DateTime firstAccess { get; set; }
            public DateTime lastUpdate { get; set; }
            public string psnDisplayName { get; set; }
            public string xboxDisplayName { get; set; }
            public bool showActivity { get; set; }
            public string locale { get; set; }
            public bool localeInheritDefault { get; set; }
            public bool showGroupMessaging { get; set; }
            public string profilePicturePath { get; set; }
            public string profileThemeName { get; set; }
            public string userTitleDisplay { get; set; }
            public string statusText { get; set; }
            public DateTime statusDate { get; set; }
            public string blizzardDisplayName { get; set; }
            public string steamDisplayName { get; set; }
            public string stadiaDisplayName { get; set; }
            public string twitchDisplayName { get; set; }
            public string cachedBungieGlobalDisplayName { get; set; }
            public int cachedBungieGlobalDisplayNameCode { get; set; }
        }

        public class Response
        {
            public List<DestinyMembership> destinyMemberships { get; set; }
            public string primaryMembershipId { get; set; }
            public BungieNetUser bungieNetUser { get; set; }
        }

        public class MessageData
        {
        }

        public class Root
        {
            public Response Response { get; set; }
            public int ErrorCode { get; set; }
            public int ThrottleSeconds { get; set; }
            public string ErrorStatus { get; set; }
            public string Message { get; set; }
            public MessageData MessageData { get; set; }
        }

        public AboutPage()
        {
            InitializeComponent();
        }



        private async void Button_Clicked(object sender, EventArgs e)
        {
            //15xeHe48zBuEXtlyv5X0BA
            var request = new HttpRequestMessage();
            //request.RequestUri = new Uri("https://jsonplaceholder.typicode.com/posts");
            request.RequestUri = new Uri("https://www.bungie.net/Platform/User/GetMembershipsById/4611686018503579998/2/");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accpet", "application/json");
            request.Headers.Add("x-api-key", "3028328cf7734aecb7217b2843daa5f0");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<DestinyMembership>(content);
                //var resultado=JsonSerializer.Deserialize<DestinyMembership>(json)
                //JSONArray arr = resultado.getJSONArray();
                //File.WriteAllText(resultado);
                string json = content.ToString();
                var jsonobject = JObject.Parse(json);
                var id = jsonObject["membershipId"];
                var name = jsonObject["displayname"];
                var data = jsonObject["DestinyMemberships"];
                var jsonArray = JArray.Parse(data.ToString())

                foreach (var token in jsonArray)
                {

                    DestinyMemberships m = new DestinyMemberships();
                    string id = token["membershipID"];
                    string name = token["displayname"];
                    
                    m.displayName = id;
                    m.membershipId = name:
                    model.Add(m);



                }

                
                

                //vvar content = await response.Content.ReadAsStringAsync();

                


                //Mr. Mono will be added to the ListView because it uses an ObservableCollection
                //employees.Add(new Employee() { DisplayName = "Mr. Mono" });
                 

            }


         ListDemo.ItemsSource = model;
        }

       
    }
}