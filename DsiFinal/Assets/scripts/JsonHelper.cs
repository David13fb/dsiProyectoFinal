using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal
{

    [SerializeField]
    public static class JsonHelper
    {

        [SerializeField]
        public static GameInfo FromJson<GameInfo>(string json)
        {
            Info<GameInfo> saveGame = JsonUtility.FromJson<Info<GameInfo>>(json);
            return saveGame.gameInfo;
        }

        [SerializeField]
        public static string ToJSon<GameInfo>(GameInfo game)
        {
            Info<GameInfo> loadGame = new Info<GameInfo>();
            loadGame.gameInfo = game;
            return JsonUtility.ToJson(loadGame);
        }

        [SerializeField]
        public static string ToJSon<GameInfo>(GameInfo gane, bool prettyPrint)
        {
            Info<GameInfo> listaIndividuoP6 = new Info<GameInfo>();
            listaIndividuoP6.gameInfo = gane;
            return JsonUtility.ToJson(listaIndividuoP6, prettyPrint);
        }

        [Serializable]
        private class Info<GameInfo>
        {
            [SerializeField] public GameInfo gameInfo;
        }
    }


}