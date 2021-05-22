namespace Altkom.Shop.Models
{
    public class Coordinate : Base
    {

        public Coordinate()
        {

        }

        public Coordinate(double latitude, double longitude)
            : this()
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

}
