using FightClub.Fighters;

namespace FightClub
{
    public class Game
    {
        #region Fields
        private Random random;
        private FightState fightState;
        private Fighter player1;
        private Fighter player2;
        #endregion

        #region Constructors
        public Game()
        {
            random = new Random();
            fightState = FightState.NextRound;
        }
        #endregion

        #region Methods
        public void StartGame()
        {
            Console.Clear();

            Console.WriteLine("ИГРОК 1 СОЗДАЕТ БОЙЦА\n");
            player1 = CreateFighter();
            Console.Clear();

            Console.WriteLine("ИГРОК 2 СОЗДАЕТ БОЙЦА\n");
            player2 = CreateFighter();
            Console.Clear();

            StartFight();
        }

        private Fighter CreateFighter()
        {
            Fighter fighter;

            Console.WriteLine("Назовите своего бойца:");
            string name = Console.ReadLine()!;

            Console.WriteLine("\nВыберите класс героя:");
            Console.WriteLine("1: Воин");
            Console.WriteLine("2: Ловкач");
            Console.WriteLine("3: Маг");

            string fighterType = Console.ReadLine()!;

            switch (fighterType)
            {
                case "1":
                    fighter = new Warrior(name);
                    break;
                case "2":
                    fighter = new Dodger(name);
                    break;
                case "3":
                    fighter = new Mage(name);
                    break;
                default:
                    fighter = new Warrior(name);
                    break;
            }

            SetUpFighterSkills(fighter);

            fighter.IsDead += () => fightState = FightState.Stopped;

            return fighter;
        }

        private void SetUpFighterSkills(Fighter fighter)
        {
            int points = Constants.POINTS_NUMBER;

            while (points > 0)
            {
                Console.Clear();

                Console.WriteLine(fighter);

                Console.WriteLine("Распределите очки умений среди характеристик персонажа:");
                Console.WriteLine("+1 Силы:       +{0} к урону", Constants.DAMAGE_MULTIPLIER);
                Console.WriteLine(
                    "+1 Ловкости:   +{0}% увернуться от атаки",
                    Constants.DODGE_MULTIPLIER
                );
                Console.WriteLine("+1 Живучести:  +{0} НР", Constants.HP_MULTIPLIER);

                Console.WriteLine(Environment.NewLine);

                Console.WriteLine("Осталось очков умений: {0}", points);
                Console.WriteLine("1: +1 Силы");
                Console.WriteLine("2: +1 Ловкости");
                Console.WriteLine("3: +1 Живучести");

                switch (Console.ReadLine())
                {
                    case "1":
                        fighter.Strength += 1;
                        break;
                    case "2":
                        fighter.Agility += 1;
                        break;
                    default:
                        fighter.Vitality += 1;
                        break;
                }

                points -= 1;
            }
        }

        private void StartFight()
        {
            for (int i = 3; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine($"{i}...");
                Console.ReadLine();
            }

            int round = 1;

            while (fightState == FightState.NextRound)
            {
                Console.Clear();
                Console.WriteLine($"РАУНД {round}\n");

                CalculateDamage(player1, player2);
                CalculateDamage(player2, player1);

                Console.WriteLine();

                Console.WriteLine($"ИГРОК 1:");
                Console.WriteLine(player1);
                Console.WriteLine();

                Console.WriteLine($"ИГРОК 2:");
                Console.WriteLine(player2);
                Console.WriteLine();

                Console.ReadLine();

                round += 1;
            }

            Console.WriteLine("БОЙ ОКОНЧЕН!");
            Console.ReadLine();
        }

        private void CalculateDamage(Fighter aggressor, Fighter victim)
        {
            if (victim.DodgeChance > this.random.Next(1, 101))
            {
                Console.WriteLine(
                    $"{aggressor.Name} хотел ударить, но противник увернулся от удара!"
                );
            }
            else
            {
                victim.HP -= aggressor.Kick();
                victim.HP -= aggressor.UseUltimateAbility();
            }
        }
        #endregion
    }
}
