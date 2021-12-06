using System;

namespace BuildingProgram
{

    public abstract class Logger
    {
        public abstract void ShowMessage(string message);
    }

    public sealed class ConsoleLogger : Logger
    {
        public override void ShowMessage(string message)
        {
            System.Console.WriteLine(message);
        }
    }

    public class Building
    {
        private static int lastBuildingNumber;

        private int _buildingNumber;
        private float _buildingHight;
        private int _buildingFloor;
        private int _buildingEntrance;
        private int _buildingApartment;

        private Logger _logger;

        public Building()
        {
            lastBuildingNumber++;

            _buildingNumber= lastBuildingNumber;
            _logger = new ConsoleLogger();
        }

        public int Number
        {
            get { return _buildingNumber; }
        }

        public float Hight

        {
            get { return _buildingHight; }
            set { _buildingHight = value; }
        }

        public int Floor

        {
            get { return _buildingFloor; }
            set { _buildingFloor = value; }
        }

        public int Entrance

        {
            get { return _buildingEntrance; }
            set { _buildingEntrance = value; }
        }

        public int Apartment

        {
            get { return _buildingApartment; }
            set { _buildingApartment = value; }
        }

        public void CalculateFloorHigh()
        {
            var buildingHigh = (_buildingHight / _buildingFloor);
            _logger.ShowMessage($" Высота этажа {buildingHigh} м");
        }

        public void CalculateNumberOfApartementInEntrance()
        {
            var appInEntrence = (_buildingApartment / _buildingEntrance);
            _logger.ShowMessage($" Квартир в одном подъезде - {appInEntrence}");
        }

        public void CalculateNumberOfApartementOnFloor()
        {
            var appOnFloor = (_buildingApartment / _buildingEntrance) / _buildingFloor;
            _logger.ShowMessage($" Квартир на одном этаже - {appOnFloor}");
        }

    }



    class Program
    {
        static void Main()
        {
           
            Building building = new Building();
            Logger logger = new ConsoleLogger();

 
            logger.ShowMessage("Высота здания");
            building.Hight = int.Parse(Console.ReadLine());

            logger.ShowMessage("Количество этажей в здании");
            building.Floor = int.Parse(Console.ReadLine());

            logger.ShowMessage("Количество подъездов в здании");
            building.Entrance = int.Parse(Console.ReadLine());

            logger.ShowMessage("Количество квартир в здании");
            var numberOfappInBuilding = int.Parse(Console.ReadLine());
            while ((numberOfappInBuilding / building.Entrance) % building.Floor != 0  || (building.Entrance * building.Floor) / numberOfappInBuilding -1 !=0 || numberOfappInBuilding % building.Entrance !=0)
            {
                logger.ShowMessage("Невозможно поделить количество квартир на количество подъездов или этажей в здании без остатка, введите другое количество квартир");
                numberOfappInBuilding = int.Parse(Console.ReadLine());
            }
            building.Apartment = numberOfappInBuilding;


            logger.ShowMessage($" Номер дома - {building.Number} Высота здания - {building.Hight}, Этажность - {building.Floor}, Подъездов в здании - {building.Entrance}, Квартир в здании - {building.Apartment} ");
            

            building.CalculateFloorHigh();
            building.CalculateNumberOfApartementOnFloor();
            building.CalculateNumberOfApartementInEntrance();

        }
    }
}
