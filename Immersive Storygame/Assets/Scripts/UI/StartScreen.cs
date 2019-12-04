using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public string nextScene;
    public Scenes sceneManager;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager.Play("Anubis");
        audioManager.Play("Music");
    }

    // Update is called once per frame
    void Update()
    {
        bool userInput = Input.GetKeyDown("space");
        if (userInput == true)
        {
            sceneManager.ChangeToScene(nextScene);
        }

    }
}
