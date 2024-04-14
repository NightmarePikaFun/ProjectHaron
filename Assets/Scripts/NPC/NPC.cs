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
    private List<string> text;
    [SerializeField]
    private Sprite npcFace;
    [SerializeField]
    private bool dialogeState = true; //true - NPC, false - player
    [SerializeField]
    private bool isReapiting = false;

    private GameObject player;
    private int currentTextNumber = 0;
    private Talker talker;
    private bool inCollision = false;
    // Start is called before the first frame update
    void Start()
    {
       talker = GameObject.FindGameObjectWithTag("Talker").GetComponent<Talker>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inCollision && Input.GetKeyDown(KeyCode.F))
        {
            //TODO check start dialog
            if (currentTextNumber < text.Count)
            {
                if(dialogeState)
                {
                    talker.WriteText(text[currentTextNumber++], npcFace);
                }
                else
                {
                    string playerText = player.GetComponent<PlayerTalk>().PlayerDialogText(npcName);
                    if (playerText != "")
                        talker.WriteText(playerText, player.GetComponent<PlayerTalk>().GetPlayerSprite());
                    else
                        talker.WriteText(text[currentTextNumber++], npcFace);
                }
                dialogeState = !dialogeState; 
            }
            else
            {
                if (isReapiting)
                {
                    currentTextNumber = 0;
                    player.GetComponent<PlayerTalk>().ResetDialog(npcName);
                }
                talker.CloseWindow();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ChangeHelperState();
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ChangeHelperState();
            currentTextNumber = 0;
            talker.ImmidiatlyCloseWindow();
            player.GetComponent<PlayerTalk>().ResetDialog(npcName);
            player = null;
        }
    }

    private void ChangeHelperState()
    {
        inCollision = !inCollision;
        helperText.gameObject.SetActive(inCollision);
    }
}
