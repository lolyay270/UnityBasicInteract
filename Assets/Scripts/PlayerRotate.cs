using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotate : MonoBehaviour
{
    Camera cam;
    InputAction look;

    [SerializeField] float mouseLookSpeed;
    [SerializeField] float controllerLookSpeed;
    [SerializeField] float maxVertAngle;

    bool inputIsDelta;
    float currentYaw;

    // Awake runs on game start
    void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        look = InputSystem.actions.FindAction("Look");
    }

    // Start runs on first frame (after Awake)
    void Start()
    {
        //listener to change if controller or mouse used
        look.performed += ctx => { inputIsDelta = ctx.control.name == "delta"; };
    }

    void Update()
    {
        Vector2 lookVector = look.ReadValue<Vector2>();
        if (!inputIsDelta) lookVector *= Time.deltaTime * controllerLookSpeed; // mulitply deltaTime for non mouse inputs
        else lookVector *= mouseLookSpeed;

        // player horizontal (y axis)
        transform.Rotate(0, lookVector.x, 0); // input x axis

        // camera vertical (x axis)
        currentYaw += -lookVector.y * mouseLookSpeed; //input y axis
        currentYaw = Mathf.Clamp(currentYaw, -maxVertAngle, maxVertAngle);
        cam.transform.localRotation = Quaternion.Euler(currentYaw, 0, 0); //want to set exact value to stop looking upsidedown
    }
}
