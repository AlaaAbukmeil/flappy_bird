using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public GameObject targetPrefab;
    public PipeScript pipeScript;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        pipeScript = GetComponentInParent<PipeScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow"))
        {
            return;
        }

        BirdScript bird = collision.GetComponent<BirdScript>();
        if (bird != null && bird.birdIsAlive)
        {
            logic.AddScore(1);
        }
    }
    public void TargetHit()
    {
        Debug.Log("TargetHit called");

        logic.AddScore(1);
        if (pipeScript != null)
        {
            Debug.Log("Opening pipe");
            pipeScript.OpenPipe();
        }
        else
        {
            Debug.Log("pipeScript is null!");
        }
    }
}
