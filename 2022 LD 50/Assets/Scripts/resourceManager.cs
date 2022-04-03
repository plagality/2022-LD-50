using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resourceManager : MonoBehaviour
{
    
    private float resources;
    public Text resourcesText;

    // Start is called before the first frame update
    void Start()
    {
        resources = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        resourcesText.text = "resources: " + resources;
    }

    public void addResource(float add) {
        resources += add;
        Debug.Log("resources changed");
    }
}
