using UnityEngine;
using Assets.Scripts.tdp.constants;
using Assets.Scripts.tdp.configuration;

namespace Assets.Scripts.tdp.scenes {
    public class StartScene : MonoBehaviour {

        private Rect buttonStartRectangleSize;

        public void Start() {
            buttonStartRectangleSize = new Rect(
                Configuration.ScreenWidth / 2 - 50, Configuration.ScreenHeight / 2 - 50, 100, 100);
        }

        public void OnGUI() {
            if (GUI.Button(buttonStartRectangleSize, "Start game")) {
                Application.LoadLevel(SceneNames.Main);
            }
        }
    }
}
