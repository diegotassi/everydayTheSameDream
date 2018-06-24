public class ObjBoss : Obj {

    int stage;
    
	public override void Action ()
    {
        switch (stage++)
        {
            case 0:
                Message.instance.Set("What? Where is your tie?");
                GameManager.instance.man.enabled = false;
                break;

            case 1:
                Message.instance.Set("What? Where is your tie?");
                break;

            case 2:
                stage = 0;
                GameManager.instance.NewDay();
                break;
        }
	}
}
