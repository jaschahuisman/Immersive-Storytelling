using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    GameObject UserInterfaceObj;
    UserInterface userInterFaceManager;
    GameObject AudioManagerObj;
    AudioManager audioManager;

    void Start()
    {
        UserInterfaceObj = GameObject.FindGameObjectWithTag("UI_Manager");
        userInterFaceManager = UserInterfaceObj.GetComponent<UserInterface>();
        AudioManagerObj = GameObject.FindGameObjectWithTag("AudioManager");

        if (AudioManagerObj != null)
        {
            audioManager = AudioManagerObj.GetComponent<AudioManager>();
            audioManager.Stop("Prologue_Mud_Music");
        }
    }

    void Update()
    {

    }
}
