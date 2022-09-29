using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image image;
    [SerializeField] private Text text_count;
    [SerializeField] private GameObject go_CountImage;
    private GameObject m_Update;

    public ItemData _item;
    public int itemcount = 1;
    public void Start()
    {
        m_Update = GameObject.Find("InventoryUI");
    }
    public ItemData item
    {
        get { return _item; }
        set
        {
            _item = value;
            if(_item != null)
            {
                image.sprite = item.itemImg;
                image.color = new Color(1, 1, 1, 1);
                go_CountImage.SetActive(true);
                text_count.text = itemcount.ToString();
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
                go_CountImage.SetActive(false);
            }

        }
    }
    public void SetSlotCount(int _count)
    {
        itemcount += _count;
        text_count.text = itemcount.ToString();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null)
            {
               
                // �Һ�
                //Debug.Log(item.itemName + " �� ����߽��ϴ�.");
                SetSlotCount(-1);
                if (m_Update)
                {
                    m_Update.transform.GetChild(1).GetComponent<MonsterMake>().AddSlot(item, 1); //chile 0�� �κ��丮
                }
                else return;
                
            }
        }
    }
}
