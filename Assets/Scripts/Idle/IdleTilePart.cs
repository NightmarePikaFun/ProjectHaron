using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTilePart : MonoBehaviour
{
    private GameObject IdleGenerator;
    // Start is called before the first frame update
    void Start()
    {
        IdleGenerator = GameObject.FindGameObjectWithTag("IdleGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Boat")
        {
            IdleGenerator.GetComponent<IdleGenerator>().SetNextWaterPart();
        }
    }

    public void CreateObstacles(GameObject obstacle)
    {
        Vector2Int[] parts = new Vector2Int[3];
        parts[0] = new Vector2Int(-9, -3);
        parts[1] = new Vector2Int(-3, 3);
        parts[2] = new Vector2Int(3, 9);
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < Random.Range(0, 6); j++)// -9 -3 / -3 3 // 3 9
            {
                GameObject createObstacle = Instantiate(obstacle);
                createObstacle.transform.position = transform.position + new Vector3(Random.Range(-2.1f, 2.1f), Random.Range(parts[i].x, parts[i].y), 0);
            }
        }
    }
}
