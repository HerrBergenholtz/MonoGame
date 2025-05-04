namespace MonoGame {
    public class Calm : Weather {
        public override int GetSnowRate()
        {
            return 40;
        }

        public override float GetWindPower()
        {
            return 30f;
        }
    }
}