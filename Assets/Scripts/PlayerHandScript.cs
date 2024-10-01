using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;



public class PlayerHandScript : MonoBehaviour
{
    public List<GameObject> CardPrefabs;
    public GameObject CursorPrefab;
    public Transform handTransform;
    public int maxCards = 5;

    public List<GameObject> cards = new List<GameObject>();
    public List<GameObject> interactables = new List<GameObject>();

    private Transform _currentActiveObject;
    private Transform _cursorObj;   
    private int _cursorIndex;
    


    // Start is called before the first frame update
    void Start()
    {
        cards.Clear();
        
        if(OperatorScript.Instance!=null)cards.Add(OperatorScript.Instance.gameObject);

        for (int i = 0; i < maxCards; i++)
        {
            GameObject card = Instantiate(CardPrefabs[Mathf.FloorToInt(Random.value*3)], handTransform.position,Quaternion.identity, handTransform);
            card.transform.position = new Vector3(Mathf.InverseLerp(0, maxCards, i) * maxCards - maxCards / 2, 0, 0)+transform.position;
            cards.Add(card);
            
        }
        _currentActiveObject = cards[0].transform;
        _cursorObj = Instantiate(CursorPrefab).transform;
    }

    // Update is called once per frame
    void Update()
    {
        _cursorObj.position = _currentActiveObject.position+new Vector3(.2f,.8f,0)+new Vector3(0,Mathf.Sin(Time.time*5)*.1f,0);
        if (Input.GetKeyDown(KeyCode.D))
        {
            _currentActiveObject = cards[(int)Mathf.Repeat(++_cursorIndex,cards.Count)].transform;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _currentActiveObject=cards[(int)Mathf.Repeat(--_cursorIndex, cards.Count)].transform;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject obj = _currentActiveObject.gameObject;
            obj.GetComponent<I_Interactable>().Interact();
        }
    }
}
