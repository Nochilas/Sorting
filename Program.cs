using System;
using CarLib;
using System.Collections;

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
        static int[] GenerateIntArr(int length, int firstNum = 0, int lastNum = 9)
        {
            Random rand = new Random();
            int[] nums = new int[length];
            for (int i = 0; i < nums.Length; i++)
                    nums[i] = rand.Next(firstNum, lastNum);

            return nums;
        }

        static string[] GeneratePlates(int nPlates = 10, int strLength = 3, int intLength = 3)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rand = new Random();
            string[] plates = new string[nPlates];
            int[] nums = new int[intLength];
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
                nums = GenerateIntArr(intLength);
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

        static Car[] GenerateCar(int nCars)
        {
            string[] plates = GeneratePlates(intLength : 10);
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
            Array.Sort(carArray, new Car());
            return carArray;
        }

        static Car[] CarSort2(Car[] carArray)
        {
            Car temp;
            for (int i = 0; i < carArray.Length - 1; i++)
                {
                    Car comparer = new Car();
                    int c = comparer.Compare(carArray[i], carArray[i+1]);
                    if (c > 0)
                    {
                        temp = carArray[i];
                        carArray[i] = carArray[i + 1];
                        carArray[i + 1] = temp;
                    }
                }
            return carArray;
        }
        
        static void Main(string[] args)
        {   
            const int nCars = 10;
            Car[] cars = new Car[nCars];
            Car[] carss = new Car[nCars];

            //Car array
            cars = GenerateCar(nCars);
            carss = GenerateCar(nCars);

            //Sorting the cars array
            CarSort(cars);

            //Check if cars[] is sorted
            Console.WriteLine("Cars after sorting:");
            foreach(Car car in cars)
                Console.WriteLine(car.Plate);

            //Sorting the carss array
            CarSort(carss);

            //Check if cars[] is sorted
            Console.WriteLine("Carss after sorting:");
            foreach(Car carr in carss)
                Console.WriteLine(carr.Plate);
        }
    }
}
