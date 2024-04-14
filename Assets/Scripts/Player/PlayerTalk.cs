using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerTalk : MonoBehaviour
{
    [SerializeField]
    private Sprite playerSprite;
    [SerializeField]
    private PlayerText[] playerTexts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string PlayerDialogText(string npcName)
    {
        return playerTexts[FindNpcId(npcName)].GetNextTextline();
    }

    public Sprite GetPlayerSprite()
    {
        return playerSprite;
    }

    public void ResetDialog(string npcName)
    {
        playerTexts[FindNpcId(npcName)].ResetTextlineNumber();
    }

    private int FindNpcId(string npcName)
    {
        int retValue = 0;
        foreach (PlayerText playerText in playerTexts)
        {
            if (playerText.nameNPC == npcName)
                break;
            retValue++;
        }
        return retValue;
    }
}

[Serializable]
public struct PlayerText
{
    public string nameNPC;
    public List<string> text;
    public int currentTextNumber;

    public string GetNextTextline()
    {
        string retValye = "";
        if(currentTextNumber < text.Count)
        {
            retValye = text[currentTextNumber++];
        }
        return retValye;
    }

    public void ResetTextlineNumber()
    {
        currentTextNumber = 0;
    }
}
