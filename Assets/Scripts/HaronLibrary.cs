using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HaronLibrary
{
    public static int inventoryObjectCount = 7;
    public static bool playerCanMove = true;

    private static bool[] unlockedDialog = new bool[inventoryObjectCount];
    private static bool[] traderItems = new bool[] {true, true, true, true, true, true, true };
    private static int[] traderItemsCost = new int[inventoryObjectCount];
    private static string[] journalDialog = new string[inventoryObjectCount];
    private static bool[] playerInventory = new bool[inventoryObjectCount];

    //TODO tmp public
    public static int playerCoins = 10;

    public static bool BuyItem(int itemId)
    {
        bool retValue = false;
        if(playerCoins - traderItemsCost[itemId] >= 0 && !playerInventory[itemId])
        {
            playerCoins -= traderItemsCost[itemId];
            traderItems[itemId] = false;
            playerInventory[itemId] = true;
            retValue = true;
        }
        return retValue;
    }

    public static bool IsDialogUnlocked(int id)
    {
        return id < 0 ? false : unlockedDialog[id];
    }

    public static void ChangeGiftState(int id)
    {
        unlockedDialog[id] = true;
    }

    public static bool GetGoodsState(int id)
    {
        return traderItems[id];
    }

    public static bool GiveGift(int id)
    {
        bool retValue = false;
        if (playerInventory[id])
        {
            playerInventory[id] = false;
            retValue = true;
        }
        return retValue;
    }

    public static void SetTraderItemsCost(int id, int cost)
    {
        traderItemsCost[id] = cost;
    }
}

[Serializable]
public struct NpcTalkSystem
{
    public List<string> giftedText;
    public List<string> notGiftedText;
    public int giftId;
    public bool isGifted;
    public string textOnGift;
}
