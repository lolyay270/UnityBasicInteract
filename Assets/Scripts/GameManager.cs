using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UnityEvent<Interactable> OnInteractableClick = new();

    //runs when game starts, before Start
    void Awake()
    {
        //make singleton
        if (Instance == null) Instance = this;

        OnInteractableClick.AddListener(HandleInteractClicked);
    }

    void HandleInteractClicked(Interactable obj)
    {
        print(obj.name + " was clicked");
    }
}
