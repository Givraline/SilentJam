using UnityEngine;

public class Toy : MonoBehaviour, IInteractable
{
    bool _isWrapped;
    bool _hasGiftBow;

    #region Properties
    public bool IsWrapped { get => _isWrapped; set => _isWrapped = value; }
    public bool HasGiftBow { get => _hasGiftBow; set => _hasGiftBow = value; }
    #endregion

    public void Interact(PlayerInteract playerInteract)
    {
        playerInteract.PlayerHold.Hold(this);
    }
}
