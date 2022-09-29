using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRespawn : MonoBehaviour
{
    //ä�� �Ĺ� ������ �Լ� -- Plane ��ü�� ������ ��ũ��Ʈ
    public List<Collider> colliders //ä������ ���� ����Ʈ, ä���������� �Ÿ��� ����ϱ� ����
    {
        get
        {
            if (0 < collectList.Count)
            {
                //����Ʈ�� ��ü �� ���� ���� �����Ͽ� colliderlist�� ���� �� ��ȯ
                collectList.RemoveAll(c => c == null);
            }
            return collectList;
        }
    }
    private List<Collider> collectList = new List<Collider>();

    public GameObject rangeObject;
    BoxCollider rangeCollider;

    public GameObject potion;//���߿� �̸� �ٲٱ�
    public GameObject coin;
    public GameObject clover;
    public float interval = 10.0f;

    void Start()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
        InvokeRepeating("CreateItem", 0.5f, interval);
    }
    void CreateCollect()
    {
        Vector3 originPosition = rangeObject.transform.position;
        // �ݶ��̴��� ����� �������� bound.size ���
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;

        int rnd = Random.Range(0, 3);
        switch (rnd) //rnd���� ���� �� Ÿ���� �������� �����Ѵ�.
        {
            case 0:
                Instantiate(potion, RandomPostion, transform.rotation);
                break;
            case 1:
                Instantiate(coin, RandomPostion, transform.rotation);
                break;
            case 2:
                Instantiate(clover, RandomPostion, transform.rotation);
                break;
        }
    }
}
