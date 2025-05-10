using UnityEngine;
using UnityEngine.UI;

public class NavigationButton : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;

    public bool IsActive
    {
        set
        {
            _icon.color = value ? Color.black : Color.white;
        }
    }

}
