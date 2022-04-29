using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LookAt : MonoBehaviour
{
    

    private void Start()
    {
        var seq = DOTween.Sequence();
        seq.AppendInterval(1f);
        seq.Append(GetComponent<Camera>().DOFieldOfView(70f, 0.5f));
        
    }

   
    private void Update()
    {
        
    }
}
