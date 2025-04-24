using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class EquipoComponent : MonoBehaviour
{
    // Start is called before the first frame update
     private void OnEnable() 
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
      VisualTreeAsset template = Resources.Load<VisualTreeAsset>("ItemToEquip");
      VisualElement root1 = root.Q("background");
      VisualElement root2 = root1.Q("EquipMenu");
      VisualElement camImg = root2.Q("LeftPanel");
      VisualElement equipMat= root2.Q("RightPanel");
      List<VisualElement> leftimgs = new List<VisualElement>();

        VisualElement aux1 = template.Instantiate();
        aux1.Q<VisualElement>("Left");
        aux1.Q<VisualElement>("Mid");
        aux1.Q<VisualElement>("Right");

      equipMat.Add(aux1);
    
    }

    
}
