using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraderUI : MonoBehaviour
{
    [SerializeField]
    private Button nextButton;
    [SerializeField]
    private Button prevButton;
    [SerializeField]
    private GameObject[] items;
    [SerializeField]
    private BuyMenu buyMenu;

    private int currentItem = 0;

    private void Awake()
    {
        try
        {
            prevButton.onClick.AddListener(NextItem);
            nextButton.onClick.AddListener(PrevItem);
        }
        catch
        {
            Debug.LogWarning("Can't load button");
        }

        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //TODO TMPs
        OnOpenUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) && currentItem+1 < items.Length)
        {
            NextItem();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && currentItem-1 >= 0)
        {
            PrevItem();
        }
        if (Input.GetKeyDown(KeyCode.Return))
            buyMenu.Buy();
    }

    public void OnOpenUI()
    {
        buyMenu.SetTraderUI(this);
        UpdateUI();
        //prevButton.interactable = false;
        currentItem = 0;
    }

    public void UpdateUI()
    {
        foreach (GameObject item in items)
        {
            item.GetComponent<GoodsScript>().CheckActive(currentItem);
        }
    }

    public void OnCloseUI()
    {
        HaronLibrary.playerCanMove = true;
    }

    private void NextItem()
    {
        items[currentItem].GetComponent<GoodsScript>().SetDeselected();
        currentItem++;
        items[currentItem].GetComponent<GoodsScript>().SetSelected();
        /*if (currentItem + 1 >= items.Length)
            nextButton.interactable = false;
        if(currentItem > 0)
            prevButton.interactable = true;*/
    }

    private void PrevItem()
    {
        items[currentItem].GetComponent<GoodsScript>().SetDeselected();
        currentItem--;
        items[currentItem].GetComponent<GoodsScript>().SetSelected();
        /*if (currentItem - 1 <= 0)
            prevButton.interactable = false;
        if (currentItem < items.Length-1)
            nextButton.interactable = true;*/
    }

}
