using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine.UIElements;
public class CustomControllerItemsClave : VisualElement
{
    public VisualElement skultula = new VisualElement();
    public Label  num = new Label();

    int numSkultulas = 10;

    public string AttributeImage { get; set; }

    // Elementos visuales
    private VisualElement etiquetacontainer;
    private Label attributeLabel;

    public int nSkultulas
    {
        get => numSkultulas;
        set
        {
            numSkultulas = value;
            ChangeNumber();
        }
    }
   

    public void ChangeNumber()
    {
        num.text = " x" + numSkultulas;
    }

    public CustomControllerItemsClave()
    {
        // Crea los contenedores para los arrays
        VisualElement ataqueContainer = new VisualElement();
        ataqueContainer.style.opacity =  1.0f;
        ataqueContainer.style.width = 300;
        ataqueContainer.style.height = 100;
    
        Sprite img_a = Resources.Load<Sprite>("skulltula");

        // Inicializa los elementos de los arrays
       
           
        
        skultula.style.backgroundImage = new StyleBackground(img_a);
        skultula.style.width = 50;
        skultula.style.height = 50;
         num.style.color = new StyleColor(Color.white);
        num.style.fontSize = new StyleLength(new Length(25, LengthUnit.Pixel));
        num.style.width = 100;
        num.style.height = 100;
        skultula.AddToClassList("skulltula");
        num.AddToClassList("numero");

       
        // Agrega los contenedores a la jerarquía
        hierarchy.Add(skultula);
        hierarchy.Add(num);

    

        ChangeNumber();
    }
   

    // Actualiza la visualización del control
    // Método para inicializar el control
    public void Initialize(int value, string imageName)
    {
        numSkultulas = value;
        ChangeNumber();
    }

    public new class UxmlFactory : UxmlFactory<CustomControllerItemsClave, UxmlTraits> { };

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        private CustomControllerItemsClave aux;
        UxmlIntAttributeDescription numsk = new UxmlIntAttributeDescription { name = "numskulltulas"};
    
        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {

            aux = ve as CustomControllerItemsClave;
            aux.numSkultulas = numsk.GetValueFromBag(bag,cc);
             aux.ChangeNumber();
        }
    }

}
