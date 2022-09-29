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
        //Debug.Log("������ ��" + _items.Count);
        updateSlot();
    }

    void Update()
    {
        
    }
    
    public void updateSlot()
    {
        int i = 0;
        //Debug.Log("update ��" + _items.Count);
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
                //Debug.Log("�� �ƴ� üũ" + makeslots[i].item.itemName + _item.itemName);
                if (makeslots[i].item.itemName == _item.itemName)
                {
                    makeslots[i].SetSlotCount(_count);
                    
                    updateSlot();
                    //Debug.Log("������ ���� �߰� �Ϸ�" + _item.itemName);
                    return;
                }
            }
        }
        for (int i = 0; i < makeslots.Length; i++)
        {
            //Debug.Log("������ �߰� �Լ�");
            if (makeslots[i].item == null)
            {
                _items.Add(_item);
                makeslots[i].itemcount = _count;
                
                updateSlot();
                //Debug.Log("������ �߰� �Ϸ�" + _item.itemName);
                return;
            }
        }
    }
    public void makeMonster() {
        for (int i = 0; i < makeslots.Length; i++)
        {
            if (makeslots[i].item != null)
            {
                Debug.Log("�� �ƴ� üũ" + recipt1);
                if (makeslots[i].item.itemName == recipt1)
                {
                    for (int j = 0; j < makeslots.Length; j++)
                    {
                        if (makeslots[j].item != null)
                        {
                            Debug.Log("�� �ƴ� üũ" + recipt2);
                            if (makeslots[j].item.itemName == recipt2)
                            {
                                Debug.Log("���� �Ϸ�!!");
                                //�̹��� �ϳ� ���� ���� �Ϸ� ǥ�����ֱ�
                                UI.SetActive(true); //���� �˸� �г� ture
                                //���� pos �ϳ� �� �տ� ���� �ű� �߿� �������� ������ֱ�
                                Instantiate(madeObj, success.position, success.rotation);
                                //�����ϸ� �� �� ������ ǥ�����ָ� ������ �̰� �ð� ������ ����
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
