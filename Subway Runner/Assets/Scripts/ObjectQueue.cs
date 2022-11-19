using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ObjectQueue{
public class ObjectQueue
    {
        private Queue<GameObject> _queue = new Queue<GameObject>();

        private float GetObjectZSize(GameObject ob)
        {
            Renderer objectRenderer = ob.GetComponentInChildren<Renderer>();
            if (objectRenderer == null)
                return 0f;
            return objectRenderer.bounds.size.z;
        }

        public GameObject Spawn(GameObject ob, Vector3 spawnLocation)
        {
            float zSize = GetObjectZSize(ob);
            if (zSize == 0f)
            {
                return null;
            }
            Object renderedObject = MonoBehaviour.Instantiate(ob, spawnLocation,ob.transform.rotation);
            return ob;
        }
    }
}