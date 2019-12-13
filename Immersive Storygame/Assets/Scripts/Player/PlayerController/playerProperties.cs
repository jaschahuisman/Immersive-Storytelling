using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProperties : MonoBehaviour
{
    public GameObject[] Reception_DM;
    public bool hasBadge;
    public bool isChipped;
    public bool wantedToChip;
    public bool hasChipData;



    // Start is called before the first frame update
    void Start()
    {
        // foreach (var Door in Reception_DM)
        // {
        //     DoorManager dm = Door.GetComponent<DoorManager>();
        //     dm.isLocked = true;
        // }

        // LockDoorGroup(Reception_DM);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LockDoorGroup(GameObject[] doorgroup)
    {
        foreach (var door in doorgroup)
        {
            DoorManager dm = door.GetComponent<DoorManager>();
            dm.isLocked = true;
        }
    }
}


