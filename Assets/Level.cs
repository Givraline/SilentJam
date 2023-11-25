using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour, IPointerClickHandler
{
    [Scene, SerializeField] private int _sceneToLoad;

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }


    // IEnumerator ZoomRoutine()
    // {
    //     
    // }
}
