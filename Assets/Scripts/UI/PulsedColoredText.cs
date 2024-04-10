using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulsedColoredText : MonoBehaviour
{
    [SerializeField]
    private List<Color> colors;

    private int number = 0;
    private Text coloredText;
    // Start is called before the first frame update
    void Awake()
    {
        coloredText = GetComponent<Text>();
        StartCoroutine(PulseColor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PulseColor()
    {
        yield return new WaitForSeconds(Random.Range(0,1f));
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            number++;
            if (number > colors.Count - 1)
            {
                number = 0;
            }
            coloredText.color = colors[number];
        }
    }
}
