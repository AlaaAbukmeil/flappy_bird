using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3;
    public float deadZone = -45;
    public bool isClosed = false;
    public GameObject topPipe;
    public GameObject bottomPipe;
    public GameObject target;
    public float openGap = 3f;
    void Start()
    {
        if (isClosed)
        {
            ClosePipe();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }

    }
    void ClosePipe()
    {
        float topPipeY = -topPipe.transform.localPosition.y + openGap;
        bottomPipe.transform.localPosition = new Vector3(0, topPipeY, 0);
        target.SetActive(true);
    }
    public void OpenPipe()
    {
        float topPipeY = -topPipe.transform.localPosition.y;
        bottomPipe.transform.localPosition = new Vector3(0, topPipeY, 0);
        target.SetActive(false);
        isClosed = false;
    }
}
