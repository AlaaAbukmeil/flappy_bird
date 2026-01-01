using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            TargetScript apple = collision.GetComponent<TargetScript>();
            if (apple != null)
            {
                apple.DestroyWithAnimation();
            }
            else
            {
                Destroy(collision.gameObject);
            }

            PipeMiddleScript middle = collision.GetComponentInParent<PipeMiddleScript>();
            if (middle != null)
            {
                middle.TargetHit();
            }

            Destroy(gameObject);
        }
    }

}
