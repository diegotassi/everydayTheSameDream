public class ObjElevatorLady : Obj {

	public override void Action ()
    {
        Message.instance.Set(GameManager.instance.pendingDays + " more steps and you will be a new person");
	}
}
