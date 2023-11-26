using UnityEngine;

public class DepositBox : MonoBehaviour, IInteractable
{
    public void Interact(PlayerInteract playerInteract)
    {
        Debug.Log("Interact With deposit box");
        if (playerInteract.PlayerHold.Toy != null)
        {
            DepositToy(playerInteract.PlayerHold, playerInteract.PlayerHold.Toy);
        }
        else
        {
            Debug.Log("Not holding Toy");
        }
    }

    void DepositToy(PlayerHold playerHold, Toy toy)
    {
        if(!toy.IsWrapped || !toy.HasGiftBow)
        {
            Debug.Log("Can't deposit, Toy not finished");
        }
        else
        {
            playerHold.Toy = null;
            Destroy(toy.gameObject);
            ScoreManager.instance.AddScore(toy.ScoreValue);
            Debug.Log("Toy Deposited");
        }
    }
}
