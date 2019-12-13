using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TriggerManager : MonoBehaviour
{
    public bool pickupOnAction;
    // // AudioTrigger
    public bool isAudioTrigger;
    // public AudioClip soundToPlay;
    // [Range(0f, 1f)]
    // public float volume;
    // [Range(.1f, 3f)]
    // public float pitch;
    // public bool loop;

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





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInTrigger == true && pickupOnAction == true)
        {
            if (isAudioTrigger == true) AudioTrigger();
            if (pickupItem == true) PickupTrigger();
            if (changeDoorGroupSettings == true) ChangeDoorGroupSettings();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInTrigger = true;
            if (pickupOnAction == false)
            {
                if (isAudioTrigger == true) AudioTrigger();
                if (pickupItem == true) PickupTrigger();
                if (changeDoorGroupSettings == true) ChangeDoorGroupSettings();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }

    public void AudioTrigger()
    {

    }

    public void PickupTrigger()
    {
        if (ObjectToPickup != null)
            Destroy(ObjectToPickup);
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
