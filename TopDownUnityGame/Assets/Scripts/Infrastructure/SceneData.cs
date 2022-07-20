using UnityEngine;

namespace Infrastructure
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;

        public Transform PlayerSpawnPoint => _playerSpawnPoint;
    }
}