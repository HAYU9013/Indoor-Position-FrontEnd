using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    AndroidJavaObject androidLibrary;
    string tmp = " from unity";
    // Start is called before the first frame update
    void Start()
    {
        androidLibrary = new AndroidJavaObject("com.example.unitypluginswifi");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Add()
    {
        var result = androidLibrary.Call<string>("ADD", 5, 8);
        Debug.Log("result: " + result.ToString());
    }
    public void Toast()
    {
        Debug.Log("toast");
    }
}
