using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Web.Http;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;



namespace MessengerApp.DataModel
{
    
    public class AMsg
    {

        [JsonProperty(PropertyName = "message_id")]
        public string MessageID { get; set; }

        [JsonProperty(PropertyName = "msg_type")]
        public string MessageType { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "ts")]
        public string TimeStamp { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public string lat { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public string longi { get; set; }

        [JsonProperty(PropertyName = "accuracy")]
        public string acc { get; set; }






    }
    
    public class Msg : ObservableCollection<AMsg>
    {
        private static Msg message;

        private Msg()
        {

        }

        public static Msg returnOneInstance()
        {
            return (message ?? (message = new Msg()));              // Singleton 
        }

        public override string ToString()
        {
            return "" + message + " ";
        }

        public async Task<bool> getMessages(string emailmain,string passwordmain)
        {

            var httpclient = new System.Net.Http.HttpClient(new HttpClientHandler());
            var response = await httpclient.GetAsync("http://www.cs.rit.edu/~jsb/2135/ProgSkills/Labs/Messenger/api.php?command=getMessages&email=" + emailmain + "&password=" + passwordmain);
            string result = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine("result= " + result);

            if (response.IsSuccessStatusCode == false)
            {
                throw new HttpRequestException(((int)response.StatusCode).ToString());
            }
           
            ClearItems();
            
            foreach (var message in JsonConvert.DeserializeObject<List<AMsg>>(await response.Content.ReadAsStringAsync()))
            {
                Add(message);
            }
            if (result.Equals("Invalid user"))
                return false;                                   // if invalid user return false
            else
                return true;                                    // else return true
          
         


        }
    }
    public class Msg_check : ObservableCollection<AMsg>
    {
        private static Msg_check message;

        private Msg_check()
        {

        }

        public static Msg_check returnOneInstance()
        {
            return (message ?? (message = new Msg_check()));            //singleton
        }

        public override string ToString()
        {
            return "" + message + " ";
        }

        public async Task<bool> getMessages_check(string emailmain, string passwordmain)
        {
            var httpclient = new System.Net.Http.HttpClient(new HttpClientHandler());
            var response = await httpclient.GetAsync("http://www.cs.rit.edu/~jsb/2135/ProgSkills/Labs/Messenger/api.php?command=getUsers&email=" + emailmain + "&password=" + passwordmain);
            string result = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine("result= " + result);

            if (response.IsSuccessStatusCode == false)
            {
                throw new HttpRequestException(((int)response.StatusCode).ToString());
            }
            if (result.Equals("Invalid user"))
                return false;
            else
                return true;

       }
    }

    public class User : ObservableCollection<AMsg>
    {
        private static User user;

        private User()
        {

        }
        public static User returnOneInstance()
        {
            return (user ?? (user = new User()));                   //singleton
        }
        public override string ToString()
        {
            return "" + user + "";
        }
        public async Task GetUser(string emailmain, string passwordmain, string firstname, string lastname)
        {
            var httpclient = new System.Net.Http.HttpClient(new HttpClientHandler());
            var response = await httpclient.GetAsync("http://www.cs.rit.edu/~jsb/2135/ProgSkills/Labs/Messenger/api.php?command=getUsers&email=" + emailmain + "&password=" + passwordmain+"&first_name="+firstname+"&last_name="+lastname);
            System.Diagnostics.Debug.WriteLine("email==" + emailmain + " password" + passwordmain);
            string result = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine("result= " + result);

            if (response.IsSuccessStatusCode == false)
            {
                throw new HttpRequestException(((int)response.StatusCode).ToString());
            }
            ClearItems();

            foreach (var user in JsonConvert.DeserializeObject<List<AMsg>>(await response.Content.ReadAsStringAsync()))
            {

                Add(user);
            }
          

        }
    }

    public class location : ObservableCollection<AMsg>
    {
        public static List<string> listLatitude = new List<string>();
        public static List<string> listLongitude = new List<string>();
        public static List<string> listName = new List<string>();
        private static location Location;
        
        private location()
        {

        }
        public static location returnOneInstance()
        {
            return (Location ?? (Location = new location()));               //singleton
        }
        public override string ToString()
        {
            return " " + Location + " ";
        }

        public async Task getLocation(string emailmain, string passwordmain)
        {
           
            var httpclient = new System.Net.Http.HttpClient(new HttpClientHandler());
            var response = await httpclient.GetAsync("http://www.cs.rit.edu/~jsb/2135/ProgSkills/Labs/Messenger/api.php?command=getLocations&email=" + emailmain + "&password=" + passwordmain);
            System.Diagnostics.Debug.WriteLine("email==" + emailmain + " password" + passwordmain);
            string result = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine("result= " + result);
            
            if (response.IsSuccessStatusCode == false)
            {
                throw new HttpRequestException(((int)response.StatusCode).ToString());
            }
            ClearItems();

            foreach (var user in JsonConvert.DeserializeObject<List<AMsg>>(await response.Content.ReadAsStringAsync()))
            {
                listLatitude.Add(user.lat);
                listLongitude.Add(user.longi);
                listName.Add(user.FirstName);
                Add(user);
            }

        }
    }
    // class with all non-observable methods
    public class non_Observable
    {
         private static non_Observable nonob;

        private non_Observable()
        {

        }
        public static non_Observable returnOneInstance()
        {
            return (nonob ?? (nonob = new non_Observable()));
        }
        public async Task SendMessage(string nowEmail,string nowPassword,string Mesg, string to)
        {
            var httpclient = new System.Net.Http.HttpClient(new HttpClientHandler());
            var response = await httpclient.GetAsync("http://www.cs.rit.edu/~jsb/2135/ProgSkills/Labs/Messenger/api.php?command=sendMessage&email="+nowEmail+"&password="+nowPassword+"&to=" + to + "&message=" + Mesg);
            if (response.IsSuccessStatusCode == false)
            {
                throw new HttpRequestException(((int)response.StatusCode).ToString());
            }

        }

        public async Task<bool> CreateAccount(string email, string password, string firstName, string lastName)
        {

        
            var httpclient = new System.Net.Http.HttpClient(new HttpClientHandler());
            var response = await httpclient.GetAsync("http://www.cs.rit.edu/~jsb/2135/ProgSkills/Labs/Messenger/api.php?command=createAccount&email=" + email + "&password=" + password + "&first_name=" + firstName + "&last_name=" + lastName);
            System.Diagnostics.Debug.WriteLine("email==" + email + " password" + password);
            // System.Diagnostics.Debug.WriteLine("boolean ===" + response.IsSuccessStatusCode);
            string result = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine("result= " + result);

            if (response.IsSuccessStatusCode == false)
            {
                throw new HttpRequestException(((int)response.StatusCode).ToString());
            }
            if (result.Equals("Account Created"))
                return true;
            else
                return false;


        }
        public async Task setLocation(string email, string password, string lat, string longi, string acc)
        {

            var httpclient = new System.Net.Http.HttpClient(new HttpClientHandler());
            var response = await httpclient.GetAsync("http://www.cs.rit.edu/~jsb/2135/ProgSkills/Labs/Messenger/api.php?command=setLocation&email=" + email + "&password=" + password + "&lat=" + lat + "&long=" + longi + "&acc=" + acc);
            if (response.IsSuccessStatusCode == false)
            {
                throw new HttpRequestException(((int)response.StatusCode).ToString());
            }
        }

        public async Task deleteAccount(string email, string password)
        {
            var httpclient = new System.Net.Http.HttpClient(new HttpClientHandler());
            var response = await httpclient.GetAsync("http://www.cs.rit.edu/~jsb/2135/ProgSkills/Labs/Messenger/api.php?command=deleteAccount&email=" + email + "&password=" + password);
            if (response.IsSuccessStatusCode == false)
            {
                throw new HttpRequestException(((int)response.StatusCode).ToString());
            }
        }

    }
           
        
    
       
    }
    

