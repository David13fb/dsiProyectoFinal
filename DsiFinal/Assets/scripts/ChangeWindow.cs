
using UnityEngine;
using UnityEngine.UIElements;

public class WindowManager : MonoBehaviour
{
    VisualElement item;
    VisualElement claves;
    VisualElement EquipMenu;
    int actualMenu = 0;

    private void NoContent()
    {
        item.style.display = DisplayStyle.None;
        EquipMenu.style.display = DisplayStyle.None;
        claves.style.display = DisplayStyle.None;
    }
    private void OnEnable()
    {
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;

        VisualElement menuses = rootve.Q("background");
        item = menuses.Q("item");
        EquipMenu = menuses.Q("EquipMenu");
        claves = menuses.Q("claves");

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (actualMenu > 0)
            {
                actualMenu--;
                NoContent();
                if (actualMenu == 0) item.style.display = DisplayStyle.Flex;
                if (actualMenu == 1) claves.style.display = DisplayStyle.Flex;
                if (actualMenu == 2) EquipMenu.style.display = DisplayStyle.Flex;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (actualMenu < 2)
            {
                actualMenu++;
                NoContent();
                if (actualMenu == 0) item.style.display = DisplayStyle.Flex;
                if (actualMenu == 1) claves.style.display = DisplayStyle.Flex;
                if (actualMenu == 2) EquipMenu.style.display = DisplayStyle.Flex;
            }
        }
    }
}
