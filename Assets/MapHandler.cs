using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour
{

    public List<GameObject> locationList = new List<GameObject>();
    public int target = 0;
    public float updateTime = 0.5f;
    float updateTimeDelta ;
    // Start is called before the first frame update
    void Start()
    {
        updateTimeDelta = updateTime;
        for (int i = 0; i < 100; i++)
        {
            GameObject temp = GameObject.Find("location" + i.ToString());
            locationList.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(updateTimeDelta < 0)
        {
            updateLocationVisiable();
            updateTimeDelta = updateTime;
        }
        else
        {
            updateTimeDelta -= Time.deltaTime;
        }

        
        
    }
    void updateLocationVisiable()
    {
        for (int i = 0; i < locationList.Count; i++)
        {
            if (!locationList[i]) continue;

            Color NoSeeColor = Color.white;
            Color CanSeeColor = Color.white;
            NoSeeColor.a = 0.1f; // 0~1
            if (locationList[i].name == "location" + target.ToString())
            {

                locationList[i].GetComponent<SpriteRenderer>().color = CanSeeColor;
            }
            else
            {
                print(locationList[i].name);
                locationList[i].GetComponent<SpriteRenderer>().color = NoSeeColor;
            }

        }
    }
}
