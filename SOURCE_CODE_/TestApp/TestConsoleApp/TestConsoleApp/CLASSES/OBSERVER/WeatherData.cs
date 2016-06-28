using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp.CLASSES
{
    class WeatherData:Subject
    {
        public WeatherData()
        {
            observers = new List<Observer>();
        }

        public void registerObserver(Observer o)
        {
            observers.Add(o);
        }
        public void removeObserver(Observer o)
        {
            int i = observers.IndexOf(o);
            if (i >= 0) observers.RemoveAt(i);
        }
        public void notifyObserver()
        {
            foreach (Observer o in observers)
            {
                o.update(temperature, humidity, pressure);
            }
        }

        protected void setTemperature(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            measurementsChanged();
        }

        protected void getTemperature() { }
        protected void getHimidity() { }
        protected void getPressure() { }

        public void measurementsChanged()
        {
            notifyObserver();
        }


        private List<Observer> observers;
        private float temperature;
        private float humidity;
        private float pressure;
    }

    public interface Observer
    {
       void update(float temperature, float humidity, float pressure);
    }
    public interface Subject
    {
        void registerObserver(Observer o);
        void removeObserver(Observer o);
        void notifyObserver();
    }
    public interface DisplayElement
    {
        void display();
    }



    public class CurrentConditionDisplay:Observer,DisplayElement
    {
        public CurrentConditionDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }
        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            display();
        }
        public void display()
        {
            Console.WriteLine("Current conditions: " + temperature + "F degrees and " + humidity + "% humidity");
        }

        private float temperature;
        private float humidity;
        private float pressure;
        private Subject weatherData;
    }
    public class StatisticDisplay : Observer, DisplayElement
    {
        public StatisticDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }
        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            display();
        }
        public void display()
        {
            Console.WriteLine("Current conditions: " + temperature + "F degrees and " + humidity + "% humidity");
        }

        private float temperature;
        private float humidity;
        private float pressure;
        private Subject weatherData;
    }
    public class ForecastDisplay : Observer, DisplayElement
    {
        public ForecastDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }
        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            display();
        }
        public void display()
        {
            Console.WriteLine("Current conditions: " + temperature + "F degrees and " + humidity + "% humidity");
        }
        private float temperature;
        private float humidity;
        private float pressure;
        private Subject weatherData;
    }
    public class ThirdPartyDisplay : Observer, DisplayElement
    {
        public ThirdPartyDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }
        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            display();
        }
        public void display()
        {
            Console.WriteLine("Current conditions: " + temperature + "F degrees and " + humidity + "% humidity");
        }

        private float temperature;
        private float humidity;
        private float pressure;
        private Subject weatherData;
    }
}
