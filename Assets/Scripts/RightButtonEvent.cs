using UnityEngine.EventSystems;

public class RightButtonEvent : EventTrigger
{
    public override void OnPointerClick(PointerEventData data)
    {
        CharacterController.Instance.ButtonRight();
    }
}
