using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public GameObject planet0;

    public GameObject[] planets;

    public float coefficient;
    public float minSize;
    public float maxSize;

    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        float distance = 0f;

        for (int i = 0; i < planets.Length; i++)
        {
      
            if (Vector3.Distance(planet0.transform.position, planets[i].transform.position) > distance)
            {
       
                distance = Vector3.Distance(planet0.transform.position, planets[i].transform.position);

			}
		}
        camera.orthographicSize = distance * coefficient;

        if (camera.orthographicSize > maxSize){
            camera.orthographicSize = maxSize;  
		} else if (camera.orthographicSize < minSize){
            camera.orthographicSize = minSize;  
		}


    }
}
