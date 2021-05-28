using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDetails : Singleton<UserDetails>
{
    public class LoginDetails
    {
        private string _username;
        public string username
        {
            get
            {
                return _username;
            }
        }
        private string _password;
        public string password
        {
            get
            {
                return _password;
            }
        }
        public void Login(string username, string password)
        {
            _username = username;
            _password = password;
        }
    }

    public class APIDetails
    {
        private string _api_site = "apis/public/";

        public string api_site
        {
            get
            {
                return _api_site;
            }
        }

        private string _ip = "staging.labs.haraya.io";

        public string ip
        {
            get
            {
                return _ip;
            }
        }
    }
    public LoginDetails loginDetails = new LoginDetails();
    public APIDetails apiDetails = new APIDetails();
}
