﻿using System;
using CarLib;

namespace sorting
{
    class Program
    {
        //Nums into string
        static string NumsToString(int[] nums)
        {
            string strNum = string.Join("", nums);
            return strNum;
        }

        //Generating
        static int[] GenerateIntArr(int length)
        {
            var rand = new Random();
            int[] nums = new int[length];
            for (int i = 0; i < nums.Length; i++)
                    nums[i] = rand.Next(0, 9);

            return nums;
        }

        static string[] GeneratePlates(int nPlates = 10, int strLength = 3, int intArrIndex = 3)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rand = new Random();
            string[] plates = new string[nPlates];
            int[] nums = new int[intArrIndex];
            string strFirst = string.Empty;
            string strEnd = string.Empty;
            string strNum = string.Empty;

            for(int i = 0; i < nPlates; i++)
            {
                for (int j = 0; j < strLength; j++)
                    //Create string of length = strLength (first n letters of plate)
                    strFirst += string.Concat(alphabet[rand.Next(0, alphabet.Length)]);
                
                for (int j = 0; j < strLength - 1; j++)
                    //Create second string of length = strLength - 1 (last n - 1 letters of plate)
                    strEnd += string.Concat(alphabet[rand.Next(0, alphabet.Length)]);
                
                //Generate array of random numbers
                nums = GenerateIntArr(intArrIndex);
                //Sort the array of random numbers
                nums = IntSort(nums);
                //Turn nums[] in a string
                strNum = NumsToString(nums);

                plates[i] = strFirst + strNum + strEnd;

                strFirst = string.Empty;
                strEnd = string.Empty;
            }

            plates = StringSort(plates);

            return plates;
        }

        static Car[] GenerateCar(int nCars, string[] plates)
        {
            Car[] cars = new Car[nCars];

            for(int i = 0; i < cars.Length; i++)
            {
                cars[i] = new Car();
                cars[i].Plate = plates[i];
            }
            return cars;
        }

        //Sorting
        static int[] IntSort(int[] nums)
        {
            int temp;
            
            //Bubble Sort
            for (int i = 0; i < nums.Length; i++)
                for(int k = 0; k < nums.Length - 1; k++)
                    if(nums[k] > nums[k+1])
                        {
                            temp = nums[k];
                            nums[k] = nums[k+1];
                            nums[k+1] = temp;
                        }
            return nums;
        }

        static string[] StringSort(string[] strArr)
        {
            string temp = string.Empty;

            for (int i = 0; i < strArr.Length; i++)
		        for (int j = 0; j < strArr.Length - 1; j++)
                {
                    int c = string.Compare(strArr[j], strArr[j+1]);

                    if (c > 0)
                    {
                        temp = strArr[j];
                        strArr[j] = strArr[j + 1];
                        strArr[j + 1] = temp;
                    }
                }

            return strArr;
        }

        static Car[] CarSort(Car[] carArray)
        {
            //Su questo non ho ancora fatto niente
            Car safetyCar = new Car(string.Empty); //= temp for Car objects

            for(int j = 0; j < carArray.Length; j++)
                for(int i = 0; i < carArray.Length - 1; i++)
                {
                    int c = string.Compare(carArray[i].Plate, carArray[i+1].Plate);

                    if(c > 0)
                    {
                        safetyCar = carArray[i];
                        carArray[i] = carArray[i+1];
                        carArray[i+1] = safetyCar;
                    }
                }
            return carArray;
        }
        
        static void Main(string[] args)
        {   
            const int nPlates = 10;
            const int index = 10;
            const int strLength = 3;
            const int nCars = nPlates;
            string[] plates = new string[nPlates];
            Car[] cars = new Car[nCars];
            
            //Generate strArr[] (array of 10 random strings)
            plates = GeneratePlates(nPlates, strLength, index);
            
            foreach(string plate in plates)
                Console.WriteLine(plate);

            //Car array
            cars = GenerateCar(nCars, plates);
            
            /*
            //Sorting the Car array
            cars = CarSort(cars);
        
            
            //Check if carArray[] is sorted
            Console.WriteLine("Cars after sorting:");
            foreach(Car car in cars)
                Console.WriteLine(car.Plate);*/
        }
    }
}
