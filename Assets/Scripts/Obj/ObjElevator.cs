using UnityEngine;
using DG.Tweening;
using System;

public class ObjElevator : Obj
{
    public Transform doorLeft;
    public Transform doorRight;

    public float timeOpened = 3;
    public float timeDoorsMove = .5f;

    Vector3 doorOriginalScale;
    bool open;

    private void Awake()
    {
        doorOriginalScale = doorLeft.localScale;
    }
    
    public void Arrive(Action onElevatorGone)
    {
        SetDoorVisible(0).OnComplete(() =>
        {
            open = true;
            DOVirtual.DelayedCall(timeOpened, () =>
            {
                open = false;
                SetDoorVisible(1).OnComplete(() => 
                onElevatorGone());
            });
        });
    }

    //IEnumerator Arrive2(Action onElevatorGone)
    //{
    //    yield return SetDoorVisible(0).WaitForCompletion();
    //    open = true;
    //    yield return DOVirtual.DelayedCall(timeOpened, null).WaitForCompletion();
    //    open = false;
    //    yield return SetDoorVisible(1).WaitForCompletion();
    //    onElevatorGone();
    //}

    Tween SetDoorVisible(int state)
    {
        doorLeft.DOScaleX(state, timeDoorsMove);
        return doorRight.DOScaleX(state, timeDoorsMove);
    }

    public override void Action()
    {
        if (open)
        {
            doorLeft.localScale = doorOriginalScale;
            doorRight.localScale = doorOriginalScale;
            ScreenManager.instance.GoScreenOther();
        }
    }
}
