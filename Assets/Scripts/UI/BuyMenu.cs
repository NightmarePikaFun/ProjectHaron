using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMenu : MonoBehaviour
{
    [SerializeField]
    private Text costDisplay;
    [SerializeField]
    private Button buyButton;

    private int currentId;
    private TraderUI traderUI;

    private void Awake()
    {
        buyButton.onClick.AddListener(Buy);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBuyInfo(bool active, int cost, int id)
    {
        currentId = id;
        if (active)
        {
            costDisplay.text = cost.ToString();
            buyButton.interactable = true;
        }
        else
        {
            costDisplay.text = "Sold";
            buyButton.interactable = false;
        }
    }

    public void SetTraderUI(TraderUI inputUI)
    {
        traderUI = inputUI;
    }

    public void Buy()
    {
        if (HaronLibrary.BuyItem(currentId))
            Debug.LogWarning("Succes");
        else
            Debug.LogError("Fail");
        Debug.Log(HaronLibrary.playerCoins);
        traderUI.UpdateUI();
    }
}
