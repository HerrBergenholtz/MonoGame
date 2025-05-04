namespace MonoGame {
    public class Windy : Weather {
        public override int GetSnowRate()
        {
            return 55;
        }

        public override float GetWindPower()
        {
            return 110f;
        }
    }
}