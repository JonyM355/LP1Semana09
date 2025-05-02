namespace AnimalKingdom
{
    public class Bat : Animal, IMammal, ICanFly
    {
        public int NumberOfNipples { get { return 2; } }
        public int NumberOfWings { get { return 2; } }

        public override string Sound()
        {
            return base.Sound() + "Tchiii";
        }
    }
}