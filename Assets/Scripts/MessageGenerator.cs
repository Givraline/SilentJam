using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MessageGenerator : MonoBehaviour
{
    private static MessageGenerator instance;
    public static MessageGenerator Instance => instance;

    [SerializeField] GameObject _messageObject;
    [SerializeField] TMP_Text _textObject;
    Animator _animator;

    private void Start()
    {
        instance = this;
        _messageObject.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        StartCoroutine(StartShowMessage(message));

    }
    IEnumerator StartShowMessage(string message)
    {
        _textObject.text = message;
        _messageObject.SetActive(true);
        yield return new WaitForSeconds(2);
        _messageObject.SetActive(false);
    }
}
