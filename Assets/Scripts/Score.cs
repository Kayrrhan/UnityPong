using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _UIScore;
    private int _scorePlayer = 0;

    void Start()
    {
        _UIScore.text = _scorePlayer.ToString();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sphere"){
            _scorePlayer += 1;
            _UIScore.text = _scorePlayer.ToString();
        }
    }
}
