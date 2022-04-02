using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    
    public float gravityScale;
    bool isDraggable;
    bool isDragging;
    Collider2D objectCollider;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
        objectCollider = GetComponent<Collider2D>();
        isDraggable = false;
        isDragging = false;

    }

    // Update is called once per frame
    void Update()
    {

        DragAndDrop();

    }

    void FixedUpdate ()
    {
        Attractor[] attractors = FindObjectsOfType<Attractor>();
        foreach (Attractor attractor in attractors)
        {
            
            if (attractor != this)
            {
                Attract(attractor);
			}
            

		}


	}

    void DragAndDrop(){

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if(objectCollider == Physics2D.OverlapPoint(mousePosition))
            {
                isDraggable = true;
            }
            else
            {
                isDraggable = false;
            }

            if (isDraggable)
            {
                isDragging = true;
            }
        }
        if (isDragging)
        {
            this.transform.position = mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDraggable = false;
            isDragging = false;
        }
    }

    void Attract (Attractor objToAttract)
    {
        
        Rigidbody2D rbToAttract = objToAttract.rb;

        Vector2 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = (rb.mass * rbToAttract.mass);
        Vector2 force = direction.normalized * forceMagnitude * gravityScale;

        rbToAttract.AddForce(force);

	}


}
