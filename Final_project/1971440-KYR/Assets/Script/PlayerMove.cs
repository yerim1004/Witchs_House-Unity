using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 m_velocity;
    private Animator m_animator;

    public Transform Energy; //발사체
    public Transform SpawnPos;

    private CollectArea m_collectArea = null;
    public float m_moveSpeed = 2.0f;

    private GameObject inven;
    public ItemData collectItem;
    void Start()
    {
        inven = GameObject.Find("InventoryUI");
        m_animator = GetComponent<Animator>();
        m_collectArea = GetComponentInChildren<CollectArea>();
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.G) && m_collectArea.collectAble) //채집가능 대상이 범위에 있으면서 G키를 누르면 채집
        {
            Collect();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_animator.SetTrigger("Attack");
            Instantiate(Energy, SpawnPos.position, SpawnPos.rotation);
        }
    }
    private void Move()
    {
        CharacterController controller = GetComponent<CharacterController>();
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        m_velocity = new Vector3(h, 0, v);
        m_velocity = m_velocity.normalized;

        m_animator.SetFloat("Move", m_velocity.magnitude);

        if (m_velocity.magnitude > 0.5)
        {
            transform.LookAt(transform.position + m_velocity);
        }

        m_velocity.y = 0; //점프없음
        controller.Move(m_velocity * m_moveSpeed * Time.deltaTime);
    }

    public void Collect()
    {
        
        m_animator.SetTrigger("Attack"); //다른 모션이 없어서 채집과 사냥 모두 Attack 모션으로 통일

        if(m_collectArea.collect != null)
        {
            Destroy(m_collectArea.collect);
            inven.transform.GetChild(0).GetComponent<ItemSave>().AddItem(collectItem, 1);
        }
        
        //Vector3 center = Vector3.zero;
        //int cnt = m_collectArea.colliders.Count;
        //int cntBreak = 0;

        //for (int i = 0; i < m_collectArea.colliders.Count; i++)
        //{
        //    var collider = m_collectArea.colliders[i];
        //    center += collider.transform.localPosition;

        //    var obj = collider.GetComponent<CollectArea>();
        //    if (obj != null)
        //    {
        //        Destroy(obj);
        //        inven.transform.GetChild(0).GetComponent<ItemSave>().AddItem(collectItem, 1);
        //        Debug.Log("obj check");
        //    }
        //    else
        //    {
        //        Destroy(collider.gameObject);
        //        Debug.Log("else");
        //    }
        //}
        //if (cntBreak > 0) m_collectArea.colliders.Clear();

        //center /= cnt;
        //center.y = transform.localPosition.y;
        //transform.LookAt(center);


    }

}
