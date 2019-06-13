namespace P06.TrafficLights.Models
{
    using P06.TrafficLights.Contracts;

    public class Light : ILight
    {
        private LightSignal signal;

        public Light(LightSignal signal)
        {
            this.signal = signal;
        }

        public void ChangeLightCollor()
        {
            if (this.signal == LightSignal.Yellow)
            {
                this.signal = 0;
            }
            else
            {
                this.signal++;
            }
        }

        public override string ToString()
        {
            return this.signal.ToString();
        }
    }
}
