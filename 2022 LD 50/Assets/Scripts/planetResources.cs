using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetResources : MonoBehaviour
{

    private double nextUpdate = 0.5;

    public GameObject ui;
    resourceManager text;

    public PlanetManager manager;

    // Start is called before the first frame update
    void Start()
    {
        text = ui.gameObject.GetComponent<resourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        checkResourceRange();
    }

    void checkResourceRange() {
        if(this != PlanetManager.mainPlanet) {
            if(manager.objectCollider.IsTouching(PlanetManager.mainPRange)) {
                Debug.Log("IN RANGE");
                manager.planetRender.material.SetColor("_Color", Color.green);
                if(Time.time >= nextUpdate) {
                    nextUpdate = Time.time+0.5;
                    text.addResource(1);
                }
            } else {
                manager.planetRender.material.SetColor("_Color", Color.red);
                Debug.Log("out");
            }
        } else {
            Debug.Log("MAIN P LANET");
        }
    }

    public void resource(int add) {
        text.addResource(add);
    }
}
