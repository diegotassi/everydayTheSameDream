using UnityEngine;

public class ObjCheckNaked : Obj {

	public override void Action()
    {
        Message.instance.Set(
            GameManager.instance.man.IsNaked() ?
            "\"Morning dear\"" :
            "\"Dress up, you're late\""
            );
        enabled = false;
	}
}
