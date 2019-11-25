using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interfaces
{
    public GameObject userInterface;
    public string name;
}

public class UserInterface : MonoBehaviour
{
    public Interfaces[] interfaces;
    public void pushUI(string name)
    {
        foreach (Interfaces i in interfaces)
        {

            if (i.name == name)
            {
                i.userInterface.SetActive(true);
            }
            // print(i);
        }
    }

    public void popUI(string name)
    {
        foreach (Interfaces i in interfaces)
        {
            if (i.name == name)
            {
                i.userInterface.SetActive(false);
            }
        }
    }

    public void toggleUI(string name)
    {
        foreach (Interfaces i in interfaces)
        {
            if (i.name == name) { i.userInterface.SetActive(!i.userInterface.activeInHierarchy); }
        }
    }
}
