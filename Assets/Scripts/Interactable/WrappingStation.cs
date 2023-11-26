using UnityEngine;

public class WrappingStation : MonoBehaviour, IInteractable
{
    public void Interact(PlayerInteract playerInteract)
    {
        Debug.Log("Interact with wrapping station");
        if (playerInteract.PlayerHold.Toy != null)
        {
            WrapToy(playerInteract.PlayerHold.Toy);
        }
        else
        {
            Debug.Log("Not holding Toy");
        }
    }

    void WrapToy(Toy toy)
    {
        if (toy.IsWrapped == true)
        {
            Debug.Log("Toy already wrapped"); 
            return;
        }
        else
        {
            toy.IsWrapped = true;
            toy.MeshFilter.mesh = toy.WrappedToyMesh;
            Debug.Log("Wrapped Toy");
        }
    }
}
