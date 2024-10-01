using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class FighterScript : MonoBehaviour
{
    public VisualEffect effect;
    public Transform originTransform;
    public Transform enemyTransform;
    public Slider hpCanvasSlider;
    private float hp = 60;

    private void Start()
    {
        hpCanvasSlider.value += 1;
        Attack();

    }

    public void Attack()
    {
        effect.SetVector3("obj", originTransform.position);
        effect.SetVector3("target", enemyTransform.position);
        effect.Play();
    }

    public void TakeDamage(float damage)
    {
        hp-=damage;
        hpCanvasSlider.value=hp/60;

    }

}
