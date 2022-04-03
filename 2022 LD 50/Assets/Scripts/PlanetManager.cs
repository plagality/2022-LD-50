using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public Collider2D objectCollider;
    public Renderer planetRender;
    public planetResources resources;

    public bool isMainPlanet;
    public static GameObject mainPlanet;
    public static Collider2D mainPRange;

    // Start is called before the first frame update
    void Start()
    {
        if(isMainPlanet) {
            mainPlanet = this.gameObject;
            Debug.Log("MAIN PLANET");
        }

        objectCollider = GetComponent<Collider2D>();
        planetRender = GetComponent<Renderer>();
        mainPRange = mainPlanet.transform.GetChild(0).gameObject.GetComponent<Collider2D>();

        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
