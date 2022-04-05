using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    
    GameObject startScreen;

    // Start is called before the first frame update
    void Start()
    {
        
        startScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit")) {
            SceneManager.LoadScene("Main");
        }
    }
}
