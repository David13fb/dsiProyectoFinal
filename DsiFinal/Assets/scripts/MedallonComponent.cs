using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MedallonComponent : MonoBehaviour
{
    [SerializeField]int numMedal = 0;
     
     List<VisualElement> medal = new List<VisualElement>();
    void Start()
    {
     VisualElement root = GetComponent<UIDocument>().rootVisualElement;

      VisualElement root1 = root.Q("background");
      VisualElement root2 = root1.Q("claves");
      VisualElement root3 = root2.Q("Medallones");
     medal.Add(root3.Q<VisualElement>("m1"));
     medal.Add(root3.Q<VisualElement>("m2"));
     medal.Add(root3.Q<VisualElement>("m3"));
     medal.Add(root3.Q<VisualElement>("m4"));
     medal.Add(root3.Q<VisualElement>("m5"));
     medal.Add(root3.Q<VisualElement>("m6"));
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)){
            if (numMedal<6)
            numMedal++;
            for(int i = 0;i<6; i++){
            if(i<numMedal) medal[i].style.display = DisplayStyle.Flex;
            else medal[i].style.display = DisplayStyle.None;
        }
        }
        if(Input.GetKeyDown(KeyCode.S)){
            if (numMedal>0)
            numMedal--;
            for(int i = 0;i<6; i++){
            if(i<numMedal) medal[i].style.display = DisplayStyle.Flex;
            else medal[i].style.display = DisplayStyle.None;
        }
        }
        
    }

    
}
