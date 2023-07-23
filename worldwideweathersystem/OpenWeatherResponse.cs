namespace worldwideweathersystem
{
    public class OpenWeatherResponse
    {
        public Main Main { get; set; }
        public string[] Weather { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
    }

    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }
}
