using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pipePrefab;
    public float spawnRate = 4f;
    private float timer = 0f;
    public float heightOffset = 4f;
    public float heightOffsetClosed = 2f;
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)   
        {
            timer += Time.deltaTime;
            return;
        }
        else
        {
            spawnPipe();
            timer = 0f;
        }

    }
    void spawnPipe()
    {
        float RandomValue = Random.value;
        float offset = RandomValue > 0.7f ? heightOffsetClosed : heightOffset;
        float lowestPoint = transform.position.y - offset;
        float highestPoint = transform.position.y + offset;
        GameObject newPipe = Instantiate(pipePrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        if (RandomValue > 0.7f)
        {
            newPipe.GetComponent<PipeScript>().isClosed = true;
        }
    }
}
