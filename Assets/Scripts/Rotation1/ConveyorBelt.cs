using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float _speed;
    private List<Rigidbody> _rbs = new List<Rigidbody>();
    

    private void FixedUpdate()
    {
        foreach (var rb in _rbs)
        {
            rb.velocity = transform.forward * _speed * Time.fixedDeltaTime; 
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Toy"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * _speed * Time.fixedDeltaTime;
            _rbs.Add(rb);
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Toy"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            _rbs.Remove(rb);
        }
    }
}
