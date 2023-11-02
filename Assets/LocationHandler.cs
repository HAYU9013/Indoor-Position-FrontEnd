using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationHandler : MonoBehaviour
{
    MapHandler mapHandler;
    // Start is called before the first frame update
    void Start()
    {
        mapHandler = GameObject.Find("MapArea").GetComponent<MapHandler>();
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

    void getWifiMac() // ����n���g�줣�P�a��
    {
        // Debug.Log(gameObject.name + " been click");
        int num = int.Parse(gameObject.name.Split("_")[1]);
        mapHandler.haveLocationData[num] = true;
    }
}
