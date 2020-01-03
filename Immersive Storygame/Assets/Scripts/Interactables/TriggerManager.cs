using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;

public class TriggerManager : MonoBehaviour
{
    public bool triggerOnAction;
    public bool removeTriggerOnAction;
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
    public bool destroyItem;
    public GameObject ObjectToDestroy;

    // EnableTrigger
    public bool gameObjectStateToggle;
    public bool isToggle;
    public bool stateToToggleTo;
    public GameObject objectToToggle;

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

    // DoorTrigger
    public bool isCutsceneTrigger;
    public PlayableDirector cutscene;

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

        if (Input.GetKeyDown("e") || Input.GetAxis("Fire2") != 0)
        {
            userInput = true;
        }
        else userInput = false;

        if (isInTrigger == true && triggerOnAction == true && userInput == true)
        {
            if (destroyItem == true) PickupTrigger();
            if (changeDoorGroupSettings == true) ChangeDoorGroupSettings();
            if (gameObjectStateToggle == true) ToggleSomething();
            if (removeTriggerOnAction == true)
            {
                changeDoorGroupSettings = false;
                gameObjectStateToggle = false;
                source = null;
                customMessage = null;
                destroyItem = false;
                triggerOnAction = false;
            }

            userInterFaceManager.popUI("CustomRAD");
            if (source)
                source.Play();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInTrigger = true;
            if (triggerOnAction == false)
            {
                if (destroyItem == true) PickupTrigger();
                if (changeDoorGroupSettings == true) ChangeDoorGroupSettings();
                if (gameObjectStateToggle == true) ToggleSomething();
                if (isCutsceneTrigger == true) PlayCutscene();
            }
        }

        if (triggerOnAction == true)
        {
            userInterFaceManager.pushRAD(customMessage);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInTrigger = false;
            userInterFaceManager.popUI("CustomRAD");
        }
    }

    public void PickupTrigger()
    {
        if (ObjectToDestroy != null)
            Destroy(ObjectToDestroy, .5f);
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

    public void ToggleSomething()
    {
        if (isToggle)
        {
            objectToToggle.SetActive(!objectToToggle.activeInHierarchy);
        }
        else
        {
            objectToToggle.SetActive(stateToToggleTo);
        }
    }

    public void PlayCutscene()
    {
        cutscene.Play();
    }
}