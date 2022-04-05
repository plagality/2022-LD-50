using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : MonoBehaviour
{

    public GameObject message;

    // Start is called before the first frame update
    void Start()
    {
        message.GetComponent<SpriteRenderer>().enabled = false;
        makeInvisible();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeInvisible()
    {
        message.GetComponent<SpriteRenderer>().enabled = false;
	}

    public void makeVisible()
    {
        message.GetComponent<SpriteRenderer>().enabled = true;
	}

}
