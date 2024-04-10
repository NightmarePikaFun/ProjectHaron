using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Face;
    [SerializeField]
    private GameObject[] coin;
    [SerializeField]
    private SpriteRenderer coruption;

    private int currentCoinNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveCoin()
    {
        if (currentCoinNumber < coin.Length)
        {
            coin[currentCoinNumber].SetActive(false);
            currentCoinNumber++;
        }
    }

    public void SetCorruptionLevel(float alpha)
    {
        coruption.color = new Color(coruption.color.r, coruption.color.g, coruption.color.b, alpha);
    }
}
