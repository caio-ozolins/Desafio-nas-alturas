using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField]
    private float generatorInterval;
    private float _generatorStopwatch;
    [SerializeField]
    private GameObject obstacle;

    private void Awake()
    {
        _generatorStopwatch = generatorInterval;
    }

    private void Update()
    {
        _generatorStopwatch -= Time.deltaTime;
        if (_generatorStopwatch < 0)
        {
            Instantiate(obstacle, transform.position, Quaternion.identity);
            _generatorStopwatch = generatorInterval;
        }
    }
}
