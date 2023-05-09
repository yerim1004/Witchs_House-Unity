using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 l_velocity;
    private Vector3 m_velocity;
    private Animator m_animator;

    public Transform Energy; //발사체
    public Transform SpawnPos;

    private CollectArea m_collectArea = null;
    public float m_moveSpeed = 2.0f;

    private GameObject inven;
    public ItemData collectItem;
    private static List<ItemInfo> itemlist; // = new List<ItemInfo>();
    private GameController GM = new GameController();

    void Start()
    {
        inven = GameObject.Find("InventoryUI");
        m_animator = GetComponent<Animator>();
        m_collectArea = GetComponentInChildren<CollectArea>();
    }

    void Update()
    {
        Move();
        PlayerLook();

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
        
        m_velocity.y = 0; //점프없음
        controller.Move(transform.TransformDirection(m_velocity) * m_moveSpeed * Time.deltaTime);
    }

    public void Collect()
    {
        m_animator.SetTrigger("Attack"); //채집과 사냥 모두 Attack 모션으로 통일

        if(m_collectArea.collect != null)
        {
            m_collectArea.collect.GetComponentInParent<CollectCreate>().StartCoroutine("ReCreate"); //파괴되었음을 전달
            GM.ItemAdd(collectItem, 1);

            Destroy(m_collectArea.collect);
            m_collectArea.collect.GetComponent<CollectEffect>().PlayEffect();
            m_collectArea.collect = null;
        }
        
    }
    private float xRotate = 0;
    private void PlayerLook()
    {
        xRotate = xRotate + Input.GetAxisRaw("Mouse X") * 3.55f;

        transform.eulerAngles = new Vector3(0, xRotate, 0);
    }
    
    public void setItemlist()
    {
        Dictionary dict = new Dictionary();
        itemlist = dict.itemlist;
    }
 }
