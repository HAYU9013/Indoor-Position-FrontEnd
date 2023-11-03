using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.NetworkInformation;
using System;
using UnityEngine.Networking;


public class OverallManager : MonoBehaviour
{
    MapHandler mapHandler;

    public int pressCnt = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        mapHandler = GameObject.Find("MapArea").GetComponent<MapHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressButtonTest() // testing button
    {
        
        pressCnt++;
        string printText = " hello world";
        Debug.Log(pressCnt.ToString() + printText);
        mapHandler.isCreating = !mapHandler.isCreating;
    }

    public void postData(string jsonData, string url)
    {
        StartCoroutine(Upload(jsonData, url));   
    }
     IEnumerator Upload(string jsonData, string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(url , jsonData))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
                string responseText = www.downloadHandler.text; // 获取后端返回的数据
                Debug.Log("Response: " + responseText);
            }
        }
        /*
        print("uploading...");
        print(url);
        print(jsonData);

        UnityWebRequest request = new UnityWebRequest(url, "POST");

        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonData);

        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            string jsonResponse = request.downloadHandler.text;
            Debug.LogWarning("Response: " + jsonResponse);

            // 在这里你可以对响应数据进行进一步处理
        }

        */
    }


}
