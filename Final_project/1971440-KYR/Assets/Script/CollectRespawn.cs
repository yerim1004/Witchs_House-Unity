using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRespawn : MonoBehaviour
{
    //채집 식물 리스폰 함수 -- Plane 객체에 적용할 스크립트
    public List<Collider> colliders //채집물을 담을 리스트, 채집물끼리의 거리를 계산하기 위함
    {
        get
        {
            if (0 < collectList.Count)
            {
                //리스트의 객체 중 널인 것은 제거하여 colliderlist에 저장 후 반환
                collectList.RemoveAll(c => c == null);
            }
            return collectList;
        }
    }
    private List<Collider> collectList = new List<Collider>();

    public GameObject rangeObject;
    BoxCollider rangeCollider;

    public GameObject potion;//나중에 이름 바꾸기
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
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;

        int rnd = Random.Range(0, 3);
        switch (rnd) //rnd값에 따라 세 타입의 아이템을 생성한다.
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
