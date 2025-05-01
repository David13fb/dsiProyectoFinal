using UnityEngine;
using System;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace ProyectoFinal
{


    [Serializable]
    public class GameInfo
    {
        public event Action Cambio;

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

      [SerializeField] private Sprite sword;
        public Sprite Sword
        {
            get { return sword; }
            set
            {
                if (value != sword)
                {
                    sword = value;
                    Cambio?.Invoke();
                }
            }
        }
        [SerializeField] private Sprite shield;
        public Sprite Shield
        {
            get { return shield; }
            set
            {
                if (value != shield)
                {
                    shield = value;
                    Cambio?.Invoke();
                }
            }
        }
        [SerializeField] private Sprite tunic;
        public Sprite Tunic
        {
            get { return tunic; }
            set
            {
                if (value != tunic)
                {
                    tunic = value;
                    Cambio?.Invoke();
                }
            }
        }
        [SerializeField] private Sprite boots;
        public Sprite Boots
        {
            get { return boots; }
            set
            {
                if (value != boots)
                {
                    boots = value;
                    Cambio?.Invoke();
                }
            }
        }
        public GameInfo(int medallones, Sprite sword, Sprite shield, Sprite tunic, Sprite boots)
        {
            this.medallones = medallones;
            this.sword = sword;
            this.shield = shield;
            this.tunic = tunic;
            this.boots = boots;
        }
    }
}
