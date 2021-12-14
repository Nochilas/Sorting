using System;
using CarLib;

namespace sorting
{
    class Program
    {
        static int[] GenerateIntArr(int x)
        {
            var rand = new Random();
            int[] nums = new int[x];
            for (int i = 0; i < nums.Length; i++)
                    nums[i] = rand.Next(0, 9);

            return nums;
        }

        static string GenerateString(int x)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var rand = new Random();
            string str = string.Empty;

            for (int i = 0; i < x; i++)
                str += string.Concat(alphabet[rand.Next(0, alphabet.Length)]);
            
            return str;
        }

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

        static Car[] CarSort(Car[] carArray)
        {
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

        static string[] GenerateStringArr(int x)
        {
            string str, str2;
            const int index = 3;
            const int str1index = 2;
            const int str2index = 3;
            int[] nums = new int[10];
            string[] strArr = new string[x];

            for (int j = 0; j < strArr.Length; j++)
            {
                //Pick n (2) random chars from alphabet
                str = GenerateString(str1index);

                //Generate 3 random numbers
                nums = GenerateIntArr(index);

                //Check nums[]
                Console.WriteLine("Nums before sorting:");
                foreach(var i in nums)
                    Console.Write($"{i} ");

                //Sorting the array of random numbers (Bubble Sort)
                nums = IntSort(nums);

                //Check sorting of nums[]
                Console.WriteLine("\nNums after sorting:");
                foreach(int i in nums)
                    Console.Write($"{i} ");
                
                Console.WriteLine();
                
                //Turn nums[] into string
                string strNum = string.Join("", nums);

                //Pick n (3) random chars from alphabet
                str2 = GenerateString(str2index);

                //Create string[j] in string array
                strArr[j] = str + strNum + str2;
            }

            return strArr;
        }
        
        static void Main(string[] args)
        {   
            const int lenght = 10;
            string[] strArr = new string[lenght];
            
            //Generate strArr[] (array of 10 random strings)
            strArr = GenerateStringArr(lenght);

            //Check strArr[]
            Console.WriteLine("Plates before sorting:");
            foreach(var ss in strArr)
                Console.WriteLine(ss);

            //10 istances of Car object with (plate) parameter
            //Mio dio che brutto, dimmi come fare meglio questa cosa
            Car car0 = new Car(strArr[0]);
            Car car1 = new Car(strArr[1]);
            Car car2 = new Car(strArr[2]);
            Car car3 = new Car(strArr[3]);
            Car car4 = new Car(strArr[4]);
            Car car5 = new Car(strArr[5]);
            Car car6 = new Car(strArr[6]);
            Car car7 = new Car(strArr[7]);
            Car car8 = new Car(strArr[8]);
            Car car9 = new Car(strArr[9]);

            //Car array
            Car[] carArray = new Car[10] {car0, car1, car2, car3, car4, car5, car6, car7, car8, car9};
            //Sorting the Car array
            CarSort(carArray);
        
            //Check if carArray[] is sorted
            Console.WriteLine("Plates after sorting:");
            foreach(var v in carArray)
                Console.WriteLine(v.Plate);
        }
    }
}
