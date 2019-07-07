using UnityEngine.EventSystems;

public class LeftButtonEvent : EventTrigger
{
    public override void OnPointerDown(PointerEventData data)
    {
        CharacterController.Instance.ButtonLeft();
    }
}
