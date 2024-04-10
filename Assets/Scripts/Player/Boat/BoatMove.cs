using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    [SerializeField]
    private Vector2 boatMoveSpeed;
    [SerializeField]
    private int coin = 2;
    [SerializeField]
    private Vector3 finishPoint;

    [SerializeField]
    private GameObject tmpFinish;

    IdleGenerator idleGenerator;
    // Start is called before the first frame update
    void Start()
    {
        idleGenerator = GameObject.FindGameObjectWithTag("IdleGenerator").GetComponent<IdleGenerator>();
        tmpFinish.transform.position = finishPoint;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y+2.75f, -10);
        transform.Translate(Input.GetAxis("Horizontal")*new Vector2(1,0)*Time.deltaTime*Observer.GameSpeed);
        transform.Translate(boatMoveSpeed * Time.deltaTime * Observer.GameSpeed);
        if(finishPoint.y <= transform.position.y)
        {
            Debug.LogWarning("Deliver Complete");
            Observer.GameSpeed = 0;
        }
    }

    public void RemoveCoin()
    {
        Debug.LogWarning("U lose a Coin!");
        coin--;
        idleGenerator.DropCoinFromFace();
        if (coin<0)
        {
            Destroy(gameObject);
        }
    }
    
}
