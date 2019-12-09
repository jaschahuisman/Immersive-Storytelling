using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    // Door Object
    public GameObject doorObject;

    // Door Properties
    public float openSpeed;
    public bool isLocked;
    public bool isOpen;
    public bool openOnEnter;
    public bool closeOnEnter;
    public bool closeOnExit;
    public bool lockOnExit;

    // Door Distances
    public Vector3 openDistance = new Vector3(0, 0, 0);
    Vector3 closedDistance;
    Vector3 desiredPos;

    // Player Collision
    bool isInTrigger;

    // Door Object
    GameObject UserInterfaceObj;
    UserInterface userInterFaceManager;


    public void Start()
    {
        UserInterfaceObj = GameObject.FindGameObjectWithTag("UI_Manager");
        userInterFaceManager = UserInterfaceObj.GetComponent<UserInterface>();
        closedDistance = doorObject.transform.position;
    }



    public void Update()
    {
        bool userInput = Input.GetKeyDown("e");

        if (isLocked == false)
        {
            // Open Door On Enter
            if (isInTrigger == true && openOnEnter == true && closeOnEnter == false) isOpen = true;

            // Close Door On Enter 
            if (isInTrigger == true && closeOnEnter == true && openOnEnter == false) isOpen = false;

            // Close Door On Exit
            if (isInTrigger == false && closeOnExit == true) isOpen = false;

            // Open Door On Action
            if (isInTrigger == true && openOnEnter == false && userInput == true && closeOnEnter == false)
            {
                isOpen = true;
                userInterFaceManager.popUI("OpenDoor");
            }

        }


        if (closeOnExit == true && isInTrigger == false)
            isOpen = false;

        if (lockOnExit == true)
            closeOnExit = true;

        if (isOpen == true)
            desiredPos = openDistance;
        else if (isOpen == false)
            desiredPos = closedDistance;

        doorObject.transform.position = Vector3.Lerp(doorObject.transform.position, desiredPos, openSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInTrigger = true;

            if (openOnEnter == false && isLocked == false && isOpen == false)
            {
                userInterFaceManager.pushUI("OpenDoor");
            }
            else if (isLocked == true)
            {
                userInterFaceManager.pushUI("DoorIsLocked");
            }
        }
        else
        {
            isInTrigger = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInTrigger = false;
            userInterFaceManager.popUI("OpenDoor");
            userInterFaceManager.popUI("DoorIsLocked");
        }

        if (lockOnExit == true)
        {
            isLocked = true;
        }
    }
}
