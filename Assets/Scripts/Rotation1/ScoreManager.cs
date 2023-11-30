using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private int _score;
    
    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Frérot t'abuse");
        }
        _score += value;
        _scoreText.text = _score.ToString();
        _scoreText.transform.localScale = Vector3.one;
        _scoreText.DOScale(1.5f, .3f).SetEase(Ease.InBounce).SetLoops(2, LoopType.Yoyo);
    }
    
    public void RemoveScore(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Frérot t'abuse");
        }
        _score -= value;
        _scoreText.text = _score.ToString();
        _scoreText.transform.localScale = Vector3.one;
        _scoreText.DOScale(.5f, .3f).SetEase(Ease.InBounce).SetLoops(2, LoopType.Yoyo);
    }

    [Button]
    public void TestAdd() => AddScore(10);
    
    [Button]
    public void TestRemove() => RemoveScore(10);
}
