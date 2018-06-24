using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public Collider2D exitLeft;
    public Collider2D exitRight;
    public GameScreen screen1;

    GameScreen screenCurrent;

    public static ScreenManager instance;
        
    void Awake()
    {
        instance = this;
        Reset();
    }

    public void Reset()
    {
        var screens = GetComponentsInChildren<GameScreen>();
        foreach (var s in screens)
        {
            s.gameObject.SetActive(false);
        }
        screenCurrent = screens[0];
        
        //screenCurrent = screen1;
        ShowCurrent();
    }

    void ShowCurrent()
    {
        screenCurrent.transform.position = Vector3.zero;
        screenCurrent.gameObject.SetActive(true);
        exitLeft.isTrigger = screenCurrent.left;
        exitRight.isTrigger = screenCurrent.right;
    }

    public void GoScreen(bool right)
    {
        screenCurrent.gameObject.SetActive(false);
        screenCurrent = right ? screenCurrent.right : screenCurrent.left;
        ShowCurrent();
        SetManPosition(!right);
    }

    public void GoScreenOther()
    {
        screenCurrent.gameObject.SetActive(false);
        screenCurrent = screenCurrent.other;
        ShowCurrent();
        SetManPosition(false);
    }
    
    void SetManPosition(bool right)
    {
        GameManager.instance.man.SetXPositon(right ?
            exitRight.transform.position.x - 1 :
            exitLeft.transform.position.x + 1);
    }
}
