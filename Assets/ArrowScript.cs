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
            PipeMiddleScript middle = collision.GetComponentInParent<PipeMiddleScript>();
            if (middle != null)
            {
                middle.TargetHit();
            }
            else
            {
                Debug.Log("PipeMiddleScript is null");
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
    }
}

}
