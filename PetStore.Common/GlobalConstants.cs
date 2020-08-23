﻿namespace PetStore.Common
{
    public static class GlobalConstants
    {
        //Breed
        public const int BreedNameMinLenght = 5;
        public const int BreedNameMaxLenght = 35;

        //Client
        public const int UserNameMinLenght = 6;
        public const int UserNameMaxLenght = 30;
        public const int FirstNameMaxLenght = 40;
        public const int LastNameMaxLenght = 80;
        public const int EmailMinLenght = 6;
        public const int EmailMaxLenght = 100;

        //ClientProducts
        public const int MinQuantity = 0;
        public const int MaxQuantity = 999;

        //Order
        public const int TownMaxLenght = 50;
        public const int AddressMaxLenght = 200;

        //Pet
        public const int PetNameMaxLenght = 30;
        public const int PetMinAge = 0;
        public const int PetMaxAge = 300; // In case Turtle
        public const double PriceMin = 0.00;
        public const double PriceMax = double.MaxValue;
    }
}