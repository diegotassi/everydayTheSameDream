using UnityEngine;

public class ObjWardrobe : Obj
{
    public override void Action()
    {
        AppManager.instance.FadeOutIn(() =>
        {
            GameManager.instance.man.Dress(true);
            GetComponent<Collider2D>().enabled = false;
        });
    }
}
