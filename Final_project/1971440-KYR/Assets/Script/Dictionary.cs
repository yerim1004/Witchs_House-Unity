using System;
using System.Collections.Generic;
using UnityEngine;
using GoogleSheetsToUnity;
using UnityEngine.Events;
using UnityEngine.Networking;

public class ItemInfo
{
    public string Name { get; set; }
    public string Image { get; set; } //�̹��� �ּ�
    public string Label { get; set; }
    public bool GetFlag { get; set; }
}

public class Dictionary : MonoBehaviour
{
    private string id = "1MS6TuH8nkX55AjyedwPfNtusWfTFXRqIN6RqxJhz1MQ";
    private string sheetname = "User";

    private List<ItemInfo> items = new List<ItemInfo>();
    public List<string> itemName = new List<string>() { "tomato", "r_meet", "n_chick" };

    public List<ItemInfo> itemlist
    {
        get
        {
            return items;
        }
    }
    void Start()
    {

        UpdateStats(Callback);

    }

    void DictCall()
    {
        //Debug.Log("�غ� ��");
        DictionaryItem dictionaryItem = new DictionaryItem();
        GameController playerList = new GameController();
        if (items.Count > 0)
        {
            dictionaryItem.SetItemList(items);
            playerList.SetItemList(items);
            //Debug.Log("�غ� ��2");
        }
        else
            Debug.Log("items NULL");
    }

    void UpdateStats(UnityAction<GstuSpreadSheet> callback, bool mergedCells = false)
    {
        //sheet �ҷ�����
        SpreadsheetManager.Read(new GSTU_Search(id, sheetname), callback, mergedCells);
    }

    void Callback(GstuSpreadSheet userSheet)
    {
        //�� ������ ������ ��������        
        foreach (string itemname in itemName)
        {
            UpdateCol(userSheet.rows[itemname], itemname);
        }
        //Debug.Log("data get");
        DictCall();
    }

    void UpdateCol(List<GSTU_Cell> row, string name)
    {
        ItemInfo info = new ItemInfo();

        info.Name = name;
    
        for (int i=0; i< row.Count; i++)
        {
            switch (row[i].columnId)
            {
                case "Image":
                    {
                        info.Image = row[i].value;
                        break;
                    }

                case "Label":
                    {
                        info.Label = row[i].value;
                        break;
                    }

                case "GetFlag":
                    {
                        info.GetFlag = Convert.ToBoolean(row[i].value);
                        break;
                    }
            }
        }
        items.Add(info);
    }
}

