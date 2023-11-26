using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHold : MonoBehaviour
{
    [SerializeField] Transform _holdPoint;
    Toy _toy;

    [SerializeField] InputActionReference _drop;

    #region Properties
    public Toy Toy { get => _toy; set => _toy = value; }
    #endregion

    private void Start()
    {
        _drop.action.started += Drop;
    }

    public void Hold(Toy toy) 
    {
        if( _toy != null)
        {
            Debug.Log("Already Holding an Item");
        }
        else
        {
            toy.transform.position = _holdPoint.position;
            toy.transform.parent = _holdPoint;
            _toy = toy;
        }
    }

    void Drop(InputAction.CallbackContext ctx)
    {
        if(_toy != null)
        {
            _toy.transform.parent = transform.root;
            _toy = null;
        }
        else
        {
            Debug.Log("No object to drop");
        }
    }
}
