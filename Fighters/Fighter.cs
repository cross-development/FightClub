namespace FightClub.Fighters
{
    public abstract class Fighter
    {
        #region Events
        public event Action IsDead; // fighter is dear
        #endregion

        #region Fields
        protected Random random;
        #endregion

        #region Properties
        public string Name { get; private set; }
        public string ClassDescription { get; private set; }
        public string UltimateAbilityDescription { get; private set; }
        private int strength;
        public int Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                Damage = value * Constants.DAMAGE_MULTIPLIER;
            }
        }
        public int Damage { get; private set; }
        private int agility;
        public int Agility
        {
            get { return agility; }
            set
            {
                agility = value;
                DodgeChance = value * Constants.DODGE_MULTIPLIER;
            }
        }
        public int DodgeChance { get; private set; }
        private int vitality;
        public int Vitality
        {
            get { return vitality; }
            set
            {
                vitality = value;
                HP = value * Constants.HP_MULTIPLIER;
            }
        }

        private int hp;
        public int HP
        {
            get { return hp; }
            set
            {
                hp = value;

                if (hp < 0)
                {
                    hp = 0;

                    if (IsDead != null)
                    {
                        IsDead();
                    }
                }
            }
        }
        #endregion

        #region Constructors
        protected Fighter(
            string name,
            string classDescription,
            string ultimateAbilityDescription,
            int strength,
            int agility,
            int vitality
        )
        {
            Name = name;
            ClassDescription = classDescription;
            UltimateAbilityDescription = ultimateAbilityDescription;
            Strength = strength;
            Agility = agility;
            Vitality = vitality;
            random = new Random();
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Имя: {Name}\nКласс: {ClassDescription}\nСила: {Strength}\t\tЛовкость: {Agility}\t\tЖивучесть: {Vitality}\nУрон: {Damage}\tШанс увернуться: {DodgeChance}%\tHP: {HP}\nУмение: {UltimateAbilityDescription}\n";
        }

        public int Kick()
        {
            int minBoundary = Damage - Constants.DAMAGE_VARIETY;
            int maxBoundary = Damage + Constants.DAMAGE_VARIETY + 1;
            int totalDamage = random.Next(minBoundary, maxBoundary);

            Console.WriteLine($"{this.Name} ударил и нанес {totalDamage} урона!");

            return totalDamage;
        }

        public abstract int UseUltimateAbility();
        #endregion
    }
}
