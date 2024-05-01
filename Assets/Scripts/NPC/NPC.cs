using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private string npcName;
    [SerializeField]
    private Text helperText;

    [SerializeField]
    private Sprite npcFace;
    [SerializeField]
    private NpcTalkSystem npcTalkSystem;


    private List<string> text;
    private int currentTextNumber = 0;
    private Talker talker;
    private bool inCollision = false;
    private bool isStartDialog = true;
    private GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {
        npcTalkSystem.isGifted = HaronLibrary.IsDialogUnlocked(npcTalkSystem.giftId);
    }

    void Start()
    {
       talker = GameObject.FindGameObjectWithTag("Talker").GetComponent<Talker>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inCollision && Input.GetKeyDown(KeyCode.F))
        {
            if (isStartDialog)
                SelectText();
            if(talker.CanWriteText())
            {
                if (currentTextNumber < text.Count)
                {
                    talker.WriteText(text[currentTextNumber++], npcFace);
                }
                else
                {
                    currentTextNumber = 0;
                    isStartDialog = true;
                    talker.CloseWindow();
                }
            }
        }
    }

    private void SelectText()
    {
        isStartDialog = false;
        if (!npcTalkSystem.isGifted)
        {
            if (HaronLibrary.GiveGift(npcTalkSystem.giftId))
            {
                npcTalkSystem.isGifted = true;
                text = new List<string>() { npcTalkSystem.textOnGift };
                HaronLibrary.ChangeGiftState(npcTalkSystem.giftId);
            }
            else
            {
                text = npcTalkSystem.notGiftedText;
            }
        }
        else
        {
            text = npcTalkSystem.giftedText;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            ChangeHelperState();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isStartDialog = true;
            player = null;
            ChangeHelperState();
            talker.CloseWindow();
            currentTextNumber = 0;
        }
    }

    private void ChangeHelperState()
    {
        inCollision = !inCollision;
        helperText.gameObject.SetActive(inCollision);
    }
}
