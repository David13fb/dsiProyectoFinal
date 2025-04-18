using UnityEngine;
using System;

namespace ProyectoFinal
{


    [Serializable]
    public class GameInfo
    {
        public event Action Cambio;

        [SerializeField] private int skultula;

        public int Skultula
        {
            get { return skultula; }
            set
            {
                if (value != skultula)
                {
                    skultula = value;
                    Cambio?.Invoke();
                }
            }
        }
        [SerializeField] private int medallones;
        public int Medallones
        {
            get { return medallones; }
            set
            {
                if (value != medallones)
                {
                    medallones = value;
                    Cambio?.Invoke();
                }
            }
        }

        [SerializeField] private Sprite top;
        public Sprite Top
        {
            get { return top; }
            set
            {
                if (value != top)
                {
                    top = value;
                    Cambio?.Invoke();
                }
            }
        }
        public GameInfo(int skultulas, int medallones, Sprite image)
        {
            this.skultula = skultulas;
            this.medallones = medallones;
            this.top = image;
        }
    }
}
