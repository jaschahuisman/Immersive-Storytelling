using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Serialize & Define User Interface GameObjects in the Unity Engine
[System.Serializable]
public class Interfaces
{
    public GameObject userInterface;
    public string name;
}

public class UserInterface : MonoBehaviour
{
    // Retrieve Interface GameObjects from the Unity Engine 
    public Interfaces[] interfaces;

    // Start the Game
    public void Awake()
    {
        foreach (Interfaces i in interfaces)
        {
            i.userInterface.SetActive(false);
            if (i.name == "Startscreen") { i.userInterface.SetActive(true); }
        }
    }

    // Enable Interface GameObject with name
    public void pushUI(string name)
    {
        foreach (Interfaces i in interfaces)
        {
            if (i.name == name)
            {
                i.userInterface.SetActive(true);
                return;
            }

        }

        Debug.LogWarning("Can't find a UI Object with the name: '" + name + "'.");
    }

    // Disable Interface GameObject with name
    public void popUI(string name)
    {
        foreach (Interfaces i in interfaces)
        {
            if (i.name == name)
            {
                i.userInterface.SetActive(false);
                return;
            }

        }

        Debug.LogWarning("Can't find a UI Object with the name: '" + name + "'.");
    }

    // Toggle Interface GameObject with name
    public void toggleUI(string name)
    {
        foreach (Interfaces i in interfaces)
        {
            if (i.name == name)
            {
                i.userInterface.SetActive(!i.userInterface.activeInHierarchy);
                return;
            }

        }

        Debug.LogWarning("Can't find a UI Object with the name: '" + name + "'.");
    }

    // Disable All Interface GameObjects
    public void popAll()
    {
        foreach (Interfaces i in interfaces)
        {
            i.userInterface.SetActive(false);
        }
    }

    // Get/return Interface GameObjects visibility state
    public int getActiveState(string name)
    {
        foreach (Interfaces i in interfaces)
        {
            if (i.name == name)
            {
                if (i.userInterface.activeInHierarchy == true)
                    // Active state is true
                    return 1;
                else if (i.userInterface.activeInHierarchy == false)
                    // Active state is false
                    return 0;
            }
        }

        // Object not found
        return -1;
    }
}
