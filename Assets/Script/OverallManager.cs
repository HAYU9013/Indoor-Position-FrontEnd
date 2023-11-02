using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        mapHandler.isCreating = !mapHandler.isCreating;
    }
}
