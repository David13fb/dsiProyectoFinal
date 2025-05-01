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

      //load images
       Sprite sword1 = Resources.Load<Sprite>("espadabigoron");
        Sprite sword2 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_60");
         Sprite sword3 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_61");

          Sprite sheild1 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_63");
      Sprite sheild2 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_64");
      Sprite sheild3 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_65");

      Sprite tunica1 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_66");
      Sprite tunica2 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_67");
      Sprite tunica3 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_68");

       Sprite zapatillas1 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_69");
       Sprite zapatillas2 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_70");
       Sprite zapatillas3 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_71");
        VisualElement aux1 = template.Instantiate();
        aux1.Q<VisualElement>("Left").style.backgroundImage =  new StyleBackground(sword2);
        aux1.Q<VisualElement>("Mid").style.backgroundImage =  new StyleBackground(sword1);
        aux1.Q<VisualElement>("Right").style.backgroundImage =  new StyleBackground(sword3);
        aux1.style.marginTop = 75;
        aux1.style.marginLeft = 10;
      equipMat.Add(aux1);
       VisualElement aux2 = template.Instantiate();
        aux2.Q<VisualElement>("Left").style.backgroundImage =  new StyleBackground(sheild1);
        aux2.Q<VisualElement>("Mid").style.backgroundImage =  new StyleBackground(sheild2);
        aux2.Q<VisualElement>("Right").style.backgroundImage =  new StyleBackground(sheild3);
        aux2.style.marginTop = 20;
        aux2.style.marginLeft = 10;
      equipMat.Add(aux2);
       VisualElement aux3 = template.Instantiate();
        aux3.Q<VisualElement>("Left").style.backgroundImage =  new StyleBackground(tunica1);
        aux3.Q<VisualElement>("Mid").style.backgroundImage =  new StyleBackground(tunica2);
        aux3.Q<VisualElement>("Right").style.backgroundImage =  new StyleBackground(tunica3);
      aux3.style.marginTop = 20;
      aux3.style.marginLeft = 10;
      equipMat.Add(aux3);
       VisualElement aux4 = template.Instantiate();
        aux4.Q<VisualElement>("Left").style.backgroundImage =  new StyleBackground(zapatillas1);
        aux4.Q<VisualElement>("Mid").style.backgroundImage =  new StyleBackground(zapatillas2);
        aux4.Q<VisualElement>("Right").style.backgroundImage =  new StyleBackground(zapatillas3);
        aux4.style.marginTop = 20;
        aux4.style.marginLeft = 10;
      equipMat.Add(aux4);

    
    }

    
}
