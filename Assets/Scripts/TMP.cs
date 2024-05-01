using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TMP : MonoBehaviour
{
    //TODO перенести в HaronLibrary
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
        if(Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("Styx");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene("Tavern");
        }
        if (change)
        {
            Observer.GameSpeed = gameSpeed;
        }
    }
}
