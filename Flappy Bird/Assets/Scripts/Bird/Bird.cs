using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    private BirdController _control;
    private int _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _control = GetComponent<BirdController>(); 
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void ResetPlayer()
    {
        _score = 0;
        _control.ResetBird();
    }

    public void Die()
    {
        GameOver?.Invoke();
        Time.timeScale = 0;
    }
}
