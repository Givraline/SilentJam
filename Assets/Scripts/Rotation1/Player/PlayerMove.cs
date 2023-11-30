using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionReference _move;
    [SerializeField] float _speed;
    Vector2 _joystickDirection;
    Coroutine _walk;

    [SerializeField] Rigidbody _rb;

    private void Start()
    {
        _move.action.started += StartWalk;
        _move.action.canceled += StopWalk;
    }

    void GetJoystickDirection()
    {
        _joystickDirection = _move.action.ReadValue<Vector2>();
        _joystickDirection.Normalize();
    }

    #region Walk
    void StartWalk(InputAction.CallbackContext ctx)
    {
        _walk = StartCoroutine(Walk());
    }

    IEnumerator Walk()
    {
        while (true)
        {
            GetJoystickDirection();
            Vector3 direction3D = new Vector3(_joystickDirection.x, 0, _joystickDirection.y);
            _rb.velocity = new Vector3(direction3D.x * _speed, _rb.velocity.y, direction3D.z * _speed);
            Rotate(direction3D);
            yield return new WaitForFixedUpdate();
        }

    }

    void StopWalk(InputAction.CallbackContext ctx)
    {
        StopCoroutine(_walk);
        _rb.velocity = Vector3.zero;
    }
    #endregion

    void Rotate(Vector3 direction)
    {
        transform.forward = direction;
    }

    private void OnDestroy()
    {
        _move.action.started -= StartWalk;
        _move.action.canceled -= StopWalk;
    }
}
