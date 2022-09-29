using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private int hp = 3;
    public GameObject destroyEffectPrefab;
    private GameObject inven;
    public ItemData rabbitItem;
    
    private Animator m_animator;

    private int rnd;
    private float time = 0.0f;
    private float waitingTime = 2.0f;
    private bool isdead = false;
    void Start()
    {
        inven = GameObject.Find("InventoryUI");
        m_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > waitingTime)
        {
            rnd = Random.Range(0, 5); //적은 2초마다 랜덤으로 이동하기
            time = 0;
        }
        if (rnd == 0 && !isdead) { // 죽지 않았을 경우에만 이동
            transform.Translate(Vector3.right * Time.deltaTime * 1.0f);
            m_animator.SetFloat("Move", 1);
        }
        else if (rnd == 1 && !isdead) { 
            transform.Translate(Vector3.left * Time.deltaTime * 1.0f);
            m_animator.SetFloat("Move", 1);
        }        
        else if (rnd == 2 && !isdead) { 
            //transform.Translate(Vector3.forward * Time.deltaTime * 0.2f);
            m_animator.SetFloat("Move", 1);
        }     
        else if (rnd == 3 && !isdead) { 
            transform.Translate(Vector3.back * Time.deltaTime * 1.0f);
            m_animator.SetFloat("Move", 1);
        }
        else if (rnd == 4 && !isdead) m_animator.SetFloat("Move", 0);

    }
    public void Damage()
    {
        hp--;
        //Debug.Log(hp);
        if (hp <= 0)
        {
            m_animator.SetTrigger("Dead");
            isdead = true;
            inven.transform.GetChild(0).GetComponent<ItemSave>().AddItem(rabbitItem, 1);
            Destroy(gameObject, 5);
        }
    }
    public int GetHP()
    {
        return hp;
    }
    public void PlayEffect()
    {
        Instantiate(destroyEffectPrefab, transform.localPosition, Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        //트리거 공격 받으면 damage호출
        if (other.gameObject.tag == "Energy")
        {
            Damage();
            PlayEffect();
        }
    }
}
