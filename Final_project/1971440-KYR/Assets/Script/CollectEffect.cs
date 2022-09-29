using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEffect : MonoBehaviour
{
    public GameObject EffectPrefab;

    public void PlayEffect()
    {
        Instantiate(EffectPrefab, transform.localPosition, Quaternion.identity);
    }
}
