using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMP : MonoBehaviour
{
    [SerializeField]
    private bool change = false;
    [SerializeField, Range(0, 1.2f)]
    private float gameSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(change)
        {
            Observer.GameSpeed = gameSpeed;
        }
    }
}
