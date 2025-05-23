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
    Button[] buttons = new Button[11];

    //Sprites de los distintos objetso
    Sprite spr_1;
    Sprite spr_2;
    Sprite spr_3;
    Sprite spr_4;
    Sprite spr_5;
    Sprite spr_6;
    Sprite spr_7;
    Sprite spr_8;
    Sprite spr_9;
    Sprite spr_10;
    Sprite spr_11;
    Sprite[] sprs = new Sprite[11];

    //Sprites de las flechas
    Sprite leftArrow;
    Sprite rightArrow;
    Sprite upArrow;
    Sprite downArrow;

    private void OnEnable()
    {
        //Nos colocamos en el menu correspondiente
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement item = root.Q<VisualElement>("item");

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


        //Flechas donde equipar los objetos
        izquierda = item.Q<Button>("Izquierda");
        buttons[7] = izquierda;
        derecha = item.Q<Button>("Derecha");
        buttons[8] = derecha;
        arriba = item.Q<Button>("Arriba");
        buttons[9] = arriba;
        abajo = item.Q<Button>("Abajo");
        buttons[10] = abajo;

        //Asignaci�n de las imagenes
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
        spr_8 = Resources.Load<Sprite>(" ");
        sprs[7] = spr_8;
        spr_9 = Resources.Load<Sprite>(" ");
        sprs[8] = spr_9;
        spr_10 = Resources.Load<Sprite>(" ");
        sprs[9] = spr_10;
        spr_11 = Resources.Load<Sprite>(" ");
        sprs[10] = spr_11;

        leftArrow = Resources.Load<Sprite>("btnleft");
        rightArrow = Resources.Load<Sprite>("btnright");
        upArrow = Resources.Load<Sprite>("btnup");
        downArrow = Resources.Load<Sprite>("btndown");

        //Evento de Click

        gancho.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[0],0));
        arco.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[1], 1));
        bombas.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[2], 2));
        nueces.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[3], 3));
        huevo.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[4], 4));
        gustabo.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[5], 5));
        Empty.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[6], 6));
        izquierda.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[7], 7));
        derecha.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[8], 8));
        arriba.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[9], 9));
        abajo.RegisterCallback<ClickEvent>(evt => colocarObjetos(evt, sprs[10], 10));

        //Seteamos los bordes a negro
        obj_borde_negro();
    }

    //Guardamos la referencia a la imagen original
    private void saveSprite(Sprite spr,int button)
    {
        sprite = spr;
        index = button;
        isSelected = true;
    }

    //Cambia el sprite guardado previamente por el sprite actual de la imagen
    private void setSprite(Button button, Sprite actSprite, int buttonIndex)
    {
        //Cambiar la imagen del array para saber cual es la imagen a guardar
        sprs[index] = actSprite;
        sprs[buttonIndex] = sprite;
        isSelected = false;

        //En caso de que se clicke por segunda vez una de las 4 flechas:
        if (buttonIndex >= 7)
        {
            //Comprobamos si el sprite guardado previamente es vac�o o no
            if (sprite == Resources.Load<Sprite>(" "))
            {
                //En caso de serlo seteamos la flecha correspondiente en funci�n del �ndice
                switch (buttonIndex)
                {
                    case 7:
                        button.style.backgroundImage = new StyleBackground(leftArrow);
                        break;
                    case 8:
                        button.style.backgroundImage = new StyleBackground(rightArrow);
                        break;
                    case 9:
                        button.style.backgroundImage = new StyleBackground(upArrow);
                        break;
                    case 10:
                        button.style.backgroundImage = new StyleBackground(downArrow);
                        break;
                }
            }
            //Si el sprite no es nulo cambiamos el sprite actual por el guardado
            else
            {
                button.style.backgroundImage = new StyleBackground(sprite);
            }

            //Si del mismo modo el click anterior es de unas flechas
            if (index >= 7)
            {
                //Comprobamos que el sprite actual no sea vac�o
                if (actSprite == Resources.Load<Sprite>(" "))
                {
                    //Si lo es asignamos la flecha correspondiente
                    switch (index)
                    {
                        case 7:
                            buttons[index].style.backgroundImage = new StyleBackground(leftArrow);
                            break;
                        case 8:
                            buttons[index].style.backgroundImage = new StyleBackground(rightArrow);
                            break;
                        case 9:
                            buttons[index].style.backgroundImage = new StyleBackground(upArrow);
                            break;
                        case 10:
                            buttons[index].style.backgroundImage = new StyleBackground(downArrow);
                            break;
                    }
                }
                //Si no lo es cambiamos el sprite tal cual
                else
                {
                    buttons[index].style.backgroundImage = new StyleBackground(actSprite);
                }
            }
            //Si el click anterior no corresponde a las flechas cambiamos la imagen directamente
            else
            {
                buttons[index].style.backgroundImage = new StyleBackground(actSprite);
            }
        }
        //En caso de que el segundo click no sea de las flechas
        else
        {
            //Comprobamos que el sprite actual no sea nulo
            if(actSprite == Resources.Load<Sprite>(" "))
            {
                //Si lo es entonces cambiamos a las flechas en caso de ser una de estas o dejamos el hueco vac�o en el inventario
                switch (index)
                {
                    case 7:
                        buttons[index].style.backgroundImage = new StyleBackground(leftArrow);
                        break;
                    case 8:
                        buttons[index].style.backgroundImage = new StyleBackground(rightArrow);
                        break;
                    case 9:
                        buttons[index].style.backgroundImage = new StyleBackground(upArrow);
                        break;
                    case 10:
                        buttons[index].style.backgroundImage = new StyleBackground(downArrow);
                        break;
                    default:
                        buttons[index].style.backgroundImage = new StyleBackground(actSprite);
                        break;
                }
            }
            //Si no lo es  cambiamos el sprite directamente
            else
            {
                buttons[index].style.backgroundImage = new StyleBackground(actSprite);
            }
            //Cambiamos el sprite del boton actual por el guardado anteriormente
            button.style.backgroundImage = new StyleBackground(sprite);
        }
    }
    private void colocarObjetos(ClickEvent e,Sprite spr,int button)
    {
        Button obj = e.target as Button;
        //Si ya se ha seleccionado una imagen antes
        if (isSelected)
        {
            obj_borde_negro();
            setSprite(obj,spr,button);
            
        }

        //Si no se ha seleccionado
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
        cambiaBordeNegro(izquierda);
        cambiaBordeNegro(derecha);
        cambiaBordeNegro(abajo);
        cambiaBordeNegro(arriba);
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
