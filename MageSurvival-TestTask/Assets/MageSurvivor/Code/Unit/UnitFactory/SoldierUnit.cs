namespace MageSurvivor.Code.Unit.UnitFactory
{
    using Abstract;

    public class SoldierUnit : AttackerUnit
    {
        public float AttackRange { get; set; }
        public float Damage { get; private set; }
        public override void SetConfig(Config config)
        {
            AttackRange = config.AttackRange;
            Damage = config.Damage;
            base.SetConfig(config);
        }

    }
}