using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.NetworkInformation;
using System;


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

    public void pressButtonTest()
    {
        pressCnt++;
        string printText = " hello world";
        Debug.Log(pressCnt.ToString() + printText);
        getWifiMac();
        // mapHandler.isCreating = !mapHandler.isCreating;




    }
    public void getWifiMac()
    {
        NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

        foreach (NetworkInterface networkInterface in networkInterfaces)
        {
            Debug.Log("getting wifi");
            if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
            {
                // 这是WiFi接口
                PhysicalAddress macAddress = networkInterface.GetPhysicalAddress();
                string macAddressString = BitConverter.ToString(macAddress.GetAddressBytes());
                string interfaceName = networkInterface.Name;

                // 输出MAC地址和接口名称
                Debug.Log("MAC地址: " + macAddressString);
                Debug.Log("接口名称: " + interfaceName);

                // 你可以继续在这里添加位置信息的获取代码
            }
        }
    }
}
