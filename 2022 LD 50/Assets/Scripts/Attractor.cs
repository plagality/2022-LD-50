using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    Vector3 launchVector;
    Vector3 mousePosition;
    LineRenderer lr;
    public Rigidbody2D rb;
    
    public PlanetManager manager;

    public bool isDraggable;
    public bool isDragging;

    // Start is called before the first frame update
    void Start()
    {
        
        lr = GetComponent<LineRenderer>();

        isDraggable = false;
        isDragging = false;

    }

    // Update is called once per frame
    void Update()
    {

        launchPlanet();


    }

    void FixedUpdate()
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

    void launchPlanet(){

        // if its dragging,
        // track mouse position and thingy position
        // on release, add launchvector

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        launchVector = mousePosition - this.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            if(manager.objectCollider == Physics2D.OverlapPoint(mousePosition))
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
            lr.SetPosition(0, this.transform.position);
            lr.SetPosition(1, this.transform.position + launchVector);
            Debug.DrawRay(this.transform.position, launchVector, Color.green);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDraggable == true && isDragging == true)
            {
                isDraggable = false;
                isDragging = false;

                lr.SetPosition(0, Vector3.zero);
                lr.SetPosition(1, Vector3.zero);

                manager.rb.AddForce(new Vector3(launchVector.x, launchVector.y, 0)*15, ForceMode2D.Impulse);
                manager.resources.resource(Mathf.FloorToInt(-1*launchVector.magnitude));
            }
        }
    }

    void Attract (Attractor objToAttract)
    {
        
        Rigidbody2D rbToAttract = objToAttract.manager.rb;

        Vector2 direction = manager.rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = (manager.rb.mass * rbToAttract.mass);
        Vector2 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);

	}


}
