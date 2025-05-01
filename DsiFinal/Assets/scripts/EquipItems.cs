using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using static UnityEditor.Progress;


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
    Button gustabo;
    Button Empty;

    //Sprites de los distintos objetso
    Sprite spr_1;
    Sprite spr_2;
    Sprite spr_3;
    Sprite spr_4;
    Sprite spr_5;
    Sprite spr_6;
    Sprite spr_7;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement item = root.Q<VisualElement>("item");

        //Flechas donde equipar los objetos
        izquierda = item.Q<Button>("Izquierda");
        derecha = item.Q<Button>("Derecha");
        arriba = item.Q<Button>("Arriba");
        abajo = item.Q<Button>("Abajo");

        //Objetos del inventario
        gancho = item.Q<Button>("Gancho");
        arco = item.Q<Button>("Arco");
        bombas = item.Q<Button>("Bomba");
        nueces = item.Q<Button>("Nuez");
        huevo = item.Q<Button>("Huevo");
        gustabo = item.Q<Button>("Gustavo");
        Empty = item.Q<Button>("Empty");

        //Asignación de las imagenes
        spr_1 = Resources.Load<Sprite>("gancho");
        spr_2 = Resources.Load<Sprite>("arco");
        spr_3 = Resources.Load<Sprite>("bomba");
        spr_4 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_2");
        spr_5 = Resources.Load<Sprite>("egg");
        spr_6 = Resources.Load<Sprite>("gustabo");
        spr_7 = Resources.Load<Sprite>(" ");

        //Evento de Click

        gancho.RegisterCallback<ClickEvent>(evt =>colocarObjetos(evt,spr_1));
        arco.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, spr_2));
        bombas.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, spr_3));
        nueces.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, spr_4));
        huevo.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, spr_5));
        gustabo.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, spr_6));
        Empty.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, spr_7));

        //Seteamos los bordes a negro
        obj_borde_negro();
    }

    private void saveSprite(Sprite spr)
    {
        sprite = spr;
        isSelected = true;
    }
    private void setSprite(Button button)
    {
        // Asignarla como fondo del botón
        button.style.backgroundImage = new StyleBackground(sprite);
        isSelected = false;
    }
    private void colocarObjetos(ClickEvent e,Sprite spr)
    {
        Button obj = e.target as Button;
        if (isSelected)
        {
            obj_borde_negro();
            setSprite(obj);
            
        }
        else
        {
            obj_borde_negro();
            obj_borde_blanco(obj);
            saveSprite(spr);

        }
    }
    private void obj_borde_negro()
    {
        cambiaBordeNegro(gancho);
        cambiaBordeNegro(arco);
        cambiaBordeNegro(bombas);
        cambiaBordeNegro(nueces);
        cambiaBordeNegro(huevo);
        cambiaBordeNegro(gustabo);
        cambiaBordeNegro(Empty);  
    }
    void cambiaBordeNegro(Button b)
    {
        b.style.borderBottomColor = Color.black;
        b.style.borderRightColor = Color.black;
        b.style.borderTopColor = Color.black;
        b.style.borderLeftColor = Color.black;
    }
    void obj_borde_blanco(Button b)
    {

        b.style.borderBottomColor = Color.white;
        b.style.borderRightColor = Color.white;
        b.style.borderTopColor = Color.white;
        b.style.borderLeftColor = Color.white;
    }
}
