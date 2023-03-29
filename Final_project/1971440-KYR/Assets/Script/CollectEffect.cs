using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEffect : MonoBehaviour
{
    public GameObject EffectPrefab;
    private GameObject effect;
    public void PlayEffect()
    {
        effect = Instantiate(EffectPrefab, transform.localPosition, transform.localRotation);
        Destroy(effect, 1);
    }
}
