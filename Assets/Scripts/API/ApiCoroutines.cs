using System.Collections;
using System.Collections.Generic;
using HarayaLabs;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class ApiCoroutines : Singleton<ApiCoroutines>
{
    const int TIMEOUT = 5;

    public object JsonConvert { get; private set; }

    public IEnumerator GetRoomList(string site, RoomList roomList) {
        string 
            username = UserDetails.Instance.loginDetails.username,
            password = UserDetails.Instance.loginDetails.password;

        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        UnityWebRequest www =
            UnityWebRequest.Post("http://" + UserDetails.Instance.apiDetails.ip +
                "/" +
                UserDetails.Instance.apiDetails.api_site +
                site,
                form);
        www.timeout = TIMEOUT;
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            JsonConvert.PopulateObject(www.downloadHandler.text, roomList);
        }
        else
        {
            //JsonConvert.PopulateObject(www.downloadHandler.text, loginMessage);
        }
    }
}
