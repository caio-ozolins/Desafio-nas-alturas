using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float velocity = 5;
    [SerializeField]
    private float yVariation;
    private Vector3 _planePosition;
    private bool _hasScored;
    private Score _score;

    private void Awake()
    {
        transform.Translate(Vector3.up * Random.Range(-yVariation, yVariation));
    }

    private void Start()
    {
        _planePosition = FindObjectOfType<Plane>().transform.position;
        _score = FindObjectOfType<Score>();
    }

    private void Update()
    {
        transform.Translate(Vector3.left * (velocity * Time.deltaTime));
        if (transform.position.x < _planePosition.x && !_hasScored)
        {
            _score.IncreaseScore();
            _hasScored = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D obstacle)
    {
        DestroyObject();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
