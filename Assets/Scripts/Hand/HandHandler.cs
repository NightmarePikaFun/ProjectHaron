using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandHandler : MonoBehaviour
{
    [SerializeField]
    private Button amenButton;
    [SerializeField]
    private List<GameObject> aspects;

    private GameObject[] fingers;

    private Vector3 startPos = new Vector3(-94, 50);
    private Vector3 step = new Vector3(0, 30);
    private bool[] fingerState = new bool[5];
    private bool[] rightFingerState = new bool[5];
    private IdleGenerator idleGenerator;
    
    // Start is called before the first frame update
    void Awake()
    {
        idleGenerator = GameObject.FindGameObjectWithTag("IdleGenerator").GetComponent<IdleGenerator>();
        fingers = GameObject.FindGameObjectsWithTag("Finger");
        startPos = aspects[0].transform.localPosition;
        for(int i = 0; i < fingerState.Length; i++)
        {
            fingerState[i] = true;
        }
        ClearAspects();
        amenButton.onClick.AddListener(Amen);
        //TMP
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearAspects()
    {
        for (int i = 0; i < fingerState.Length; i++)
        {
            aspects[i].SetActive(false);
            fingers[i].GetComponent<FingerInteraction>().WakeUpFinger();
        }
    }

    public void SetRightFingerState(bool[] rightState)
    {
        StartCoroutine(WaitForAmen());
        int value = 0;
        rightFingerState = rightState;
        for (int i = 0; i < rightFingerState.Length; i++)
        {
            if (rightFingerState[i])
            {
                aspects[i].SetActive(true);
                aspects[i].transform.localPosition = startPos - value * step;
                value++;
            }
        }
    }

    public void ChangeFingerState(int number)
    {
        fingerState[number] = !fingerState[number];
    }

    private bool amenIsDo = false;

    private void Amen()
    {
        amenIsDo = true;
        int chance = 25;
        for(int i = 0; i < fingerState.Length; i++)
        {
            if (fingerState[i] == rightFingerState[i])
                chance += 15;
        }
        Debug.LogWarning("Your chance is "+chance+", Amen!");
        float randomValue = Random.Range(0, 99);
        Debug.LogWarning("Need chance " + randomValue);
        if (chance < randomValue)
        {
            GameObject.FindGameObjectWithTag("Boat").GetComponent<BoatMove>().RemoveCoin();  
        }
        Invoke("ContinueGame", 2);
        ClearAspects();
        idleGenerator.EnableFace();
    }

    public IEnumerator WaitForAmen()
    {
        yield return new WaitForSeconds(10);
        if (!amenIsDo)
        {
            Debug.LogError("yOu AmEn FaIl!");
            GameObject.FindGameObjectWithTag("Boat").GetComponent<BoatMove>().RemoveCoin();
            Invoke("ContinueGame", 2);
            ClearAspects();
            idleGenerator.EnableFace();
        }
    }

    public void ContinueGame()
    {
        Observer.GameSpeed = 1;
    }
    //Возможность потерять палец, шанс на молитву зависит от зажатых правильно пальцев N(0-5)*15% + 25%;
    //TODO вместо руки добавить голову, в монетами на глазах (потеря монеты, на лице она тоже теряется), активировать руку не сразу, а после некоторого времени 
    // с повялением прожилок красных на лице, чтобы человек подготовился
    // Баг что когда приплываем может прокнуть осквернение
    //подсказка 1.    жизнь коротка (умер) как и указатель показывающий на ее последствие.
}
