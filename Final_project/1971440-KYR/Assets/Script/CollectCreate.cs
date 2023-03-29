using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCreate : MonoBehaviour
{
    public Transform pos;
    public GameObject collect_model;
    private GameObject collect;

    float waitingTime = 5.0f;
    private bool destroy = false;
    

    void Start()
    {
        pos = gameObject.transform;
        StartCreate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ReCreate()
    {
        Debug.Log("ä�� ��");

        yield return new WaitForSeconds(5.0f); //5�� ��ٸ��� �ν��Ͻ� ����
        
        StartCreate();
    }

    void StartCreate()
    {
        collect = Instantiate(collect_model, pos.position, pos.rotation);
        //�θ� �����ؼ� �ٸ� ��ũ��Ʈ���� �ش� ��ũ���� ���� ������ �����ϰ� ��
        collect.transform.SetParent(gameObject.transform, true); //true�� �������, false�� �θ���� ��ġ ����...�̶�� ������ �ôµ� �ݴ� ����
    }
}
