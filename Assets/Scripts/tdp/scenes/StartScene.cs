using UnityEngine;
using Assets.Scripts.tdp.constants;

namespace Assets.Scripts.tdp.scenes {
    public class StartScene : MonoBehaviour {

        private Rect buttonStartRectangleSize = new Rect(0, 0, 100, 100);

        public void OnGUI() {
            if (GUI.Button(new Rect(
                               configuration.Configuration.ScreenWidth / 2 - buttonStartRectangleSize.width / 2,
                               configuration.Configuration.ScreenHeight / 2 - buttonStartRectangleSize.height / 2,
                               buttonStartRectangleSize.width, buttonStartRectangleSize.height), "Start game")) {
                Application.LoadLevel(SceneNames.Main);
            }
        }
    }
}
