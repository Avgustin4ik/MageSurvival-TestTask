namespace MageSurvivor.Code.Unit.Player
{
    using MageSurvivor.Code.Abilities;
    using MageSurvivor.Code.Abilities.Abstract;
    using UnitFactory.Abstract;
    using UnityEngine;

    public class Player : CharacterUnitBase, IPlayer
    {
        public void EquipAbility(IAbility ability)
        {
            Abilities.Add(ability);
        }
        
        public Player()
        {
            Abilities = new AbilityPool();
        }
        
        public AbilityPool Abilities { get; private set; }
        ~Player()
        {
            Debug.Log("Player Destructor");
        }

        public void SelectAbility(int index) => Abilities.SelectAbility(index);
        public void UseAbility(GameObject caster, GameObject target)
        {
            throw new System.NotImplementedException();
        }
        public void UseAbility(GameObject caster, Vector3 direction) => Abilities.UseSelectedAbility(caster, direction);

        public int Health { get; }
        public int Armor { get; }

        public void Die()
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