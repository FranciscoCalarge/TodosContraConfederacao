using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Card Scriptable Object", menuName= "Card Scriptable Object")]
public class CardScriptO : ScriptableObject
{
    [Range(0,4)]public int custoCarta;
    public bool isAtaque;
    public bool isEspecial;
    [Range(0,20)] public int valorAtaque;
    [Range(0,20)] public int valorDefesa;



}
