namespace MonoGame {
    public class Blizzard : Weather {
        public override int GetSnowRate()
        {
            return 150;
        }

        public override float GetWindPower()
        {
            return 80f;
        }
    }
}