using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject puddle;
    private float waitTime, startWait = 0f, endWait = 6f;
    private Vector3 spawnPosition;
    public Vector3 spawnValues;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Obstacle());
    }

    // Update is called once per frame
    void Update()
    {
        waitTime = Random.Range(startWait, endWait);
    }

    IEnumerator Obstacle()
    {
        while (true)
        {
            spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);
            Instantiate(puddle, spawnPosition, gameObject.transform.rotation);

            yield return new WaitForSeconds(waitTime);
        }
    }
}
