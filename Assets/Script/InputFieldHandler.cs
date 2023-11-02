using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldHandler : MonoBehaviour
{

    public GameObject mapArea;
    // Start is called before the first frame update
    void Start()
    {
        mapArea = GameObject.Find("MapArea");
    }

    // Update is called once per frame
    void Update()
    {

        var input = gameObject.GetComponent<InputField>();
        input.onEndEdit.AddListener(SubmitName);

    }

    private void SubmitName(string arg0)
    {
        // Debug.Log(arg0);
        mapArea.GetComponent<MapHandler>().target = int.Parse(arg0); ;
    }
}
