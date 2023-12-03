using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] InputActionReference _interact;
    [SerializeField] Transform _interactionOrigin;
    [SerializeField] float _interactionRadius;

    PlayerHold _playerHold;


    #region Properties
    public Transform InteractionOrigin { get => _interactionOrigin; }
    public PlayerHold PlayerHold { get => _playerHold; }
    #endregion

    private void Awake()
    {
        _playerHold = GetComponent<PlayerHold>();
    }

    private void Start()
    {
        _interact.action.started += Interact;
    }

    void Interact(InputAction.CallbackContext ctx)
    {
        Collider[] hitInfos = Physics.OverlapSphere(_interactionOrigin.position, _interactionRadius);
        foreach (Collider hit in hitInfos) 
        {
            if(hit.GetComponent<IInteractable>() != null)
            {
                IInteractable interactable = hit.GetComponent<IInteractable>();
                interactable.Interact(this);
                break;
            }
        }
    }

    private void OnDestroy()
    {
        _interact.action.canceled -= Interact;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (_interactionOrigin != null)
        {
            Gizmos.DrawWireSphere(_interactionOrigin.position, _interactionRadius);
        }
    }
}
