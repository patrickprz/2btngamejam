using UnityEngine.EventSystems;

public class RightButtonEvent : EventTrigger
{
    public override void OnPointerDown(PointerEventData data)
    {
        CharacterController.Instance.ButtonRight();
    }
}
