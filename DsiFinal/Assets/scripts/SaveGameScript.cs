using UnityEngine.UIElements;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal{
    public class SaveGameScript : MonoBehaviour
    {
        GameInfo gameInfo;
        MedallonComponent medallon;
        EquipoComponent equipment;
        VisualElement guardar;
        VisualElement cargar;

        private void OnEnable()
        {
            GameInfo aux = new GameInfo(0, Resources.Load<Sprite>(" "), Resources.Load<Sprite>(" "), Resources.Load<Sprite>(" "), Resources.Load<Sprite>(" "));
            gameInfo = aux;
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            guardar = root.Q<Button>("Guardar");
            cargar = root.Q<Button>("Cargar");
            guardar.RegisterCallback<ClickEvent>(GuardarJson);
            cargar.RegisterCallback<ClickEvent>(CargarJson);
        }

        private void GuardarJson(ClickEvent evt)
        {

            gameInfo.Medallones = medallon.getMedal();
            gameInfo.Sword = equipment.getSword();
            gameInfo.Shield = equipment.getShield();
            gameInfo.Tunic = equipment.getTunic();
            gameInfo.Boots = equipment.getboots();
            string rutaArchivo = Application.persistentDataPath + "/partida.json"; //Guardamos la ruta del Json
            string listaToJson = JsonHelper.ToJSon(gameInfo, true); // Convierte la lista a JSON
            File.WriteAllText(rutaArchivo, listaToJson); // Guarda el JSON en un archivo
            Debug.Log("Archivo JSON guardado en: " + rutaArchivo);
        }

        private void CargarJson(ClickEvent evt)
        {
            string rutaArchivo = Application.persistentDataPath + "/partida.json";
            if (File.Exists(rutaArchivo)) // Verifica si el archivo existe
            {
                string jsonDesdeArchivo = File.ReadAllText(rutaArchivo); // Lee el contenido del archivo
                GameInfo jsonToLista = JsonHelper.FromJson<GameInfo>(jsonDesdeArchivo); // Convierte el JSON en lista
                gameInfo = BaseDeDatos.getData(jsonToLista);
                medallon.setMedal(gameInfo.Medallones);
                equipment.setlefImg(0,gameInfo.Sword);
                equipment.setlefImg(1,gameInfo.Shield);
                equipment.setlefImg(2,gameInfo.Tunic);
                equipment.setlefImg(3,gameInfo.Boots);
                Debug.Log("Datos cargados desde el archivo JSON.");
            }
        }

        private void Start()
        {
            medallon = GetComponent<MedallonComponent>();
            equipment = GetComponent<EquipoComponent>();
        }
    }

}
