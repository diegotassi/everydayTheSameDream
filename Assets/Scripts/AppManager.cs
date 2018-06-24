using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class AppManager : MonoBehaviour {

    public Image imageBlack;

    public static AppManager instance;

    void Awake()
    {
        instance = this;	
	}

    public void FadeIn(Action callback = null)
    {
        imageBlack.gameObject.SetActive(true);
        imageBlack.color = Color.black;
        imageBlack.DOFade(0, .5f).OnComplete(() =>
        {
            imageBlack.gameObject.SetActive(false);
            if (callback != null)
            {
                callback();
            }
        });
    }

    public void FadeOut(Action callback)
    {
        //SetInput(false);
        imageBlack.gameObject.SetActive(true);
        imageBlack.color = Color.clear;
        imageBlack.DOFade(1, .5f).OnComplete(() => {
            //SetInput(true);
            callback();
        });
    }

    public void FadeOutIn(Action action)
    {
        FadeOut(() =>
        {
            action();
            FadeIn();
        });
    }

    public void ShowBlackScreen(Action callback)
    {
        imageBlack.color = Color.black;
        imageBlack.gameObject.SetActive(true);
        DOVirtual.DelayedCall(1, () => callback());
    }
}
