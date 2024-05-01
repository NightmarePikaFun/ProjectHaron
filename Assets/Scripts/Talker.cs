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
    private float textDelay = 0.05f;
    [SerializeField]
    private GameObject talkingSection;
    

    private bool canTalk = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WriteText(string text, Sprite talkerSprite)
    {
        talkingSection.SetActive(true);
        canTalk = false;
        image.sprite = talkerSprite;
        StartCoroutine(SlowTextWriter(text));
    }

    public bool CanWriteText()
    {
        return canTalk;
    }

    public void CloseWindow()
    {
        canTalk = true;
        StopAllCoroutines();
        talkingSection.SetActive(false);
    }

    private IEnumerator SlowTextWriter(string text)
    {
        textField.text = "";
        foreach (char letter in text)
        {
            yield return new WaitForSeconds(textDelay);
            textField.text += letter;
        }
        canTalk = true;
    }
}
