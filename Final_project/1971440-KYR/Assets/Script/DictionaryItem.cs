using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryItem : MonoBehaviour
{
    //���� UI�� ����, ���� ������ ���� <- ItemInfo list �ޱ�
    
    private GameObject dictPrefab;
    private Image itemImage;

    private static GameObject ItemUI;
    private static GameObject MonsterUI;

    private List<float> gridPositionX = new List<float>() { 110.0f, 210.0f };
    private List<float> gridPositionY = new List<float>() { -100.0f, -100.0f };

    private static List<ItemInfo> itemlist;

    public void SetItemList(List<ItemInfo> list)
    {
        itemlist = list;

        SetDictUI_Item();
        SetDictUI_Monster();
    }
    private void SetDictUI_Item()
    {
        FindUI("Item");
        int j = 0;

        for (int i = 0; i < itemlist.Count; i++)
        {
            if (itemlist[i].Label != "Item")
                continue;
            
            //GameObject newDict = Instantiate(dictPrefab, ItemUI.transform);
            
            GameObject newDict = Instantiate(dictPrefab); //����
            RectTransform dictposition = newDict.GetComponent<RectTransform>(); // ��ġ �ʱ�ȭ

            dictposition.position = new Vector3(gridPositionX[j], gridPositionY[j], 0.0f);

            newDict.transform.SetParent(ItemUI.transform, false);
            newDict.name = itemlist[i].Name;

            itemImage = newDict.transform.Find("Button").gameObject.GetComponent<Image>();
            itemImage.sprite = Resources.Load<Sprite>(itemlist[i].Image);

            if (itemlist[i].GetFlag == false)
            {
                //ȹ������ ���� �������� ��
                itemImage.color = Color.black;
            }
            j++;
        }
    }

    private void SetDictUI_Monster()
    {
        FindUI("Monster");
        int j = 0;

        for (int i = 0; i < itemlist.Count; i++)
        {
            if (itemlist[i].Label != "Result")
                continue;
            
            GameObject newDict = Instantiate(dictPrefab); //����
            RectTransform dictposition = newDict.GetComponent<RectTransform>(); // ��ġ �ʱ�ȭ

            dictposition.position = new Vector3(gridPositionX[j], gridPositionY[j], 0.0f);

            newDict.transform.SetParent(MonsterUI.transform, false);
            newDict.name = itemlist[i].Name;

            itemImage = newDict.transform.Find("Button").gameObject.GetComponent<Image>();
            itemImage.sprite = Resources.Load<Sprite>(itemlist[i].Image);

            if (itemlist[i].GetFlag == false)
            {
                //ȹ������ ���� �������� ��
                itemImage.color = Color.black;
            }
            j++;
        }
    }
    public void FindUI(string UIname)
    {
        //dict ������ �ʱ�ȭ
        dictPrefab = Resources.Load<GameObject>("Prefabs/DictGrid");

        //�θ� �� ������Ʈ �ʱ�ȭ
        GameObject inventoryUI = GameObject.Find("InventoryUI").transform.Find("Dictionary").gameObject;

        if (UIname == "Item")
        {
            GameObject invenChild = inventoryUI.transform.Find("Item").gameObject.transform.Find("ItemView").gameObject;
            ItemUI = invenChild.transform.Find("ItemContent").gameObject;
        }
        else if (UIname == "Monster")
        {
            GameObject invenChild = inventoryUI.transform.Find("Monster").gameObject.transform.Find("MonsterView").gameObject;
            MonsterUI = invenChild.transform.Find("MonContent").gameObject;
        }

    }
    public void rePaint(string gridname)
    {
        //Debug.Log("RePaint");
        for (int j = 0; j < ItemUI.transform.childCount; j++)
            {
                GameObject child = ItemUI.transform.GetChild(j).gameObject;

                if (child.name == gridname)
                {
                Image childImg = child.transform.Find("Button").gameObject.GetComponent<Image>();

                    childImg.color = Color.white;

                    child.transform.Find("Text").gameObject.SetActive(true);
                }
            }
        
    }
}

