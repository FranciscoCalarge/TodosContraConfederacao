using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationScript : MonoBehaviour
{
    public TextMeshPro text;
    float age;
    float maxAge=5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Mathf.Min( Time.deltaTime/Mathf.Sqrt(age),2f);
        age += Time.deltaTime;
        if(age > maxAge)
        {
            Destroy(gameObject);
        }
    }
}
