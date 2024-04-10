using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Boat")
        {
            Debug.LogWarning("Destroy boat!");
            Destroy(collision.gameObject);
        }
    }
}
