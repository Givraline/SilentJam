using System;
using System.Collections;
using System.Collections.Generic;
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
    }
    
    public void RemoveScore(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Frérot t'abuse");
        }
        _score -= value;
        _scoreText.text = _score.ToString();
    }

    [Button]
    public void TestAdd() => AddScore(10);
    
    [Button]
    public void TestRemove() => RemoveScore(10);
}
