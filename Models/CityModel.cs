using System.ComponentModel.DataAnnotations;

namespace Api_demo.Models
{
    public class CityModel
    {
        public int CityID { get; set; }
        public int StateID { get; set; }
       
        public int CountryID { get; set; }
        public string CityName { get; set; }
        public string PinCode { get; set; }
    }
}
