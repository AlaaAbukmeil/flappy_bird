using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D myRigidbody;
    public float flapStrength = 4f;
    public LogicScript logic;
    public GameObject arrowPrefab;
    public Transform shootPoint;
    public bool birdIsAlive = true;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
          myRigidbody.velocity = Vector2.up * flapStrength;
        }
        if (Input.GetKeyDown(KeyCode.F) && birdIsAlive)
        {
            Shoot();
        }
        if (transform.position.y > 5 || transform.position.y < -5)
        {
            logic.gameOver();
            birdIsAlive = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
    void Shoot()
    {
        Instantiate(arrowPrefab, shootPoint.position, arrowPrefab.transform.rotation);
    }
}
