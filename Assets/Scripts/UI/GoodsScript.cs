using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodsScript : MonoBehaviour
{
    [SerializeField]
    private int goodsId;
    [SerializeField]
    private Sprite goodsSprite;
    [SerializeField]
    private Image goodsImage;
    [SerializeField]
    private int goodsCost;
    [SerializeField]
    private GameObject soldIcon;
    [SerializeField]
    private GameObject selectedFrame;

    private GameObject buyMenu;

    private bool isActive = true;
    private void Awake()
    {
        goodsImage.sprite = goodsSprite;
        buyMenu = GameObject.FindGameObjectWithTag("BuyMenu");
        HaronLibrary.SetTraderItemsCost(goodsId, goodsCost);
        //CheckActive();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelected()
    {
        selectedFrame.SetActive(true);
        buyMenu.GetComponent<BuyMenu>().SetBuyInfo(isActive, goodsCost, goodsId);
    }

    public void SetDeselected()
    {
        selectedFrame.SetActive(false);
    }

    public void CheckActive(int selectedId)
    {
        if (goodsId != selectedId)
            selectedFrame.SetActive(false);
        else
            SetSelected();
        isActive = HaronLibrary.GetGoodsState(goodsId);
        soldIcon.SetActive(!isActive);
    }

}
