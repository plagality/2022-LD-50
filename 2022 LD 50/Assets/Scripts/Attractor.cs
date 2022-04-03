using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    bool isDraggable;
    bool isDragging;
    private double nextUpdate = 0.5;
    Vector3 launchVector;
    Vector3 mousePosition;
    Collider2D objectCollider;
    Renderer planetRender;

    LineRenderer lr;
    public GameObject mainPlanet;
    Collider2D mainPRange;
    public GameObject ui;
    resourceManager text;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
        objectCollider = GetComponent<Collider2D>();
        planetRender = GetComponent<Renderer>();
        lr = GetComponent<LineRenderer>();
        mainPRange = mainPlanet.transform.GetChild(0).gameObject.GetComponent<Collider2D>();
        text = ui.gameObject.GetComponent<resourceManager>();
        isDraggable = false;
        isDragging = false;

    }

    // Update is called once per frame
    void Update()
    {

        DragAndDrop();
        checkResourceRange();

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        launchVector = mousePosition - this.transform.position;

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

                rb.AddForce(new Vector3(launchVector.x, launchVector.y, 0)*15, ForceMode2D.Impulse);
                text.addResource(Mathf.FloorToInt(-1*launchVector.magnitude));
            }
        }
    }

    void checkResourceRange() {
        if(this != mainPlanet) {
            if(objectCollider.IsTouching(mainPRange)) {
                Debug.Log("IN RANGE");
                planetRender.material.SetColor("_Color", Color.green);
                if(Time.time >= nextUpdate) {
                    nextUpdate = Time.time+0.5;
                    text.addResource(1);
                }
            } else {
                planetRender.material.SetColor("_Color", Color.red);
                Debug.Log("out");
            }
        } else {
            Debug.Log("MAIN P LANET");
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
