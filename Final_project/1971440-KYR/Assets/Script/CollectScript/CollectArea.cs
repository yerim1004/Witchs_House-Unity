using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectArea : MonoBehaviour
{
    //�÷��̾�� ������ ��ũ��Ʈ
    
    public bool collectAble;
    public GameObject collect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectableObject"))
        {
            
            collectAble = true;
            collect = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CollectableObject"))
        {
            //colliders.Remove(other);
            //Debug.Log("out");
            collectAble = false;
            collect = null;
        }
    }
    void Start()
    {

    }
    void Update()
    {

    }
}
