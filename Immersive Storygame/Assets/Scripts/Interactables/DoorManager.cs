using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
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
    public float openDistance;
    Vector3 openVector;
    Vector3 closedDistance;
    Vector3 desiredPos;

    // Player Collision
    bool isInTrigger;

    // Door Object
    GameObject UserInterfaceObj;
    UserInterface userInterFaceManager;

    // Door Sound
    public AudioSource doorAudio;

    public void Start()
    {
        openVector = new Vector3(0,0, openDistance);
        UserInterfaceObj = GameObject.FindGameObjectWithTag("UI_Manager");
        userInterFaceManager = UserInterfaceObj.GetComponent<UserInterface>();
        closedDistance = doorObject.transform.localPosition;
    }



    public void Update()
    {
        bool userInput = Input.GetKeyDown("e");

        if (isLocked == false)
        {
            // Open Door On Enter
            if (isInTrigger == true && openOnEnter == true && closeOnEnter == false)
            {
                isOpen = true;
            }

            // Close Door On Enter 
            if (isInTrigger == true && closeOnEnter == true && openOnEnter == false)
            {
                PlayDoorSound();
                isOpen = false;
            }

            // Close Door On Exit
            if (isInTrigger == false && closeOnExit == true)
            {
                isOpen = false;
            }

            // Open Door On Action
            if (isInTrigger == true && openOnEnter == false && userInput == true && closeOnEnter == false)
            {
                PlayDoorSound();
                isOpen = true;
                userInterFaceManager.popUI("OpenDoor");
            }

        }


        if (closeOnExit == true && isInTrigger == false)
            isOpen = false;

        if (lockOnExit == true)
            closeOnExit = true;

        if (isOpen == true)
            desiredPos = openVector;
        else if (isOpen == false)
            desiredPos = closedDistance;

        doorObject.transform.localPosition = Vector3.Lerp(doorObject.transform.localPosition, desiredPos, openSpeed * Time.deltaTime);
    }

    public void PlayDoorSound()
    {
        doorAudio.pitch = Random.Range(0.9f, 1.1f);
        doorAudio.Play();
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

            if (openOnEnter == true && isOpen == false)
            {
                PlayDoorSound();
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

        if (isOpen == true && closeOnExit == true)
        {
            PlayDoorSound();
        }
    }
}
