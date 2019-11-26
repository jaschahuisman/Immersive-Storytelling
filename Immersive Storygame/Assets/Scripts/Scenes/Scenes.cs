using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    // Define UI Manager GameObject
    // GameObject UI_Object;
    // UserInterface UI;

    // Start the Game
    void Start()
    {
        // Get UserInterface Class of UI_Object
        // UI_Object = GameObject.FindWithTag("UI_Manager");
        // UI = UI_Object.GetComponent<UserInterface>();
    }

    public void ChangeToScene(string sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
