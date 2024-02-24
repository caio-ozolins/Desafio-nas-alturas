using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int _score;
    [SerializeField]
    private Text textScore;
    
    public void IncreaseScore()
    {
        _score++;
        textScore.text = _score.ToString();
    }

    public void RestartScore()
    {
        _score = 0;
        textScore.text = _score.ToString();
    }
}
