using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

public class CardScript : MonoBehaviour, I_Interactable
{
    public CardScriptO cardScriptableObject;
    public bool isEnfileirada=false;
    public TextMeshProUGUI cardCostMesh;
    public TextMeshProUGUI cardValueMesh;
    public GameObject iconsObj;


    private Vector3 originPos;
    public bool _hasInteracted;
    public float interactedCd;
    public bool HasInteracted { get => _hasInteracted; set => _hasInteracted=value; }

    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
        InitiateCardVisual();
        _hasInteracted = false;
        interactedCd = 0;
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
        float auxScale = Mathf.Clamp(interactedCd, 1, 1.25f);
        transform.localScale = Vector3.one * auxScale;

        if (_hasInteracted)
        {
            interactedCd += Time.deltaTime*10;
        }
        else
        {
            interactedCd= 0;
        }
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

    public void OnMouseExit()
    {
        _hasInteracted = false;
    }

    public void Activate()
    {
        if (PlayerHandScript.Instance != null)
        {
            PlayerHandScript.Instance.DetermineActiveObject(this.transform);
        }
        _hasInteracted = true;
    }

    public void Interact()
    {
        if (OperatorScript.Instance != null) { 
            OperatorScript.Instance.QueueCard(this);
        }
    }

}

