using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class GameResult
{
    public string UserName;
    public int Score;
}
public class WepTest : MonoBehaviour
{
    string _baseUrl = "https://localhost:44302/api";
    // Start is called before the first frame update
    void Start()
    {
        GameResult gameResult = new GameResult()
        {
            UserName = "NoJi",
            Score = 3201
        };

        SendPostWebRequest("ranking", gameResult, (uwr) =>
          {
              Debug.Log("TODO : UI �����ϱ�");
          });

        SendGetAllRequest("ranking", (uwr) =>
        {
            Debug.Log("TODO : UI �����ϱ�");
        });
    }

    public void SendPostWebRequest(string url, object obj, Action<UnityWebRequest> callback)
    {
        StartCoroutine(CoSendWebRequest(url, "POST", obj, callback));
    }
    public void SendGetAllRequest(string url, Action<UnityWebRequest> callback)
    {
        StartCoroutine(CoSendWebRequest(url, "GET", null, callback));
    }
    IEnumerator CoSendWebRequest(string url, string method, object obj, Action<UnityWebRequest> callback)
    {
        string sendUrl = $"{_baseUrl}/{url}/";

        byte[] jsonBytes = null;
        if (obj != null)
        {
            string jsonStr = JsonUtility.ToJson(obj);
            jsonBytes = Encoding.UTF8.GetBytes(jsonStr);
        }

        var uwr = new UnityWebRequest(sendUrl, method);
        uwr.uploadHandler = new UploadHandlerRaw(jsonBytes);
        uwr.downloadHandler = new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError || uwr.isHttpError)
            Debug.Log(uwr.error);
        else
        {
            Debug.Log("Recv" + uwr.downloadHandler.text);

            callback.Invoke(uwr);
        }

    }
}
