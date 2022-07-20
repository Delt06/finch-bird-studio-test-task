using UnityEngine;

namespace Infrastructure
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private SceneData _scene;
        [SerializeField] private Player _playerPrefab;

        private void Start()
        {
            var playerSpawnPoint = _scene.PlayerSpawnPoint;
            Instantiate(_playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
        }
    }
}