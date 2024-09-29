using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorScript : MonoBehaviour , I_Interactable
{
    public List<CardScript> cartasAcionadas;
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
        
    }

    public void QueueCard(CardScript cartaSelecionada)
    {
        if(cartaSelecionada != null&&!cartaSelecionada.isEnfileirada)
        {
            CardScriptO carta=cartaSelecionada.Enfileirar();
            if (carta != null) { 
                valorAtaque+=carta.valorAtaque;
                valorDefesa+=carta.valorDefesa;
                if (carta.isEspecial)
                {
                    isEspecial = carta.isEspecial;
                }
            }
            cartaSelecionada.isEnfileirada = true;
        }
        else
        {
            CardScriptO carta=cartaSelecionada.Enfileirar();
            if (carta != null)
            {
                valorAtaque -= carta.valorAtaque;
                valorDefesa -= carta.valorDefesa;
                if (carta.isEspecial)
                {
                    isEspecial = false;
                }
            }
            cartaSelecionada.isEnfileirada=false;
        }
    }
}
