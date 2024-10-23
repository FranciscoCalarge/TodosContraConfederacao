using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardScript : MonoBehaviour, I_Interactable
{
    public CardScriptO cardScriptableObject;
    public bool isEnfileirada=false;
    public TextMeshProUGUI cardCostMesh;
    public TextMeshProUGUI cardValueMesh;
    public GameObject iconsObj;


    private Vector3 originPos;

    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
        InitiateCardVisual();   
    }

    void InitiateCardVisual()
    {
        if (cardScriptableObject.isAtaque)
        {
            iconsObj.transform.GetChild(0).gameObject.SetActive(true);
            cardCostMesh.text = cardScriptableObject.custoCarta.ToString();
            cardValueMesh.text = cardScriptableObject.valorAtaque.ToString();
        }
        else if (cardScriptableObject.isEspecial)
        {
            iconsObj.transform.GetChild(2).gameObject.SetActive(true);
            cardCostMesh.text = cardScriptableObject.custoCarta.ToString();
            cardValueMesh.text = "";

        }
        else
        {
            iconsObj.transform.GetChild(1).gameObject.SetActive(true);
            cardCostMesh.text = cardScriptableObject.custoCarta.ToString();
            cardValueMesh.text = cardScriptableObject.valorDefesa.ToString();
        }
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

    private void OnMouseEnter()
    {
        Activate();
    }

    public void Activate()
    {
        if (PlayerHandScript.Instance != null)
        {
            PlayerHandScript.Instance.DetermineActiveObject(this.transform);
        }
    }

    public void Interact()
    {
        if (OperatorScript.Instance != null) { 
            OperatorScript.Instance.QueueCard(this);
        }
    }

}
