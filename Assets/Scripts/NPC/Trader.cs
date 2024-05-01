using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{

    [SerializeField]
    private GameObject traderUI;

    private bool inCollision = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inCollision && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("+");
            traderUI.SetActive(!traderUI.activeInHierarchy);
            HaronLibrary.playerCanMove = !traderUI.activeInHierarchy;
            traderUI.GetComponent<TraderUI>().OnOpenUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            inCollision = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inCollision = false;
            traderUI.SetActive(false);
            HaronLibrary.playerCanMove = true;
        }
    }
}
