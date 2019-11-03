using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public GameObject targetObject;
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerUnit" && isTriggered == false)
        {
            isTriggered = true;
            Debug.Log("door triggered");
            removeObstacle();
        }
    }

    private void removeObstacle()
    {
        targetObject.transform.Translate(0, 5, 0);
    }
}
