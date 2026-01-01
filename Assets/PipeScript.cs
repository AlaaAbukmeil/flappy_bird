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
    public float openSpeed = 2f;

    void Start()
    {
    }
    public void Init(bool closed)
    {
        isClosed = closed;
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
    public void ClosePipe()
    {
        float topPipeY = -topPipe.transform.localPosition.y + openGap;
        bottomPipe.transform.localPosition = new Vector3(0, topPipeY, 0);
        target.SetActive(true);
    }
    public void OpenPipe()
    {
        isClosed = false;
        StartCoroutine(OpenPipeAnimation());
    }

    IEnumerator OpenPipeAnimation()
    {
        Vector3 targetPosition = new Vector3(0, -topPipe.transform.localPosition.y, 0);

        while (Vector3.Distance(bottomPipe.transform.localPosition, targetPosition) > 0.01f)
        {
            bottomPipe.transform.localPosition = Vector3.Lerp(
                bottomPipe.transform.localPosition,
                targetPosition,
                openSpeed * Time.deltaTime
            );
            yield return null;
        }

        bottomPipe.transform.localPosition = targetPosition;
    }
}
