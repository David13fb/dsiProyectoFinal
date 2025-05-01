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
    //Indica que boton se pulso antes de seleccionar sprite
    int index;
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
    Button[] buttons = new Button[7];
    //Sprites de los distintos objetso
    Sprite spr_1;
    Sprite spr_2;
    Sprite spr_3;
    Sprite spr_4;
    Sprite spr_5;
    Sprite spr_6;
    Sprite spr_7;
    Sprite[] sprs = new Sprite[7];

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
        buttons[0] = gancho;
        arco = item.Q<Button>("Arco");
        buttons[1] = arco;
        bombas = item.Q<Button>("Bomba");
        buttons[2] = bombas;
        nueces = item.Q<Button>("Nuez");
        buttons[3] = nueces;
        huevo = item.Q<Button>("Huevo");
        buttons[4] = huevo;
        gustabo = item.Q<Button>("Gustavo");
        buttons[5] = gustabo;
        Empty = item.Q<Button>("Empty");
        buttons[6] = Empty;

        //Asignación de las imagenes
        spr_1 = Resources.Load<Sprite>("gancho");
        sprs[0] = spr_1;
        spr_2 = Resources.Load<Sprite>("arco");
        sprs[1] = spr_2;
        spr_3 = Resources.Load<Sprite>("bomba");
        sprs[2] = spr_3;
        spr_4 = Resources.Load<Sprite>("Nintendo 64 - The Legend of Zelda Ocarina of Time - Item Icons - copia_2");
        sprs[3] = spr_4;
        spr_5 = Resources.Load<Sprite>("egg");
        sprs[4] = spr_5;
        spr_6 = Resources.Load<Sprite>("gustabo");
        sprs[5] = spr_6;
        spr_7 = Resources.Load<Sprite>(" ");
        sprs[6] = spr_7;

        //Evento de Click

        gancho.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[0],0));
        arco.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[1], 1));
        bombas.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[2], 2));
        nueces.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[3], 3));
        huevo.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[4], 4));
        gustabo.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[5], 5));
        Empty.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[6], 6));

        //Seteamos los bordes a negro
        obj_borde_negro();
    }

    private void saveSprite(Sprite spr,int button)
    {
        sprite = spr;
        index = button;
        isSelected = true;
    }
    private void setSprite(Button button, Sprite actSprite,int buttonIndex)
    {
        //Cambiar la imagen del array
        sprs[index] = actSprite;
        sprs[buttonIndex] = sprite;
        // Asignarla como fondo del botón
        buttons[index].style.backgroundImage = new StyleBackground(actSprite);
        button.style.backgroundImage = new StyleBackground(sprite);
        isSelected = false;
    }
    private void colocarObjetos(ClickEvent e,Sprite spr,int button)
    {
        Button obj = e.target as Button;
        if (isSelected)
        {
            obj_borde_negro();
            setSprite(obj,spr,button);
            
        }
        else
        {
            obj_borde_negro();
            obj_borde_blanco(obj);
            saveSprite(spr,button);

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
