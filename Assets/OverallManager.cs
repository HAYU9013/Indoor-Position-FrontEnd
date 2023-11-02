using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallManager : MonoBehaviour
{
    public int pressCnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressButtonTest()
    {
        pressCnt++;
        Debug.Log(pressCnt);
    }
}
