using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    [SerializeField]
    private Vector2 boatMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, -10);
        transform.Translate(Input.GetAxis("Horizontal")*new Vector2(1,0)*Time.deltaTime*Observer.GameSpeed);
        transform.Translate(boatMoveSpeed * Time.deltaTime * Observer.GameSpeed);
    }

    
}
