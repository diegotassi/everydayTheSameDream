using UnityEngine;

public class ObjWife : Obj
{
	public override void Action ()
    {
        Message.instance.Set("\"C'mon honey, you're late");
        //Message.instance.Set("\"Dress up, you're late");
        enabled = false;
    }
}
