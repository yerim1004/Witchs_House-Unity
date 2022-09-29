using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterMake : MonoBehaviour
{
    
    public List<ItemData> _items;
    
    [SerializeField] private Transform slotParent;
    [SerializeField] private Transform mslotParent;
    [SerializeField] private Slot[] slots;
    [SerializeField] private Slot[] makeslots;

    private string recipt1 = "col1";
    private string recipt2 = "rabbit";

    public GameObject UI;
    public Transform success;
    public GameObject madeObj;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
        makeslots = mslotParent.GetComponentsInChildren<Slot>();
    }


    void Start()
    {
        //Debug.Log("시작할 때" + _items.Count);
        updateSlot();
    }

    void Update()
    {
        
    }
    
    public void updateSlot()
    {
        int i = 0;
        //Debug.Log("update 들어감" + _items.Count);
        for (; i < _items.Count && i < makeslots.Length; i++)
        {
            makeslots[i].item = _items[i];
            
        }
        for (; i < makeslots.Length; i++)
        {
            makeslots[i].item = null;
        }
    }
    public void AddSlot(ItemData _item, int _count)
    {
        for (int i = 0; i < makeslots.Length; i++)
        {
            if (makeslots[i].item != null) 
            {
                //Debug.Log("널 아님 체크" + makeslots[i].item.itemName + _item.itemName);
                if (makeslots[i].item.itemName == _item.itemName)
                {
                    makeslots[i].SetSlotCount(_count);
                    
                    updateSlot();
                    //Debug.Log("아이템 개수 추가 완료" + _item.itemName);
                    return;
                }
            }
        }
        for (int i = 0; i < makeslots.Length; i++)
        {
            //Debug.Log("아이템 추가 함수");
            if (makeslots[i].item == null)
            {
                _items.Add(_item);
                makeslots[i].itemcount = _count;
                
                updateSlot();
                //Debug.Log("아이템 추가 완료" + _item.itemName);
                return;
            }
        }
    }
    public void makeMonster() {
        for (int i = 0; i < makeslots.Length; i++)
        {
            if (makeslots[i].item != null)
            {
                Debug.Log("널 아님 체크" + recipt1);
                if (makeslots[i].item.itemName == recipt1)
                {
                    for (int j = 0; j < makeslots.Length; j++)
                    {
                        if (makeslots[j].item != null)
                        {
                            Debug.Log("널 아님 체크" + recipt2);
                            if (makeslots[j].item.itemName == recipt2)
                            {
                                Debug.Log("생성 완료!!");
                                //이미지 하나 만들어서 생성 완료 표시해주기
                                UI.SetActive(true); //성공 알림 패널 ture
                                //스폰 pos 하나 집 앞에 만들어서 거기 중에 랜덤으로 만들어주기
                                Instantiate(madeObj, success.position, success.rotation);
                                //가능하면 닭 몇 개인지 표시해주면 좋은데 이건 시간 남으면 ㄱㄱ
                                return;
                            }
                        }
                    }
                    return;
                }
            }
        }
    }
}
