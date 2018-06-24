using UnityEngine;

public class ObjTv : Obj {

    public Color[] colors;
    public Material materialColor;
    public float timeColorChange = .25f;

    float currentTime;
    int colorIndex;

    void Update ()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeColorChange)
        {
            currentTime -= timeColorChange;
            materialColor.color = colors[colorIndex++];
            colorIndex %= colors.Length;
        }
	}

    public override void Action()
    {
        enabled = !enabled;
        if (!enabled)
        {
            materialColor.color = Color.black;
        }
    }
}
