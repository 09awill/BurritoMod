using IngredientLib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BurritoMod.Customs
{
    internal class SidesDetector : MonoBehaviour
    {
        private GameObject m_SidesContainer;
        bool m_FirstTime = true;
        internal void SetupPrefab(GameObject gameObject)
        {
            print($"[Burrito Mod Debug] Setting up side container prefab");
            m_SidesContainer = Instantiate(gameObject, this.gameObject.transform);
            //m_SidesContainerPrefab.SetActive(false);
            print($"[Burrito Mod Debug] Setup side container prefab and disabled {m_SidesContainer.name}");
        }

        private void Update()
        {
            if(m_FirstTime )
            {
                print($"[Burrito Mod Debug] Setting up side container");
                m_SidesContainer = gameObject.GetChild("Side Prefab(Clone)");
                m_SidesContainer.SetActive(false);
                print($"[Burrito Mod Debug] Setup side container prefab and disabled {m_SidesContainer.name}");
                foreach(var go in m_SidesContainer.transform.GetComponentsInChildren<Transform>())
                {
                    print($"[Burrito Mod Debug] Children are : {go.name}, Parent is : {go.parent.name}");
                }
                m_FirstTime = false;
            }
            if (m_SidesContainer == null) return;
            int num = m_SidesContainer.transform.GetComponentsInChildren<Transform>().Length;
            if(num > 4)
            {
                Debug.Log($"[Burrito Mod Debug] Number is great enough {num}... Activating");
                m_SidesContainer.SetActive(true);
            }
            foreach (var go in m_SidesContainer.transform.GetComponentsInChildren<Transform>())
            {
                print($"[Burrito Mod Debug] Children are : {go.name}, Parent is : {go.parent.name}");
            }


        }
    }
}
