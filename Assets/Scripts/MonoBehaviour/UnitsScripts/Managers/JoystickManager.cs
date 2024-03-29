using UnityEngine;

public class JoystickManager : Joystick, IShowable
{
    public static JoystickManager instance;
    private void Awake()
    {
        instance = this;
        AddJoystickListener();
    }

    public void AddJoystickListener()
    {
        joystickPress.AddListener(() => {
            IsPressed = true;
            Debug.Log("Joystick is pressed");
        });
    }
    public int GetXReversedPosition() => (int)((Horizontal - 1) / (-2f) * 255);
    public int GetYReversedPosition() => (int)((Vertical - 1) / (-2f) * 255);

    public int GetXPosition() => (int)((Horizontal + 1)/2f * 255);
    public int GetYPosition() => (int)((Vertical + 1) / 2f * 255);

    public bool CanShowCategory() => UnitsManager.instance.UnitSlotHasChildren() && UnitsManager.instance.GetUnitImage().name.ToUpper() == GetCategoryName();
    public void ClearGarbage()
    {
        if (CanShowCategory()) 
        { 
        joystickPress.RemoveAllListeners();
        }
    }
    public string GetCategoryName() => this.name.ToUpper();
}
