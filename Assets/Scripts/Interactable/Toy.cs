using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interact");
    }
}
