using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSave : MonoBehaviour //�κ��丮 ��ũ��Ʈ
{
    public List<ItemData> items; //�÷��̾ ����ؾ� �ϴϱ� public 

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
            //Debug.Log("item ���Կ� �Է��� �� �ε��� " + i);
        }
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
            //Debug.Log("���� ���� �ε��� " + i);
        }
    }
    public void AddItem(ItemData _item, int _count)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)  // null �̶�� slots[i].item.itemName �� �� ��Ÿ�� ���� ����
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
                //Debug.Log("inven null�� �� �ε��� " + i);
                items.Add(_item);
                slots[i].itemcount = _count;
                FreshSlot();
                return;
            }
        }
    }
}
