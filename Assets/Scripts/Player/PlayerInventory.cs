using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private bool[] inventoryItem;

    private void Awake()
    {
        inventoryItem = new bool[HaronLibrary.inventoryObjectCount];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GiveGift(int giftId)
    {
        return inventoryItem[giftId];
    }
}
