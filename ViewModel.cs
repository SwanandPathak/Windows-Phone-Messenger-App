using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MessengerApp.DataModel
{
    public class ViewModel
    {
        public string emailThisSession { get; set;}
        public string passwordThisSession { get; set;}
        public string firstNameThisSession { get; set; }
        public string lastNameThisSession { get; set; }
        public static ViewModel myViewModel { get; set; }
        public Msg msgs { get; set; }
        public User users { get; set; }
        public non_Observable allOther { get; set; }
        public Msg_check checkCall { get; set; }
        public location loc { get; set; }

        public ViewModel()
        {
            users = User.returnOneInstance();
            msgs = Msg.returnOneInstance();
            allOther = non_Observable.returnOneInstance();
            checkCall = Msg_check.returnOneInstance();
            loc = location.returnOneInstance();
        }

        public static ViewModel returnMyViewModel()
        {
            return myViewModel ?? (myViewModel = new ViewModel());                  // singleton
        }

        public async Task getUsers(string emailmain, string passwordmain, string firstname, string lastname)
        {
            await users.GetUser(emailmain,passwordmain,firstname,lastname);
        }

        public async Task<bool> getMsgs(string emailmain, string passwordmain)
        {
           return await msgs.getMessages(emailmain, passwordmain);
        }


        public async Task getAllLocations(string emailmain, string passwordmain)
        {
            await loc.getLocation(emailmain,passwordmain);
        }

        public async Task msgSend(string emailNow,string passwordNow,string msgSend,string toWhom)
        {
            await allOther.SendMessage(emailNow,passwordNow, msgSend, toWhom);
        }
        public async Task<bool> getMessages_check(string emailNow,string passwordNow)
        {
            return await checkCall.getMessages_check(emailNow, passwordNow);
        }
        public async Task<bool> accountCreate(string emailNow, string passwordNow, string firstNameNow, string lastNameNow)
        {
            return await allOther.CreateAccount(emailNow,passwordNow,firstNameNow,lastNameNow);
        }

        public async Task locSet(string emailNow, string passwordNow, string latNow, string longiNow, string accNow)
        {
            await allOther.setLocation(emailNow, passwordNow, latNow, longiNow, accNow);
        }

        public async Task delAccount(string emailNow, string passwordNow)
        {
            await allOther.deleteAccount(emailNow, passwordNow);
        }

     }
   
}
