using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> waterPart;
    [SerializeField]
    private List<GameObject> obstacles;

    private FaceScript face;
    private HandHandler handHandler;
    private bool IsSwimed = true;
    private GameObject hand;
    private GameObject handUI;
    // Start is called before the first frame update
    void Start()
    {
        hand = GameObject.FindGameObjectWithTag("HandHandler");
        handUI = GameObject.FindGameObjectWithTag("HandUI");
        face = GameObject.FindGameObjectWithTag("Face").GetComponent<FaceScript>();
        handHandler = GameObject.FindGameObjectWithTag("Observer").GetComponent<HandHandler>();
        waterPart[2].GetComponent<IdleTilePart>().CreateObstacles(obstacles[0]);
        waterPart[3].GetComponent<IdleTilePart>().CreateObstacles(obstacles[0]);
        StartCoroutine(DeadWakeUp());
        handUI.SetActive(false);
        hand.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNextWaterPart()
    {
        GameObject oldFirstPart = waterPart[0];
        waterPart.Remove(oldFirstPart);
        oldFirstPart.transform.position = waterPart[waterPart.Count - 1].transform.position + new Vector3(0, 18, 0);
        oldFirstPart.GetComponent<IdleTilePart>().CreateObstacles(obstacles[0]);
        waterPart.Add(oldFirstPart);
    }

    private IEnumerator DeadWakeUp()
    {
        float randValue;
        bool[] fingerState = new bool[5];
        while(IsSwimed)
        {
            yield return new WaitForSeconds(15);
            if (Observer.GameSpeed < 1)
                continue;
            randValue = Random.Range(0, 10);
            if(randValue%3 == 0)
            {
                face.SetCorruptionLevel(0.33f);
                Debug.Log("HandsUp");
                yield return new WaitForSeconds(3);
                face.SetCorruptionLevel(0.66f);
                yield return new WaitForSeconds(2);
                face.SetCorruptionLevel(0.99f);
                yield return new WaitForSeconds(1);
                face.SetCorruptionLevel(0);
                face.gameObject.SetActive(false);
                handUI.SetActive(true);
                hand.gameObject.SetActive(true);
                for (int i = 0; i < fingerState.Length; i++)
                {
                    Observer.GameSpeed = 0.75f;
                    
                    fingerState[i] = Random.Range(0, 100) % 2 == 0;
                }
                Debug.Log(fingerState);
                handHandler.SetRightFingerState(fingerState);
                //Activate mechanics
            }
        }
        //random chance to wake up
        //stop time
        //Open hand
        //Create hand state
        //On hand state show needed elements
    }

    public void DropCoinFromFace()
    {
        face.RemoveCoin();
    }

    public void EnableFace()
    {
        handUI.SetActive(false);
        face.gameObject.SetActive(true);
        hand.gameObject.SetActive(false);
    }
}
