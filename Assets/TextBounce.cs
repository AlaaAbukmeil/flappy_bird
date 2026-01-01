using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBounce : MonoBehaviour
{
    public float bounceHeight = 20f;
    public float bounceSpeed = 2f;
    public float scaleAmount = 0.2f;

    private Vector3 startPos;
    private Vector3 startScale;

    void Start()
    {
        startPos = transform.position;
        startScale = transform.localScale;
    }

    void Update()
    {
        float bounce = Mathf.Sin(Time.unscaledTime * bounceSpeed) * bounceHeight;
        transform.position = startPos + Vector3.up * bounce;

        float scale = 1f + Mathf.Sin(Time.unscaledTime * bounceSpeed) * scaleAmount;
        transform.localScale = startScale * scale;
    }
}