using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIOnOff : MonoBehaviour
{
    public GameObject UI;
    
    public void ActiveSetting()
    {
        UI.SetActive(!UI.active);
    }
}
