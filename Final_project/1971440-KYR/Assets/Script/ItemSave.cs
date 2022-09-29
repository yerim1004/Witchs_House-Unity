using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSave : MonoBehaviour //인벤토리 스크립트
{
    public List<ItemData> items; //플레이어가 사용해야 하니까 public 

    [SerializeField] private Transform slotParent;
    [SerializeField] private Slot[] slots;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    void Start()
    {
        FreshSlot();
    }
    private void Update()
    {
        
    }
    public void FreshSlot()
    {
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
            //Debug.Log("item 슬롯에 입력할 대 인덱스 " + i);
        }
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
            //Debug.Log("널인 슬롯 인덱스 " + i);
        }
    }
    public void AddItem(ItemData _item, int _count)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)  // null 이라면 slots[i].item.itemName 할 때 런타임 에러 나서
            {
                if (slots[i].item.itemName == _item.itemName)
                {
                    slots[i].SetSlotCount(_count);
                    FreshSlot();
                    return;
                }
            }
        }
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                //Debug.Log("inven null일 때 인덱스 " + i);
                items.Add(_item);
                slots[i].itemcount = _count;
                FreshSlot();
                return;
            }
        }
    }
}
