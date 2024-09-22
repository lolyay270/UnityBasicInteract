using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerInteract : MonoBehaviour
{
    Camera cam;
    InputAction interact;

    [SerializeField] float interactionDistance;

    void Awake()
    {
        cam = GetComponentInChildren<Camera>();

        interact = InputSystem.actions.FindAction("Interact");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void Start()
    {
        //event listener for when interact occurs
        interact.performed += ctx => { HandleInteract(); };
    }

    void HandleInteract()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, interactionDistance)) //returns true if hit anything
        {
            GameObject obj = hit.collider.gameObject;
            try
            {
                Interactable inter = obj.GetComponent<Interactable>();
                GameManager.Instance.OnInteractableClick.Invoke(inter);
            }
            catch
            {
                print("GO=  " + obj.name + "    no interactable present");
            }
        }
    }
}
