using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputManagerEntry;

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
            Debug.Log("Already Holding a Toy");
        }
        else
        {
            toy.transform.position = _holdPoint.position;
            toy.transform.parent = _holdPoint;
            toy.GetComponent<Collider>().enabled = false;
            _toy = toy;
        }
    }

    void Drop(InputAction.CallbackContext ctx)
    {
        if(_toy != null)
        {
            _toy.transform.parent = transform.root;
            _toy.GetComponent<Collider>().enabled = true;
            _toy = null;
        }
        else
        {
            Debug.Log("No object to drop");
        }
    }
}
