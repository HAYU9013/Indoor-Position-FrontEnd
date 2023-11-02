using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationHandler : MonoBehaviour
{
    MapHandler mapHandler;
    GetMacHandler getMacHandler;
    [System.Serializable]
    public class MacData
    {
        public int point;
        public List<string> macs;
    }

    // public List<MacData> MacList = new List<MacData>();
    
    // Start is called before the first frame update
    void Start()
    {
        mapHandler = GameObject.Find("MapArea").GetComponent<MapHandler>();
        getMacHandler = GameObject.Find("GetMac").GetComponent<GetMacHandler>();
        // Debug.Log(gameObject.name + " ready");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        getWifiMac();
        //Todo for getWifiMac * 10
        //Sendto Backend
    }

    void getWifiMac() // 之後要換寫到不同地方
    {
        // Debug.Log(gameObject.name + " been click");
        int num = int.Parse(gameObject.name.Split("_")[1]);
        mapHandler.haveLocationData[num] = true;
        /*
        MacData macData = new MacData();
        // Debug.Log("ret from exe: " + getMacHandler.ExecuteCommand());
        macData.macs = getMacHandler.ExecuteCommand();
        macData.point = num;

        string json = "" + JsonUtility.ToJson(macData);
        Debug.Log(json);
        */

    }
}
