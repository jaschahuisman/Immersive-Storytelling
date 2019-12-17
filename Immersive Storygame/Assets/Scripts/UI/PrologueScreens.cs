using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueScreens : MonoBehaviour
{
    public UserInterface userInterfaceManager;
    public int UserInterfaceState;

    private GameObject sceneManagerObj;
    private Scenes sceneManager;
    private GameObject audioManagerObj;
    private AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        SceneSetup();
        UserInterfaceState = 0;
        userInterfaceManager.popAll();
        // audioManager.Stop("Anubis");
        // audioManager.Play("");
    }

    public void SceneSetup()
    {
        sceneManagerObj = GameObject.FindGameObjectWithTag("GameManager");
        sceneManager = sceneManagerObj.GetComponent<Scenes>();
        audioManagerObj = GameObject.FindGameObjectWithTag("AudioManager");
        audioManager = audioManagerObj.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // audioManager.Stop("Homescreen");
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
            audioManager.Stop("Theme");
            sceneManager.ChangeToScene("Scene04_Gameplay");
        }
    }
}
