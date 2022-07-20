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
    }
}