using UnityEngine.UIElements;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal{
    public class SaveGameScript : MonoBehaviour
    {
        GameInfo gameInfo = new GameInfo(0);
        MedallonComponent medallon;
        VisualElement guardar;
        VisualElement cargar;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            guardar = root.Q<Button>("Guardar");
            cargar = root.Q<Button>("Cargar");
            guardar.RegisterCallback<ClickEvent>(GuardarJson);
            cargar.RegisterCallback<ClickEvent>(CargarJson);
        }

        private void GuardarJson(ClickEvent evt)
        {

            gameInfo.Medallones = medallon.getMedal();
            string rutaArchivo = Application.persistentDataPath + "/individuos.json"; //Guardamos la ruta del Json
            string listaToJson = JsonHelper.ToJSon(gameInfo, true); // Convierte la lista a JSON
            File.WriteAllText(rutaArchivo, listaToJson); // Guarda el JSON en un archivo
            Debug.Log("Archivo JSON guardado en: " + rutaArchivo);
        }

        private void CargarJson(ClickEvent evt)
        {
            string rutaArchivo = Application.persistentDataPath + "/individuos.json";
            if (File.Exists(rutaArchivo)) // Verifica si el archivo existe
            {
                string jsonDesdeArchivo = File.ReadAllText(rutaArchivo); // Lee el contenido del archivo
                GameInfo jsonToLista = JsonHelper.FromJson<GameInfo>(jsonDesdeArchivo); // Convierte el JSON en lista
                gameInfo = BaseDeDatos.getData(jsonToLista);
                medallon.setMedal(gameInfo.Medallones);
                Debug.Log("Datos cargados desde el archivo JSON.");
            }
        }

        private void Start()
        {
            medallon = GetComponent<MedallonComponent>();
        }
    }

}
