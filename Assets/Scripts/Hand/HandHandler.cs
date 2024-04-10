using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandHandler : MonoBehaviour
{
    [SerializeField]
    private Button amenButton;
    private bool[] fingerState = new bool[5];
    private bool[] rightFingerState = new bool[5];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < fingerState.Length; i++)
        {
            fingerState[i] = true;
        }
        amenButton.onClick.AddListener(Amen);
        //TMP
        GetRightFingerState(new bool[] { false, true, false, true, true });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetRightFingerState(bool[] rightState)
    {
        rightFingerState = rightState;
    }

    public void ChangeFingerState(int number)
    {
        fingerState[number] = !fingerState[number];
    }

    private void Amen()
    {
        int chance = 25;
        for(int i = 0; i < fingerState.Length; i++)
        {
            if (fingerState[i] == rightFingerState[i])
                chance += 15;
        }
        Debug.LogWarning("Your chance is "+chance+", Amen!");
    }
    //¬озможность потер€ть палец, шанс на молитву зависит от зажатых правильно пальцев N(0-5)*15% + 25%;
}
