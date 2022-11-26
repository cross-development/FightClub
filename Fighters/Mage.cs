namespace FightClub.Fighters
{
    public class Mage : Fighter
    {
        public Mage(string name = "Имя должен выбрать игрок")
            : base(
                name,
                "Могущественный маг",
                "Концентрация - ничто не способно вывести мага из равновесия. Маг на секунду концентрируется и пускает в противника огненный шар на 1-60 урона",
                2,
                3,
                5
            ) { }

        public override int UseUltimateAbility()
        {
            int totalDamage = this.random.Next(1, 61);

            Console.WriteLine(
                $"{this.Name} на секунду концентрируется и пускает в противника огненный шар на {totalDamage} урона!"
            );

            return totalDamage;
        }
    }
}
