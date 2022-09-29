using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCreate : MonoBehaviour
{
    public Transform pos;
    public GameObject collect;

    float timer;
    int waitingTime = 10;

    void Start()
    {
        pos = gameObject.transform;
        timer = 0.0f;
        Instantiate(collect, pos.position, pos.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime && collect == false) //파괴되어서 객체가 없는 상태면
        {
            Instantiate(collect, pos.position, pos.rotation);
            timer = 0.0f;
        }
    }
}
