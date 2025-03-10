namespace MageSurvivor.Code.Player
{
    using Reflex.Attributes;
    using UnityEngine;

    public class PlayerMono : MonoBehaviour
    {
        private IPlayer _player;
        public CharacterController characterController;
        
        // public PlayerMono(IPlayer player)
        // {
        //     _player = player;
        //     Debug.Log("PlayerMono constructor");
        // }
        
        [Inject]
        public void Construct(IPlayer player)
        {
            _player = player;
            Debug.Log("PlayerMono Construct");
        }
    }
}