using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpeedUp : MonoBehaviour
{
    
    public float increaseSpeedScale;
    bool isMouseOver = false;
    bool isSelected = false;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isMouseOver){
            isSelected = true;
		}
            

        if(Input.GetMouseButtonDown(0) && !isMouseOver){
            isSelected = false;
        }

        if(Input.GetKey("a") && isSelected){
              rb.velocity = rb.velocity * increaseSpeedScale;
		}

        if(Input.GetKey("d") && isSelected){
              rb.velocity = rb.velocity/increaseSpeedScale;
		}
    }


    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        isMouseOver = true;

    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        isMouseOver = false;
    }

}
