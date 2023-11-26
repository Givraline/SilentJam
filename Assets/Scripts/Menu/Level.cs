using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour, IPointerClickHandler
{
    [Scene, SerializeField] private int _sceneToLoad;
    [SerializeField] private AnimationCurve _zoomCurve;
    [SerializeField, Range(0f, 10f)] private float _zoomDuration;
    private CinemachineVirtualCamera _cam;
    private Coroutine _zoomRoutine;

    private bool _alorsEnfaiteCeScriptIlSertAChoisirLeNiveauVoila = true;

    private void Awake()
    {
        _cam = FindObjectOfType<CinemachineVirtualCamera>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_zoomRoutine == null)
        {
            _zoomRoutine = StartCoroutine(ZoomRoutine());
        }
    }
    
    IEnumerator ZoomRoutine()
    {
        _cam.Follow = transform;
        float timer = 0;
        float baseDist = _cam.m_Lens.OrthographicSize;
        float percentage;
        while (timer < _zoomDuration)
        {
            timer += Time.deltaTime;
            percentage = _zoomCurve.Evaluate(timer / _zoomDuration);
            _cam.m_Lens.OrthographicSize = Mathf.Lerp(baseDist, 0f, percentage);
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene(_sceneToLoad);
    }
}
