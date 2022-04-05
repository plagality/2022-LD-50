using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour

{

    public GameObject mainPlanet;
    public GameObject[] otherPlanets;

    public float resources;
    public float resourceDistanceMax;
    public float resourceDistanceMinimum;

    
    public float timeForIncrement;
    float timer;

    public TextMeshProUGUI TextPro;


    // Start is called before the first frame update
    void Start()
    {
        timer = timeForIncrement;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;

        TextPro.text = "Score: " + resources.ToString("0");

        if(timer < 0){
      
            for (int i = 0; i < otherPlanets.Length; i++){
                float distance = Vector3.Distance(mainPlanet.transform.position, otherPlanets[i].transform.position);
                if(distance < resourceDistanceMax && 
                   distance > resourceDistanceMinimum &&
                   otherPlanets[i].GetComponent<Rigidbody2D>().velocity.magnitude > 0.05){
                    resources += 1;     
			    }
		    }

            timer = timeForIncrement;

            Debug.Log("Resources: " + resources);

		}
        
        


    }
}
