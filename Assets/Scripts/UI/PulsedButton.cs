using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulsedButton : MonoBehaviour
{
    [SerializeField]
    private Text pulseText;
    [SerializeField]
    private Vector2Int pulseRange;
    [SerializeField]
    private bool canWait = false;
    // Start is called before the first frame update
    void Awake()
    {
        if(pulseText == null)
            pulseText = GetComponent<Text>();
        pulseText.fontSize = pulseRange.x;
        StartCoroutine(Pulse());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Pulse()
    {
        if (canWait)
            yield return new WaitForSeconds(Random.Range(0, 0.5f));
        int addedNumber = 1;
        while(true)
        {
            yield return new WaitForSeconds(0.05f);
            pulseText.fontSize += addedNumber;
            if (pulseText.fontSize > pulseRange.y)
                addedNumber = -1;
            if (pulseText.fontSize < pulseRange.x)
                addedNumber = 1;

        }
    }//TODO text Φωτιά Εδαφος Ανεμος Ποτάμι Θάνατος
    //Fire Soil River Wind Death
    //TODO tmp coords 0.02 1.5
}
