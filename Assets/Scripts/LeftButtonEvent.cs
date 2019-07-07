using UnityEngine.EventSystems;

public class LeftButtonEvent : EventTrigger
{
    public override void OnPointerClick(PointerEventData data)
    {
        CharacterController.Instance.ButtonLeft();
    }
}
