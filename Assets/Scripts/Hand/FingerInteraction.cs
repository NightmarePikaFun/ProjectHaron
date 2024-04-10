using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerInteraction : MonoBehaviour
{
    [SerializeField]
    private int fingerNumber;
    [SerializeField]
    private Vector2 stateOn;
    [SerializeField]
    private Vector2 stateOff;
    [SerializeField]
    private bool state = true;

    private GameObject observer;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        observer = GameObject.FindGameObjectWithTag("Observer");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        state = !state;
        if (state)
        {
            transform.localPosition = stateOn;
            spriteRenderer.sortingOrder = 0;

        }
        else
        {
            transform.localPosition = stateOff;
            spriteRenderer.sortingOrder = 3;
        }
        observer.GetComponent<HandHandler>().ChangeFingerState(fingerNumber);
    }
}
