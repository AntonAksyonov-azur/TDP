using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.constants;
using UnityEngine;

namespace Assets.Scripts.tdp.scenes {
    public class LooseScene : MonoBehaviour {
        private Rect buttonStartRectangleSize = new Rect(0, 0, 100, 100);
        private Rect labelRectangleSize = new Rect(0, 0, 70, 30);

        public void OnGUI() {
            GUI.Label(new Rect(Configuration.ScreenWidth / 2 - labelRectangleSize.width / 2,
                               Configuration.ScreenHeight / 2 - buttonStartRectangleSize.height,
                               labelRectangleSize.width, labelRectangleSize.height), "You loose!");

            if (GUI.Button(new Rect(
                               Configuration.ScreenWidth / 2 - buttonStartRectangleSize.width / 2,
                               Configuration.ScreenHeight / 2 - buttonStartRectangleSize.height / 2,
                               buttonStartRectangleSize.width, buttonStartRectangleSize.height), "Try again")) {
                Application.LoadLevel(SceneNames.Main);
            }
        }
    }
}