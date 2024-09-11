namespace yocar.Insurance.Services.Dtos.Location
{
    public class CreateLocationDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        public int GarageID { get; set; }
    }
}
