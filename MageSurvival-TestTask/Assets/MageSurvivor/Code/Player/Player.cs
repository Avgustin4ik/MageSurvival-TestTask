namespace MageSurvivor.Code.Player
{
    using System.Collections.Generic;
    using Abilities.Abstract;
    using UnityEngine;

    public class Player : IPlayer
    {
        public Player()
        {
            Debug.Log("Player constructor");
        }
        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<IAbility> Abilities { get; }
        public void SelectAbility(int index)
        {
            throw new System.NotImplementedException();
        }

        public void UseAbility(GameObject target)
        {
            throw new System.NotImplementedException();
        }

        public void UseAbility<T>(GameObject target) where T : IAbility
        {
            throw new System.NotImplementedException();
        }

        public void UseAbility(IAbility ability, GameObject target)
        {
            throw new System.NotImplementedException();
        }
    }
}