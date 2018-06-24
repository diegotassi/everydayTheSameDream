using UnityEngine;
using DG.Tweening;

public class ObjButton : Obj
{
    public Material button;
    public Color colorCall;
    public ObjElevator objElevator;
    public float timeElevatorCome = 3;

    Color colorOriginal;

    private void Awake()
    {
        colorOriginal = button.color;
    }

    public override void Action()
    {
        if (button.color == colorOriginal)
        {
            button.color = colorCall;
            DOVirtual.DelayedCall(timeElevatorCome, () => objElevator.Arrive(OnElevatorGone));
        }
    }

    void OnElevatorGone()
    {
        button.color = colorOriginal;
    }
}
