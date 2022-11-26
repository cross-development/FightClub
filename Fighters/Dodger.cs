namespace FightClub.Fighters
{
    public class Dodger : Fighter
    {
        public Dodger(string name = "Имя должен выбрать игрок")
            : base(
                name,
                "Изворотливый ловкач",
                "Ловкость рук - есть 25% шанс запутать противника и незаметно ударить второй рукой. Такой удар считается критическим попаданием (х3)",
                3,
                4,
                3
            ) { }

        public override int UseUltimateAbility()
        {
            int chance = this.random.Next(1, 101);

            if (chance <= 25)
            {
                int totalDamage = this.Damage * 3;

                Console.WriteLine(
                    $"{this.Name} изловчился и ударил второй рукой! Этот удар оказался критическим и нанес {totalDamage} урона!"
                );

                return totalDamage;
            }

            Console.WriteLine(
                $"{this.Name} попытался незаметно ударить второй рукой, но противник это заметил и увернулся"
            );

            return 0;
        }
    }
}
