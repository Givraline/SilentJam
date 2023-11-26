using UnityEngine;

public class Toy : MonoBehaviour, IInteractable
{
    public void Interact(PlayerInteract playerInteract)
    {
        playerInteract.PlayerHold.Hold(this);
    }
}
