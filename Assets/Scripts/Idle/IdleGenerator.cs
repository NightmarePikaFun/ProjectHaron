using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> waterPart;
    [SerializeField]
    private List<GameObject> obstacles;
    // Start is called before the first frame update
    void Start()
    {
        waterPart[2].GetComponent<IdleTilePart>().CreateObstacles(obstacles[0]);
        waterPart[3].GetComponent<IdleTilePart>().CreateObstacles(obstacles[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNextWaterPart()
    {
        GameObject oldFirstPart = waterPart[0];
        waterPart.Remove(oldFirstPart);
        oldFirstPart.transform.position = waterPart[waterPart.Count - 1].transform.position+new Vector3(0,18,0);
        oldFirstPart.GetComponent<IdleTilePart>().CreateObstacles(obstacles[0]);
        waterPart.Add(oldFirstPart);
    }

    private void GenerateObstacles(Vector3 partPosition)
    {
        int[] obstaclesCount = new int[obstacles.Count];
        for(int i = 0; i < obstacles.Count; i++)
        {
            obstaclesCount[i] = Random.Range(0, 10);
        }

    }
}
