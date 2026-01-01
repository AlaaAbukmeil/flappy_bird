using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public void DestroyWithAnimation()
    {
        StartCoroutine(DestroyAnimation());
    }

    IEnumerator DestroyAnimation()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float duration = 0.4f;
        float elapsed = 0f;
        Color startColor = sr.color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            transform.position += Vector3.down * 5f * Time.deltaTime;

            sr.color = new Color(startColor.r, startColor.g, startColor.b, 1 - t);

            yield return null;
        }

        Destroy(gameObject);
    }
}