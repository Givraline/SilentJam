using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    private Coroutine c;

    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private int _timer;
    [SerializeField] private ScoreManager _sm;

    public static TimerManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        LaunchTimer();
    }

    void LaunchTimer()
    {
        RemoveScore(1);
        c = StartCoroutine(TimerLoop());
    }

    IEnumerator TimerLoop()
    {
        yield return new WaitForSeconds(1.0f);
        if (_timer == 0)
        {
            MessageGenerator.Instance.ShowMessage("TIME UP !");
            if(_sm.Score <= 100)
            {
                yield return new WaitForSeconds(2.0f);
                MessageGenerator.Instance.ShowMessage("YOU LOOSE...");
                SceneManager.LoadScene(0);
            }
            else
            {
                yield return new WaitForSeconds(2.0f);
                MessageGenerator.Instance.ShowMessage("YOU WIN !");
                SceneManager.LoadScene(0);
            }
        }
        LaunchTimer();
    }

    public void AddScore(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Frérot t'abuse");
        }
        _timer += value;
        _timerText.text = _timer.ToString();
        _timerText.transform.localScale = Vector3.one;
        _timerText.DOScale(1.5f, .3f).SetEase(Ease.InBounce).SetLoops(2, LoopType.Yoyo);
    }

    public void RemoveScore(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Frérot t'abuse");
        }
        _timer -= value;
        _timerText.text = _timer.ToString();
        _timerText.transform.localScale = Vector3.one;
        _timerText.DOScale(.5f, .3f).SetEase(Ease.InBounce).SetLoops(2, LoopType.Yoyo);
    }

    [Button]
    public void TestAdd() => AddScore(10);

    [Button]
    public void TestRemove() => RemoveScore(10);

}
