using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    // Define Scene Manager GameObject
    GameObject SceneObject;
    Scenes scene;
    
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        // Get UserInterface Class of UI_Object
        SceneObject = GameObject.FindWithTag("GameManager");
        scene = SceneObject.GetComponent<Scenes>();
    }

    // Update is called once per frame
    void Update()
    {
        bool userInput = Input.GetKeyDown("space");
        if (userInput == true)
        {
            scene.ChangeToScene(nextScene);
        }

    }
}
