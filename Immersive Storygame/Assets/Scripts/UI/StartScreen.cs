using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public string nextScene;
    private GameObject sceneManagerObj;
    private Scenes sceneManager;
    private GameObject audioManagerObj;
    private AudioManager audioManager;

    // Start is called before the first frame update
    public void Start()
    {
        SceneSetup();
        audioManager.Play("Anubis");
    }

    public void SceneSetup()
    {
        sceneManagerObj = GameObject.FindGameObjectWithTag("GameManager");
        sceneManager = sceneManagerObj.GetComponent<Scenes>();
        audioManagerObj = GameObject.FindGameObjectWithTag("AudioManager");
        audioManager = audioManagerObj.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    public void Update()
    {
        bool userInput = Input.GetKeyDown("space");
        // Press space to start game
        if (userInput == true)
        {
            sceneManager.ChangeToScene(nextScene);
        }
    }
}
