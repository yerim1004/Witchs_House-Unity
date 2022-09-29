using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectArea : MonoBehaviour
{
    //플레이어에게 적용할 스크립트
    //public List<Collider> colliders
    //{
    //    get
    //    {
    //        if (0 < colliderList.Count)
    //        {
    //            //리스트의 객체 중 널인 것은 제거하여 colliderlist에 저장 훟 반환
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
