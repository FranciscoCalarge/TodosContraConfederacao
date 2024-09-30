using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour, I_Interactable
{
    public CardScriptO cardScriptableObject;
    public bool isEnfileirada=false;

    private Vector3 originPos;

    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnfileirada)
        {
            transform.position = originPos + Vector3.up * .2f;
        }
        else
        {
            transform.position = originPos;
        }
    }

    public void Interact()
    {
        if (OperatorScript.Instance != null) { 
            OperatorScript.Instance.QueueCard(this);
        }
    }

}
