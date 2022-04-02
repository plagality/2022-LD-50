using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    bool isDraggable;
    bool isDragging;
    Vector3 launchVector;
    Vector3 mousePosition;
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

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        launchVector = mousePosition - this.transform.position;
        Debug.DrawRay(this.transform.position, new Vector3(1, 1, 1), Color.green);

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

        // if its dragging,
        // track mouse position and thingy position
        // on release, add launchvector

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
            Debug.DrawRay(this.transform.position, launchVector, Color.green);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDraggable == true && isDragging == true)
            {
                isDraggable = false;
                isDragging = false;
            
                rb.AddForce(new Vector3(launchVector.x, launchVector.y, 0)*15, ForceMode2D.Impulse);
            }
        }
    }

    void Attract (Attractor objToAttract)
    {
        
        Rigidbody2D rbToAttract = objToAttract.rb;

        Vector2 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = (rb.mass * rbToAttract.mass);
        Vector2 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);

	}


}
