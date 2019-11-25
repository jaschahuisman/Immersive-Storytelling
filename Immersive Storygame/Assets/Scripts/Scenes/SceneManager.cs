using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Define UI Manager GameObject
    GameObject UI_Object;
    UserInterface UI;

    // Start the Game
    void Start()
    {
        // Get UserInterface Class of UI_Object
        UI_Object = GameObject.FindWithTag("UI_Manager");
        UI = UI_Object.GetComponent<UserInterface>();
    }

    // // Toggle Credit window
    // public void toggleCredits()
    // {
    //     if (UI.getActiveState("Credits") == 1)
    //     {
    //         // Toggle Off
    //         UI.popAll();
    //         UI.pushUI("Startscreen");
    //     }
    //     else if (UI.getActiveState("Credits") == 0)
    //     {
    //         // Toggle On
    //         UI.popAll();
    //         UI.pushUI("Credits");
    //     }
    // }

    public void ChangeToScene(string sceneToChangeTo)
    {


    }
}
