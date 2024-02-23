using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class Plane : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float force;
    private SceneDirector _director;
    private Vector3 _initialPosition;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _initialPosition = transform.position;
    }

    private void Start()
    {
        _director = FindObjectOfType<SceneDirector>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fly();
        }
    }

    private void Fly()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rigidbody2D.simulated = false;
        _director.EndGame();
    }

    public void Restart()
    {
        transform.position = _initialPosition;
        _rigidbody2D.simulated = true;
    }
}
