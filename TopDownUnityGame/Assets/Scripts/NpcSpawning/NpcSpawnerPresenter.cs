using UnityEngine;

namespace NpcSpawning
{
    public class NpcSpawnerPresenter : MonoBehaviour
    {
        [SerializeField] private NpcSpawner _npcSpawner;

        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
                _npcSpawner.Spawn();
        }

        private void OnGUI()
        {
            const int fontSize = 32;
            var oldFontSize = GUI.skin.label.fontSize;
            GUI.skin.label.fontSize = fontSize;
            GUI.Label(new Rect(20, 20, 600, 100), "Press SPACE to spawn an NPC");
            GUI.skin.label.fontSize = oldFontSize;
        }
    }
}