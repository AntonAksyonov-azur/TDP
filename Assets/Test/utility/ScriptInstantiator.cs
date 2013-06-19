﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Test.utility {
    public static class ScriptInstantiator {

        private static List<GameObject> gameObjects = new List<GameObject>();

        public static T InstantiateScript<T>(GameObject gameObjectPrefab) where T : MonoBehaviour {

            GameObject gameObject;
            if (gameObjectPrefab == null) {
                throw new Exception("Failed to create game object");
            }
            
            gameObject = (GameObject) Object.Instantiate(gameObjectPrefab);
            gameObject.name = typeof (T).Name + " (Test)";

            T instance = gameObject.GetComponent<T>();

            if (instance == null) {
                instance = gameObject.AddComponent<T>();
            }

            gameObjects.Add(gameObject);

            return instance;
        }

        public static void CleanUp() {
            foreach (var gameObject in gameObjects) {
                Object.DestroyImmediate(gameObject);
            }

            gameObjects.Clear();
        }
    }
}