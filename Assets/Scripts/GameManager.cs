using UnityEngine;

public class GameManager : MonoBehaviour {

    public Man man;

    public static GameManager instance;

    [HideInInspector] public Obj currentObject;
    [HideInInspector] public int pendingDays = 5;
        
    void Awake()
    {
        instance = this;
	}

    public void NewDay()
    {
        if (--pendingDays == 0)
        {
            GameOver();
            return;
        }

        ScreenManager.instance.Reset();


    }

    void GameOver()
    {

    }
}
