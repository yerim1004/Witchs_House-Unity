using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectArea : MonoBehaviour
{
    //�÷��̾�� ������ ��ũ��Ʈ
    //public List<Collider> colliders
    //{
    //    get
    //    {
    //        if (0 < colliderList.Count)
    //        {
    //            //����Ʈ�� ��ü �� ���� ���� �����Ͽ� colliderlist�� ���� �o ��ȯ
    //            colliderList.RemoveAll(c => c == null);
    //        }
    //        return colliderList;
    //    }
    //}
    //private List<Collider> colliderList = new List<Collider>();
    public bool collectAble;
    public GameObject collect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectableObject"))
        {
            //colliders.Add(other);
            //Debug.Log("in");
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
