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
      leftimgs.Add(camImg.Q<VisualElement>("UnEquipableItem1"));
      leftimgs.Add(camImg.Q<VisualElement>("UnEquipableItem2"));
      leftimgs.Add(camImg.Q<VisualElement>("UnEquipableItem3"));
      leftimgs.Add(camImg.Q<VisualElement>("UnEquipableItem4"));
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
        var left1 = aux1.Q<VisualElement>("Left");left1.style.backgroundImage =  new StyleBackground(sword2);
        var med1 = aux1.Q<VisualElement>("Mid");med1.style.backgroundImage =  new StyleBackground(sword1);
        var right1 = aux1.Q<VisualElement>("Right");right1.style.backgroundImage =  new StyleBackground(sword3);
        aux1.style.marginTop = 75;
        aux1.style.marginLeft = 10;
        left1.RegisterCallback<ClickEvent>(evt => {
          leftimgs[0].style.backgroundImage = left1.style.backgroundImage;
        });

        med1.RegisterCallback<ClickEvent>(evt => {
          leftimgs[0].style.backgroundImage = med1.style.backgroundImage;
        // Lógica específica aquí
        });

    right1.RegisterCallback<ClickEvent>(evt => {
    Debug.Log("Click en Right");
    // Lógica específica aquí
});
      equipMat.Add(aux1);
       VisualElement aux2 = template.Instantiate();
        var left2 = aux2.Q<VisualElement>("Left");left2.style.backgroundImage =  new StyleBackground(sheild1);
        var med2 = aux2.Q<VisualElement>("Mid");med2.style.backgroundImage =  new StyleBackground(sheild2);
        var right2 = aux2.Q<VisualElement>("Right");right2.style.backgroundImage =  new StyleBackground(sheild3);
        aux2.style.marginTop = 20;
        aux2.style.marginLeft = 10;
      equipMat.Add(aux2);
       VisualElement aux3 = template.Instantiate();
        var left3 =aux3.Q<VisualElement>("Left");left3.style.backgroundImage =  new StyleBackground(tunica1);
        var med3 = aux3.Q<VisualElement>("Mid");med3.style.backgroundImage =  new StyleBackground(tunica2);
        var right3 = aux3.Q<VisualElement>("Right");right3.style.backgroundImage =  new StyleBackground(tunica3);
      aux3.style.marginTop = 20;
      aux3.style.marginLeft = 10;
      equipMat.Add(aux3);
       VisualElement aux4 = template.Instantiate();
       var left4 = aux4.Q<VisualElement>("Left");left4.style.backgroundImage =  new StyleBackground(zapatillas1);
        var med4 = aux4.Q<VisualElement>("Mid");med4.style.backgroundImage =  new StyleBackground(zapatillas2);
        var right4 = aux4.Q<VisualElement>("Right");right4.style.backgroundImage =  new StyleBackground(zapatillas3);
        aux4.style.marginTop = 20;
        aux4.style.marginLeft = 10;
      equipMat.Add(aux4);

    
    }

    
}
