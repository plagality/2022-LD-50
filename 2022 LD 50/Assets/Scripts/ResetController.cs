using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetController : MonoBehaviour
{

    public GameObject[] resetObjects;
    public Transform[] resetLocations;

    public GameObject deathMessage;

    public Animator star;

    public GameObject ResourceManager;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset(){
    
        
        for (int i = 0; i < resetObjects.Length; i++){
            
            rb = resetObjects[i].GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;

            resetObjects[i].transform.position = new Vector3(resetLocations[i].position.x,
                                                             resetLocations[i].position.y,
                                                             0f);


		}

        star.Play("Death", -1, 0f);

        ResourceManager.GetComponent<ResourceManager>().resources = 0f;

        deathMessage.GetComponent<MessageController>().makeInvisible();

	}
}
