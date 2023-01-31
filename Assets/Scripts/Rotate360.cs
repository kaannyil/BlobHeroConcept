using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotate360 : MonoBehaviour
{
    private float time = 4;

    private void Start()
    {
        /*Vector3 movePosition = transform.position;
        movePosition.y += .5f;
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(transform.DOLocalRotate(new Vector3(0, 360, 0), time, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1,LoopType.Restart))
        .Append(transform.DOLocalMove(new Vector3 (this.transform.position.x,movePosition.y,this.transform.position.z), 1).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo));*/

        transform.DOLocalRotate(new Vector3(0, 360, 0), time, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }
}
