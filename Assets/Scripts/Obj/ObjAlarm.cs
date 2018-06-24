using UnityEngine;
using DG.Tweening;

public class ObjAlarm : Obj {

    public Material led;
    public float blinkTime = .5f;

    public Color colorLedOn;
    public Color colorLedOff;
    Tween blink;

	void Start ()
    {
        blink = DOVirtual.DelayedCall(blinkTime, () =>
        {
            led.color = led.color == colorLedOn ? colorLedOff : colorLedOn;
        }
        ).SetLoops(-1);
	}

    public override void Action()
    {
        blink.Kill();
        led.color = colorLedOff;
        GetComponent<Collider2D>().enabled = false;
    }
}

