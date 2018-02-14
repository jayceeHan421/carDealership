using System;
namespace carDealership
{
    public class Car
    {

        public string carId { get; set; }
        public string make { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public int price { get; set; }
        public bool hasSunroof { get; set; }
        public bool isFourWheelDrive { get; set; }
        public bool hasLowMiles { get; set; }
        public bool hasPowerWindow { get; set; }
        public bool hasNavigation { get; set; }
        public bool hasHeatedSeat { get; set; }

        public override string ToString()
        {
            return string.Format("[Car: carId={0}, make={1}, year={2}, color={3}, price={4}, hasSunroof={5}, isFourWheelDrive={6}, hasLowMiles={7}, hasPowerWindow={8}, hasNavigation={9}, hasHeatedSeat={10}]", carId, make, year, color, price, hasSunroof, isFourWheelDrive, hasLowMiles, hasPowerWindow, hasNavigation, hasHeatedSeat);
        }
    }
}
