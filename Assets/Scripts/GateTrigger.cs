using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateTrigger : MonoBehaviour
{
    public GameObject targetObject;
    private bool isTriggered = false;
    public float countDownTimer;
    public Text countDownDisplay;
    public Collider selfCollider;

    private void Start()
    {
        selfCollider = gameObject.GetComponent<BoxCollider>();
        countDownTimer = 5f;
        countDownDisplay.text = "Go to the next check point";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerUnit" && isTriggered == false)
        {
            isTriggered = true;
            Debug.Log("door triggered");
            selfCollider.enabled = false;
            //removeObstacle();
        }
    }

    private void Update()
    {
        if (isTriggered)
        {
            countDownTimer -= Time.deltaTime;
            countDownDisplay.text = "Gate Opening in: " + countDownTimer;
            
            if (countDownTimer < 0)
            {
                isTriggered = false;
                removeObstacle();
                countDownDisplay.text = "Go to the next check point";
                countDownTimer = 5f;
            }
        }
    }

    private void removeObstacle()
    {
        targetObject.transform.Translate(0, 5, 0);
    }
}
