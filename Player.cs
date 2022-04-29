using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform Camera;
    private bool isMoving=false;
    

    private void Start()
    {
        
    }

   
    private void Update()
    {
        if (isMoving) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow)) Move(Vector3.left);
        else if (Input.GetKeyDown(KeyCode.RightArrow)) Move(Vector3.right);
        else if (Input.GetKeyDown(KeyCode.UpArrow)) Move(Vector3.forward);
        else if (Input.GetKeyDown(KeyCode.DownArrow)) Move(Vector3.back);


    }

    private void Move(Vector3 displacement)
    {
        float duration = 0.3f;
        Vector3 endPosition = transform.position + displacement;
        Vector3 midPosition = Vector3.Lerp(transform.position, endPosition, 0.5f);
        midPosition.y = 2;

        var myTraslationSequence = DOTween.Sequence();
        myTraslationSequence.Append(transform.DOMove(midPosition, duration * 0.5f));
        myTraslationSequence.Append(transform.DOMove(endPosition, duration * 0.5f));
        myTraslationSequence.Append(Camera.DOShakePosition(0.1f));

        transform.DOMove(endPosition, duration);

        var mySquashSequence = DOTween.Sequence();
        mySquashSequence.Append(transform.DOScaleY(0.1f, duration * 0.3f));
        mySquashSequence.Append(transform.DOScaleY(1f, duration * 0.7f));

        isMoving = true;
        myTraslationSequence.onComplete += OnMoveCompleted;
        
    }
    private void OnMoveCompleted()
    {
        isMoving = false;
    }
}
