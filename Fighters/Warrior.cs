namespace FightClub.Fighters
{
    public class Warrior : Fighter
    {
        public Warrior(string name = "Имя должен выбрать игрок")
            : base(
                name,
                "Безжалостный воин",
                "Ярость - боль делает воина только сильнее. После удара воин впадает в ярость и трижды бьет противника щитом. Урон каждого удара равен показателю силы",
                5,
                0,
                5
            ) { }

        public override int UseUltimateAbility()
        {
            int totalDamage = this.Strength * 3;

            Console.WriteLine(
                $"{this.Name} впадает в ярость! Он трижды бьет противника щитом и наносит {totalDamage} урона!"
            );

            return totalDamage;
        }
    }
}
