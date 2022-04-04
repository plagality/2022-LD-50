using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour

{

    public GameObject mainPlanet;
    public GameObject[] otherPlanets;

    public float resources;
    public float resourceDistanceMax;

    
    public float timeForIncrement;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = timeForIncrement;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;

        if(timer < 0){
      
            for (int i = 0; i < otherPlanets.Length; i++){
                float distance = Vector3.Distance(mainPlanet.transform.position, otherPlanets[i].transform.position);
                if(distance < resourceDistanceMax){
                    resources += 1;     
			    }
		    }

            timer = timeForIncrement;

            Debug.Log("Resources: " + resources);

		}
        
        


    }
}
