using Assets.Scripts.tdp;
using Assets.Scripts.tdp.configuration;
using UnityEngine;

public class MainScene : MonoBehaviour {
    public GameObject gameplayObject;
    private Gameplay cachedGameplay;

    public void Start() {
        cachedGameplay = gameplayObject.GetComponent<Gameplay>();
    }

    public void OnGUI() {
        GUILayout.Label(
            string.Format("Elapsed seconds: {0:f}; need to hold: {1:f}",
            cachedGameplay.GetElapsedGameplayTime(),
            Configuration.SecondsToEndGame)
        );
        GUILayout.Label(
            string.Format("Enemies passed: {0}", cachedGameplay.GetEnemiesPassed())
        );
    }
}