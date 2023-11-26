using UnityEngine;

public class Toy : MonoBehaviour, IInteractable
{
    bool _isWrapped;
    bool _hasGiftBow;

    [SerializeField] Mesh _wrappedToyMesh;
    [SerializeField] Mesh _wrappedToyWithGiftBowMesh;
    [SerializeField] MeshFilter _meshFilter;

    int _scoreValue = 100;

    #region Properties
    public bool IsWrapped { get => _isWrapped; set => _isWrapped = value; }
    public bool HasGiftBow { get => _hasGiftBow; set => _hasGiftBow = value; }
    public Mesh WrappedToyMesh { get => _wrappedToyMesh; }
    public Mesh WrappedToyWithGiftBowMesh { get => _wrappedToyWithGiftBowMesh; }
    public MeshFilter MeshFilter { get => _meshFilter; set => _meshFilter = value; }
    public int ScoreValue { get => _scoreValue; }
    #endregion

    public void Interact(PlayerInteract playerInteract)
    {
        playerInteract.PlayerHold.Hold(this);
    }
}
