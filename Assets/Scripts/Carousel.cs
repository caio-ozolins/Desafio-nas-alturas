using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Carousel : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private float velocity = 5;

    private Vector3 _initialPosition;
    private float _realImageSize;
    private float _scale;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _initialPosition = transform.position;
        _scale = transform.localScale.x;
        _realImageSize = _spriteRenderer.size.x * _scale;
    }

    private void Update()
    {
        float displacement = Mathf.Repeat(velocity * Time.time, _realImageSize);
        transform.position = _initialPosition + Vector3.left * displacement;
    }
}
