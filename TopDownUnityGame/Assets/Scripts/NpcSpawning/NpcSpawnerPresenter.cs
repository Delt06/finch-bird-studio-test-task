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
            GUI.Label(new Rect(20, 20, 200, 50), "Press SPACE to spawn an NPC");
        }
    }
}