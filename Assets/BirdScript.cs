using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D myRigidbody;
    public float flapStrength = 15f;
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          myRigidbody.velocity = Vector2.up * flapStrength;
        }

    }
}
