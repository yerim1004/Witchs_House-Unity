using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictGrid : MonoBehaviour
{
    public Button button;
    public GameObject newText;
    public int index;
    public bool getItemFlag; 
    
    public void clickBtn()
    {
        newText = gameObject.transform.Find("Text").gameObject;

        newText.SetActive(false); //��ư ������ Ȯ�� �� -> new ǥ�ð� �������
    }
}
