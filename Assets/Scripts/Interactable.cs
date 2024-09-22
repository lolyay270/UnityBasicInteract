using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    Outline outline;
    Rigidbody body;

    // Awake is called on game load, before Start
    private void Awake()
    {
        outline = gameObject.AddComponent<Outline>();
        body = gameObject.AddComponent<Rigidbody>();
        body.isKinematic = true;
        body.useGravity = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        SetOutline();
    }

    private void OnMouseEnter()
    {
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 10f;
    }

    private void OnMouseExit()
    {
        SetOutline();
    }

    void SetOutline()
    {
        outline.OutlineColor = Color.white;
        outline.OutlineWidth = 5f;
    }
}
