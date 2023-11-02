﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    public bool isCreating = true;

    public GameObject mapArea;
    public GameObject locationPrefab; // the location pin prefab
    public float leftMost = -2f, rightMost = 2f; // the map position
    public float downMost = -2f, upMost = 2f;
    public float gridAmount = 5f; // how many point to show 


    public List<GameObject> locationList = new List<GameObject>();

    [SerializeField]
    public List<bool> haveLocationData = new List<bool>();

    public int maxLocationNumber = 0;
    
    
    public int target = -1; // the location to show out
    public float updateTime = 0.5f; // how soon to get current position
    float updateTimeDelta ;
    // Start is called before the first frame update
    void Start()
    {

        mapArea = GameObject.Find("MapArea");

        updateTimeDelta = updateTime;
        gridAmount--; // original will add one more
        initLocation();

        /* find the location when the map have already build
         * for (int i = 0; i < 100; i++)
        {
            // GameObject temp = GameObject.Find("location" + i.ToString());
            
            if (temp)
            {
                locationList.Add(temp);
                maxLocationNumber++;
            }
        }

        */
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

            Color NotHereColor = Color.white;
            Color IsHereColor = Color.white;
            Color BlackColor = Color.black;
            Color NoColor = Color.black;
            NotHereColor.a = 0.1f; // 0~1
            NoColor.a = 0f;

            if (isCreating) // 還沒有資料的設定黑色 有資料的設定彩色
            {
                if (haveLocationData[i])
                {
                    locationList[i].GetComponent<SpriteRenderer>().color = IsHereColor;
                }
                else
                {
                    
                    locationList[i].GetComponent<SpriteRenderer>().color = BlackColor;
                }
            }
            else // 正確點顯示白色 不是的顯示半透明
            {
                if (haveLocationData[i] == false)
                {
                    locationList[i].GetComponent<SpriteRenderer>().color = NoColor;
                }
                else if (locationList[i].name == "location_" + target.ToString())
                {
                    locationList[i].GetComponent<SpriteRenderer>().color = IsHereColor;
                    
                    
                }
                else
                {
                   
                    locationList[i].GetComponent<SpriteRenderer>().color = NotHereColor;
                    locationList[i].GetComponent<SpriteRenderer>().color = BlackColor; // 正式要註解掉
                }
            }
            

        }
    }

    void initLocation()
    {
        float gridLength = (rightMost - leftMost) / gridAmount;
        for (float i = leftMost; i <= rightMost; i += gridLength)
        {
            for(float j = downMost; j <= upMost; j += gridLength)
            {
                Vector3 tmpPos = new Vector3(i, j, 0);
                // 实例化Prefab物体
                GameObject newObject = Instantiate(locationPrefab, tmpPos, Quaternion.identity);
                newObject.transform.SetParent(mapArea.transform);
                newObject.transform.localScale *= 5 / gridAmount; // change scale according to the gridAmount

                newObject.name = "location_" + maxLocationNumber.ToString(); // 可能會出 bug
                
                maxLocationNumber++;
                locationList.Add(newObject);
                haveLocationData.Add(false);
            }
            
            
        }
    }

    public void SaveHaveData()
    {
        print("save data");
        string saveData = "";
        for(int i = 0; i < haveLocationData.Count; i++)
        {
            if (haveLocationData[i]) saveData += "1";
            else saveData += "0";

        }
        print("Save Data: " + saveData);
        PlayerPrefs.SetString("haveLocationData", saveData);
        PlayerPrefs.Save();
    }
    public void LoadHaveData()
    {
        print("load data");
        string saveData = PlayerPrefs.GetString("haveLocationData");
        print("Load Data: " + saveData);
        for (int i = 0; i < haveLocationData.Count; i++)
        {
            if (saveData[i] == '1') haveLocationData[i] = true;
            else haveLocationData[i] = false;

        }

        
    }

    public void ResetHaveData()
    {
        print("reset data");
        for (int i = 0; i < haveLocationData.Count; i++)
        {
            haveLocationData[i] = false;
        }
        SaveHaveData();
        LoadHaveData();

    }
    

}