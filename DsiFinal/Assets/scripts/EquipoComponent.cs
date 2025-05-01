using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class EquipoComponent : MonoBehaviour
{
    List<VisualElement> leftimgs = new List<VisualElement>();
    Sprite[] swords = new Sprite[3];
    Sprite[] shields = new Sprite[3];
    Sprite[] tunics = new Sprite[3];
    Sprite[] boots = new Sprite[3];
    int swordIndex = 2;
    int shieldIndex = 1;
    int tunicsIndex = 0;
    int bootsIndex = 0;
    // Start is called before the first frame update
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualTreeAsset template = Resources.Load<VisualTreeAsset>("ItemToEquip");
        VisualElement root1 = root.Q("background");
        VisualElement root2 = root1.Q("EquipMenu");
        VisualElement camImg = root2.Q("MiddlePanel");
        VisualElement equipMat = root2.Q("RightPanel");

        leftimgs.Add(camImg.Q<VisualElement>("EquipedItem1"));
        leftimgs.Add(camImg.Q<VisualElement>("EquipedItem2"));
        leftimgs.Add(camImg.Q<VisualElement>("EquipedItem3"));
        leftimgs.Add(camImg.Q<VisualElement>("EquipedItem4"));
        //load images

        Sprite sword1 = Resources.Load<Sprite>("espadabigoron");
        Sprite sword2 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_60");
        Sprite sword3 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_61");
        swords[0] = sword1;
        swords[1] = sword2;
        swords[2] = sword3;

        Sprite sheild1 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_63");
        Sprite sheild2 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_64");
        Sprite sheild3 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_65");
        shields[0] = sheild1;
        shields[1] = sheild2;
        shields[2] = sheild3;

        Sprite tunica1 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_66");
        Sprite tunica2 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_67");
        Sprite tunica3 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_68");
        tunics[0] = tunica1;
        tunics[1] = tunica2;
        tunics[2] = tunica3;

        Sprite zapatillas1 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_69");
        Sprite zapatillas2 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_70");
        Sprite zapatillas3 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_71");
        boots[0] = zapatillas1;
        boots[1] = zapatillas2;
        boots[2] = zapatillas3;

        VisualElement aux1 = template.Instantiate();
        var left1 = aux1.Q<VisualElement>("Left"); left1.style.backgroundImage = new StyleBackground(sword2);
        var med1 = aux1.Q<VisualElement>("Mid"); med1.style.backgroundImage = new StyleBackground(sword1);
        var right1 = aux1.Q<VisualElement>("Right"); right1.style.backgroundImage = new StyleBackground(sword3);
        aux1.style.marginTop = 75;
        aux1.style.marginLeft = 10;
        left1.RegisterCallback<ClickEvent>(evt =>
        {
            leftimgs[0].style.backgroundImage = left1.style.backgroundImage;
            swordIndex = 0;
        });

        med1.RegisterCallback<ClickEvent>(evt =>
        {
            leftimgs[0].style.backgroundImage = med1.style.backgroundImage;
            swordIndex = 1;
        });

        right1.RegisterCallback<ClickEvent>(evt =>
        {
            leftimgs[0].style.backgroundImage = right1.style.backgroundImage;
            swordIndex = 2;
        });
        equipMat.Add(aux1);
        VisualElement aux2 = template.Instantiate();
        var left2 = aux2.Q<VisualElement>("Left"); left2.style.backgroundImage = new StyleBackground(sheild1);
        var med2 = aux2.Q<VisualElement>("Mid"); med2.style.backgroundImage = new StyleBackground(sheild2);
        var right2 = aux2.Q<VisualElement>("Right"); right2.style.backgroundImage = new StyleBackground(sheild3);
        aux2.style.marginTop = 20;
        aux2.style.marginLeft = 10;
        left2.RegisterCallback<ClickEvent>(evt =>
        {
            leftimgs[1].style.backgroundImage = left2.style.backgroundImage;
            shieldIndex = 0;
        });

        med2.RegisterCallback<ClickEvent>(evt =>
        {
            leftimgs[1].style.backgroundImage = med2.style.backgroundImage;
            shieldIndex = 1;
        });

        right2.RegisterCallback<ClickEvent>(evt =>
        {
            leftimgs[1].style.backgroundImage = right2.style.backgroundImage;
            shieldIndex = 2;
        });
        equipMat.Add(aux2);
        VisualElement aux3 = template.Instantiate();
        var left3 = aux3.Q<VisualElement>("Left"); left3.style.backgroundImage = new StyleBackground(tunica1);
        var med3 = aux3.Q<VisualElement>("Mid"); med3.style.backgroundImage = new StyleBackground(tunica2);
        var right3 = aux3.Q<VisualElement>("Right"); right3.style.backgroundImage = new StyleBackground(tunica3);
        aux3.style.marginTop = 20;
        aux3.style.marginLeft = 10;
        left3.RegisterCallback<ClickEvent>(evt =>
        {
            leftimgs[2].style.backgroundImage = left3.style.backgroundImage;
            tunicsIndex = 0;
        });

        med3.RegisterCallback<ClickEvent>(evt =>
        {
            leftimgs[2].style.backgroundImage = med3.style.backgroundImage;
            tunicsIndex = 1;
        });

        right3.RegisterCallback<ClickEvent>(evt =>
        {
            leftimgs[2].style.backgroundImage = right3.style.backgroundImage;
            tunicsIndex = 2;
        });
        equipMat.Add(aux3);
        VisualElement aux4 = template.Instantiate();
        var left4 = aux4.Q<VisualElement>("Left"); left4.style.backgroundImage = new StyleBackground(zapatillas1);
        var med4 = aux4.Q<VisualElement>("Mid"); med4.style.backgroundImage = new StyleBackground(zapatillas2);
        var right4 = aux4.Q<VisualElement>("Right"); right4.style.backgroundImage = new StyleBackground(zapatillas3);
        aux4.style.marginTop = 20;
        aux4.style.marginLeft = 10;
        left4.RegisterCallback<ClickEvent>(evt =>
        {
            leftimgs[3].style.backgroundImage = left4.style.backgroundImage;
            bootsIndex = 0;
        });

        med4.RegisterCallback<ClickEvent>(evt =>
        {
            leftimgs[3].style.backgroundImage = med4.style.backgroundImage;
            bootsIndex = 1;
        });

        right4.RegisterCallback<ClickEvent>(evt =>
        {
            leftimgs[3].style.backgroundImage = right4.style.backgroundImage;
            bootsIndex = 2;
        });
        equipMat.Add(aux4);


    }

    //Geters de los equipos
    public Sprite getSword() 
    {
        return swords[swordIndex];
    }
    public Sprite getShield()
    {
        return shields[shieldIndex];
    }
    public Sprite getTunic()
    {
        return tunics[tunicsIndex];
    }
    public Sprite getboots()
    {
        return boots[bootsIndex];
    }
    public void setlefImg(int index, Sprite img)
    {
        leftimgs[index].style.backgroundImage = new StyleBackground(img);
    }

}
