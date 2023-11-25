using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] InputActionReference _interact;
    [SerializeField] Transform _interactionOrigin;


    private void Start()
    {
        _interact.action.started += Interact;
    }

    void Interact(InputAction.CallbackContext ctx)
    {
        Debug.Log("Try to interact");
        //Physics.OverlapSphere(_interactionOrigin.position)
    }

    private void OnDestroy()
    {
        _interact.action.canceled -= Interact;
    }
}
