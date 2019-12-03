using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueScreens : MonoBehaviour
{
    public AudioManager audioManager;
    public UserInterface userInterfaceManager;

    public int UserInterfaceState;


    // Start is called before the first frame update
    void Start()
    {
        UserInterfaceState = 0;
        userInterfaceManager.popAll();
        audioManager.Play("Prologue_Music");
    }

    // Update is called once per frame
    void Update()
    {
        audioManager.Stop("Homescreen");
        bool userInput = Input.GetKeyDown("space");
        if (userInput == true)
        {
            UserInterfaceState++;
        }

        if (UserInterfaceState == 0)
        {
            userInterfaceManager.pushUI("Text1");
        }
        else if (UserInterfaceState == 1)
        {
            userInterfaceManager.popUI("Text1");
            userInterfaceManager.pushUI("Text2");
        }
        else if (UserInterfaceState > 1)
        {
            userInterfaceManager.popUI("Text2");
        }
    }
}
