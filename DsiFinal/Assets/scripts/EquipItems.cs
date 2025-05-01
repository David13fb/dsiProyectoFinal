using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


public class EquipItems : MonoBehaviour
{
    //Indica si se ha elegido Sprite
    bool isSelected = false;
    //Sprite clickado
    Sprite sprite;
    //Flechas del inventario
    Button izquierda;
    Button derecha;
    Button arriba;
    Button abajo;

    //Objetos a equipar
    Button gancho;
    Button arco;
    Button bombas;
    Button nueces;
    Button huevo;
    Button Gustavo;
    Button Empty;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement item = root.Q<VisualElement>("item");
        izquierda = item.Q<Button>("Izquierda");
        derecha = item.Q<Button>("Derecha");
        arriba = item.Q<Button>("Arriba");
        abajo = item.Q<Button>("Abajo");
        gancho = item.Q<Button>("Gancho");
        arco = item.Q<Button>("Arco");
        bombas = item.Q<Button>("Bombas");
        nueces = item.Q<Button>("Nueces");
        huevo = item.Q<Button>("Huevo");
        Gustavo = item.Q<Button>("Gustavo");
        Empty = item.Q<Button>("Empty");
    }

    private void setSprite(Sprite imagenElement)
    {
        sprite = imagenElement;
        isSelected = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
