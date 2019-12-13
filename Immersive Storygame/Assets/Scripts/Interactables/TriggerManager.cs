using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TriggerManager : MonoBehaviour
{
    public bool pickupOnAction;
    public string customMessage;

    // Audio
    public AudioClip audioClip;
    private AudioSource source;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;

    // PickupTrigger
    public bool pickupItem;
    public GameObject ObjectToPickup;

    // DoorTrigger
    public bool changeDoorGroupSettings;
    public bool isLocked;
    public bool isOpen;
    public bool openOnEnter;
    public bool closeOnEnter;
    public bool closeOnExit;
    public bool lockOnExit;
    public string customLockMessage;
    public string customUnlockMessage;
    public GameObject[] doorGroup;

    private bool isInTrigger;

    // UI
    GameObject UserInterfaceObj;
    UserInterface userInterFaceManager;


    // Start is called before the first frame update
    void Start()
    {
        UserInterfaceObj = GameObject.FindGameObjectWithTag("UI_Manager");
        userInterFaceManager = UserInterfaceObj.GetComponent<UserInterface>();
        gameObject.AddComponent<AudioSource>();

        source = gameObject.GetComponent<AudioSource>();
        if (audioClip != null)
        {
            source.clip = audioClip;
            source.volume = volume;
            source.pitch = pitch;
            source.loop = loop;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool userInput;

        if (Input.GetKeyDown("e") || Input.GetAxis("Submit") != 0)
        {
            userInput = true;
        }
        else userInput = false;

        if (isInTrigger == true && pickupOnAction == true && userInput == true)
        {
            if (pickupItem == true) PickupTrigger();
            if (changeDoorGroupSettings == true) ChangeDoorGroupSettings();
            userInterFaceManager.popUI("CustomRAD");
            source.Play();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInTrigger = true;
            if (pickupOnAction == false)
            {
                if (pickupItem == true) PickupTrigger();
                if (changeDoorGroupSettings == true) ChangeDoorGroupSettings();
            }
        }

        if (pickupOnAction == true)
        {
            userInterFaceManager.pushRAD(customMessage);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            userInterFaceManager.popUI("CustomRAD");
        }
    }

    public void PickupTrigger()
    {
        if (ObjectToPickup != null)
            Destroy(ObjectToPickup, .5f);
            // ObjectToPickup.SetActive(false);
    }

    public void ChangeDoorGroupSettings()
    {
        if (doorGroup != null)
            foreach (var door in doorGroup)
            {
                DoorManager dm = door.GetComponent<DoorManager>();

                dm.isLocked = isLocked;
                dm.isOpen = isOpen;
                dm.openOnEnter = openOnEnter;
                dm.closeOnEnter = closeOnEnter;
                dm.closeOnExit = closeOnExit;
                dm.lockOnExit = lockOnExit;

                if (customLockMessage.Length > 0)
                {
                    dm.customLockMessage = customLockMessage;
                }

                if (customUnlockMessage.Length > 0)
                {
                    dm.customUnlockMessage = customUnlockMessage;
                }
            }
    }
}
