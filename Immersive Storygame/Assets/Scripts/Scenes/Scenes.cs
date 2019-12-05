using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public static Scenes instance;

    void Awake()
    {
        if (instance == null)
        { instance = this;}
        else {Destroy(gameObject);}

        DontDestroyOnLoad(gameObject);
    }

    public void ChangeToScene(string sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
