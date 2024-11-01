using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorScript : MonoBehaviour , I_Interactable
{
    public List<CardScript> cartasAcionadas;
    public FighterScript fighterScript;

    public GameObject notificationPrefab;
    public static OperatorScript Instance;

    public int valorAtaque=0;
    public int valorDefesa=0;
    public bool isEspecial=false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else if(Instance!=null && Instance != this)
        {
            Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log("acionar");
        StartCoroutine("PlayCards");
    }

    public void QueueCard(CardScript cartaSelecionada)
    {
        if(cartaSelecionada != null&&!cartaSelecionada.isEnfileirada)
        {
            CardScript carta=cartaSelecionada;
            if (carta != null) { 
                valorAtaque+=carta.cardScriptableObject.valorAtaque;
                valorDefesa+=carta.cardScriptableObject.valorDefesa;
                if (carta.cardScriptableObject.isEspecial)
                {
                    isEspecial = carta.cardScriptableObject.isEspecial;
                }
            }
            cartaSelecionada.isEnfileirada = true;
            cartasAcionadas.Add(carta);
        }
        else
        {
            CardScript carta=cartaSelecionada;
            if (carta != null)
            {
                valorAtaque -= carta.cardScriptableObject.valorAtaque;
                valorDefesa -= carta.cardScriptableObject.valorDefesa;
                if (carta.cardScriptableObject.isEspecial)
                {
                    isEspecial = false;
                }
            }
            cartasAcionadas.Remove(carta);
            cartaSelecionada.isEnfileirada=false;
        }
    }

    public IEnumerator PlayCards()
    {
        
        for(int i =0; i<cartasAcionadas.Count;i++){
            GameObject aux = Instantiate(notificationPrefab,this.transform);
            aux.GetComponent<NotificationScript>().text.text = cartasAcionadas[i].GetComponent<CardScript>().cardScriptableObject.isAtaque.ToString()+ "é um ataque";
            fighterScript.TakeDamage(15);
            fighterScript.Attack();
            yield return new WaitForSeconds(2);

        }
        yield return null;
    }
}
