using System.Collections;
using UnityEngine;

public class ScreenElevator : MonoBehaviour {

    public SpriteRenderer[] lights;
    public Color lightOn = Color.white;
    public Color lightOff = Color.gray;
    public float lightTime = 2;

    public Transform doorLeft;
    public Transform doorRight;

    private void OnEnable()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].color = lightOff;
        }

        StartCoroutine(LightsCR());
    }

    IEnumerator LightsCR()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].color = lightOn;
            yield return new WaitForSeconds(lightTime);

            if (i < lights.Length - 1)
            {
                lights[i].color = lightOff;
            }
        }

        ScreenManager.instance.GoScreenOther();
    }
}
