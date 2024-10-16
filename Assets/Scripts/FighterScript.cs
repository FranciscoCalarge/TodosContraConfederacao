using UnityEngine;
using UnityEngine.VFX;

public class FighterScript : MonoBehaviour
{
    public VisualEffect effect;
    public Transform originTransform;
    public Transform enemyTransform;
    public Material healthBarMaterial;
    private float _initialHP = 60;
    private float _currentHP ;

    private void Start()
    {
        healthBarMaterial.SetFloat("_hp_percentage",1f);
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
        _initialHP-=damage;
        healthBarMaterial.SetFloat("_hp_percentage", _currentHP/_initialHP);


    }

}
