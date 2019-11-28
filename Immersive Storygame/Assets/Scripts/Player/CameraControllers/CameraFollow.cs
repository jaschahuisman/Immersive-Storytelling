using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraMoveSpeed = 120f;
    public GameObject cameraFollowObject;
    public float clampAngle;
    public float inputSensitivity;
    public GameObject mainCamera;
    public GameObject playerObj;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    public float rotX = 0.0f;
    public float rotY = 0.0f;

    public void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotX = rot.x;
        rotY = rot.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {
        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputZ = Input.GetAxis("RightStickVertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        rotX += -1 * finalInputZ * inputSensitivity * Time.deltaTime;
        rotY += finalInputX * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }

    public void LateUpdate()
    {
        CameraUpdater();
    }

    public void CameraUpdater()
    {
        Transform target = cameraFollowObject.transform;
        float step = cameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    // public GameObject player;
    // public float cameraHeight = 20.0f;
    // public float cameraDistance = 3.0f;

    // void Update()
    // {
    //     Vector3 pos = player.transform.position;
    //     pos.y += cameraHeight;
    //     pos.z += -cameraDistance;
    //     transform.position = pos;
    // }
}