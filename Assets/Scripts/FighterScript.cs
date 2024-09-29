using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FighterScript : MonoBehaviour
{
    public VisualEffect effect;

    void Attack()
    {
        effect.Play();
    }
}
