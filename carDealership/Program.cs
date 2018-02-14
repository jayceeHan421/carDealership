using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace carDealership
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = readingCarInfo();
            UserInput inputInfo = userInputInfo();

            List<Car> filteredCars = new List<Car>();
            foreach(Car car in cars)
            {
                bool checkFlag = true;
                if(inputInfo.makeDigit != null)
                {
                    checkFlag = checkFlag && (inputInfo.makeDigit.ToLower() == car.make.ToLower());
                    if(checkFlag == false)
                    {
                        continue;
                    }
                }
                if(inputInfo.colorDigt != null)
                {
                    checkFlag = checkFlag && (inputInfo.colorDigt.ToLower() == car.color.ToLower());
                    if(checkFlag == false)
                    {
                        continue;
                    }
                }
                if (inputInfo.hasSunRoofDigit != null)
                {
                    checkFlag = checkFlag && (inputInfo.hasSunRoofDigit == car.hasSunroof);
                    if (checkFlag == false)
                    {
                        continue;
                    }
                }
                if (inputInfo.isFourWheelDriveDigit != null)
                {
                    checkFlag = checkFlag && (inputInfo.isFourWheelDriveDigit == car.isFourWheelDrive);
                    if (checkFlag == false)
                    {
                        continue;
                    }
                }
                if (inputInfo.hasLowMilesDigit != null)
                {
                    checkFlag = checkFlag && (inputInfo.hasLowMilesDigit == car.hasLowMiles);
                    if (checkFlag == false)
                    {
                        continue;
                    }
                }
                if (inputInfo.hasPowerWindowsDigit != null)
                {
                    checkFlag = checkFlag && (inputInfo.hasPowerWindowsDigit == car.hasPowerWindow);
                    if (checkFlag == false)
                    {
                        continue;
                    }
                }
                if (inputInfo.hasNavigationDigit != null)
                {
                    checkFlag = checkFlag && (inputInfo.hasNavigationDigit == car.hasNavigation);
                    if (checkFlag == false)
                    {
                        continue;
                    }
                }
                if (inputInfo.hasHeadedSeatsDigit != null)
                {
                    checkFlag = checkFlag && (inputInfo.hasHeadedSeatsDigit == car.hasHeatedSeat);
                    if (checkFlag == false)
                    {
                        continue;
                    }
                }

                if(inputInfo.yearRange != null)
                {
                    if(inputInfo.yearRange[0] != 0)
                    {
                        checkFlag = checkFlag && (car.year >= inputInfo.yearRange[0]);
                    }
                    if(inputInfo.yearRange[1] != 0)
                    {
                        checkFlag = checkFlag && (car.year <= inputInfo.yearRange[1]);
                    }

                    if(checkFlag == false)
                    {
                        continue;
                    }
                }

                if (inputInfo.priceRange != null)
                {
                    if (inputInfo.priceRange[0] != 0)
                    {
                        checkFlag = checkFlag && (car.price >= inputInfo.priceRange[0]);
                    }
                    if (inputInfo.priceRange[1] != 0)
                    {
                        checkFlag = checkFlag && (car.price <= inputInfo.priceRange[1]);
                    }

                    if (checkFlag == false)
                    {
                        continue;
                    }
                }

                if(checkFlag)
                {
                    Console.WriteLine(car);  
                }

            }
        }

        static List<Car> readingCarInfo()
        {
            List<Car> cars;
            using (StreamReader r = new StreamReader("../carInfo.JSON"))
            {
                string carInfo = r.ReadToEnd();
                //cars = JsonConvert.DeserializeObject<List<Car>>(carInfo);
                var settings = new JsonSerializerSettings();
                settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;

               cars = JsonConvert.DeserializeObject<List<Car>>(carInfo, settings);
            }
            return cars;
        }

        static UserInput userInputInfo()
        {
            UserInput userInputs = new UserInput();

            Console.WriteLine("Please provide some info about the car you want to buy. If no requirement for one option, just type return");
            Console.WriteLine("");
            Console.WriteLine("what is the car make? Chevy, Toyota, Mercedes, Ford. Please choose one");
            string make = Console.ReadLine();
            userInputs.makeDigit = make;
           


            Console.WriteLine("what is the car year range.");
            Console.WriteLine("Please provide min year");
            string minYear = Console.ReadLine();
            int[] yearRange = new int[2];
            if(!string.IsNullOrEmpty(minYear))
            {
                int minYearDigit = Convert.ToInt32(minYear);
                yearRange[0] = minYearDigit;
            }
            else
            {
                yearRange[0] = 0; 
            }

            Console.WriteLine("Please provide max year");
            string maxYear = Console.ReadLine();
            if(!string.IsNullOrEmpty(maxYear))
            {
                int maxYearDigit = Convert.ToInt32(maxYear);
                yearRange[1] = maxYearDigit;
            }
            else 
            {
                yearRange[1] = 0;
            }

            userInputs.yearRange = yearRange;



            Console.WriteLine("what is the color? Gray,  Silver, Black, White, Red. please choose one");
            string color = Console.ReadLine();
            userInputs.colorDigt = color;
            

            Console.WriteLine("what is the price range?");
            Console.WriteLine("Please provide the min price");
            int[] priceRange = new int[2];
            string minPrice = Console.ReadLine();
            if(!string.IsNullOrEmpty(minPrice)) 
            {
                int minPriceDigit = Convert.ToInt32(minPrice);
                priceRange[0] = minPriceDigit;
            }
            else
            {
                priceRange[0] = 0;
            }

            Console.WriteLine("Please provide the max price");
            string maxPrice = Console.ReadLine();
            if(!string.IsNullOrEmpty(maxPrice))
            {
                int maxPriceDigit = Convert.ToInt32(maxPrice);
                priceRange[1] = maxPriceDigit;
            }
            else
            {
                priceRange[1] = 0;
            }
            userInputs.priceRange = priceRange;

            Console.WriteLine("Does it need to have sun roof? Y, N, please choose one");
            String isSunRoof = Console.ReadLine();
            if(!string.IsNullOrEmpty(isSunRoof))
            {
                if(isSunRoof.ToLower().Equals("y"))
                {
                    userInputs.hasSunRoofDigit = true;
                }
                else
                {
                    userInputs.hasSunRoofDigit = false;
                }
            }

            Console.WriteLine("Does it to be four wheel drive? Y, N, pleae choose one");
            string hasFourWheelDrive = Console.ReadLine();
            if(!string.IsNullOrEmpty(hasFourWheelDrive))
            {
                if (hasFourWheelDrive.ToLower().Equals("y"))
                {
                    userInputs.isFourWheelDriveDigit = true;
                }
                else
                {
                    userInputs.isFourWheelDriveDigit = false;
                }
            }


            Console.WriteLine("Does it to have low miles? Y, N, please choose one");
            string hasLowMiles = Console.ReadLine();
            if (!string.IsNullOrEmpty(hasLowMiles))
            {
                if (hasLowMiles.ToLower().Equals("y"))
                {
                    userInputs.hasLowMilesDigit = true;
                }
                else
                {
                    userInputs.hasLowMilesDigit = false;
                }
            }

            Console.WriteLine("Does it to has power windows? Y, N please choose one");
            string hasPowerWindows = Console.ReadLine();
            if (!string.IsNullOrEmpty(hasPowerWindows))
            {
                if (hasPowerWindows.ToLower().Equals("y"))
                {
                    userInputs.hasPowerWindowsDigit = true;
                }
                else
                {
                    userInputs.hasPowerWindowsDigit = false;
                }
            }

            Console.WriteLine("Does it to has navigation? Y, N please choose one");
            string hasNavigation = Console.ReadLine();
            if (!string.IsNullOrEmpty(hasNavigation))
            {
                if (hasNavigation.ToLower().Equals("y"))
                {
                    userInputs.hasNavigationDigit = true;
                }
                else
                {
                    userInputs.hasNavigationDigit = false;
                }
            }

            Console.WriteLine("Does it to has heated seats? Y, N please choose one");
            string hasHeatedSeat = Console.ReadLine();
            if (!string.IsNullOrEmpty(hasHeatedSeat))
            {
                if (hasHeatedSeat.ToLower().Equals("y"))
                {
                    userInputs.hasHeadedSeatsDigit = true;
                }
                else
                {
                    userInputs.hasHeadedSeatsDigit = false;
                }
            }
            return userInputs;
        }
    }
}
