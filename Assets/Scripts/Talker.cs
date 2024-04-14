using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talker : MonoBehaviour
{
    [SerializeField]
    private Text textField;
    [SerializeField]
    private Image image;
    [SerializeField]
    private float textDelay = 0.2f;
    [SerializeField]
    private GameObject talkingSection;

    private List<Sprite> spriteTalkerQueue;
    private List<string> talkQueue;
    private bool talking = false;

    private bool windowState = false;
    // Start is called before the first frame update
    void Start()
    {
        talkQueue = new List<string>();
        spriteTalkerQueue = new List<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteText(string text, Sprite talkerSprite)
    {
        windowState = true;
        talkingSection.SetActive(true);
        if (talking)
        {
            talkQueue.Add(text);
            spriteTalkerQueue.Add(talkerSprite);
        }
        else
        {
            image.sprite = talkerSprite;
            talking = true;
            StartCoroutine(SlowTextWriter(text));
        }
        
    }

    public void CloseWindow()
    {
        windowState = false;
        if(!talking)
            talkingSection.SetActive(false);
    }

    public void ImmidiatlyCloseWindow()
    {
        windowState = false;
        talkQueue.Clear();
        spriteTalkerQueue.Clear();
        talkingSection.SetActive(false);
        StopAllCoroutines();
    }

    private IEnumerator SlowTextWriter(string text)
    {
        textField.text = "";
        foreach (char letter in text)
        {
            yield return new WaitForSeconds(textDelay);
            textField.text += letter;
        }
        talking = false;
        if(talkQueue.Count > 0)
        {
            yield return new WaitForSeconds(3);
            string talkText = talkQueue[0];
            Sprite talkerSprite = spriteTalkerQueue[0];
            talkQueue.RemoveAt(0);
            spriteTalkerQueue.RemoveAt(0);
            WriteText(talkText, talkerSprite);
        }
        else
        {
            if (!windowState)
                talkingSection.SetActive(false);
        }
    }
}
