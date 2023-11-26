using UnityEngine;

public class GiftBowStation : MonoBehaviour, IInteractable
{
    public void Interact(PlayerInteract playerInteract)
    {
        Debug.Log("Interact with giftbow station");
        if (playerInteract.PlayerHold.Toy != null)
        {
            PutGiftBow(playerInteract.PlayerHold.Toy);
        }
        else
        {
            Debug.Log("Not holding Toy");
        }
    }

    void PutGiftBow(Toy toy)
    {
        if(!toy.IsWrapped)
        {
            Debug.Log("Canno't put giftbow because Toy is not wrapped");
        }
        else if (toy.HasGiftBow)
        {
            Debug.Log("Toy already has giftbow");
        }
        else
        {
            Debug.Log("Put giftbow on Toy");
            toy.HasGiftBow = true;
        }
    }
}
