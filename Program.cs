using System;
using CarLib;

namespace sorting
{
    class Program
    {
        static void Main(string[] args)
        {        
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string str, str2;
            var rand = new Random();
            int[] nums = new int[10];
            int temp;
            string[] strArr = new string[10];

            for (int j = 0; j < 10; j++)
            {
                //Pick 2 random chars from alphabet
                str = string.Concat(alphabet[rand.Next(0, 25)], alphabet[rand.Next(0, 25)]);

                //Generate 3 random numbers
                for (int i = 0; i < 10; i++)
                    nums[i] = rand.Next(0, 9);

                //Check nums[]
                Console.WriteLine("Nums before sorting:");
                foreach(var i in nums)
                    Console.Write($"{i} ");

                //Sorting the array of random numbers (Bubble Sort)
                for (int i = 0; i < 9; i++)
                    for(int k = 0; k < 9; k++)
                        if(nums[k] > nums[k+1])
                            {
                                temp = nums[k];
                                nums[k] = nums[k+1];
                                nums[k+1] = temp;
                            }

                //Check sorting of nums[]
                Console.WriteLine("\nNums after sorting:");
                foreach(int i in nums)
                    Console.Write($"{i} ");
                
                Console.WriteLine();
                
                //Turn nums[] into string
                string strNum = string.Join("", nums);

                //Pick 3 more random chars from alphabet
                str2 = string.Concat(alphabet[rand.Next(0, 25)], alphabet[rand.Next(0, 25)], alphabet[rand.Next(0, 25)]);

                //Create string[j] in string array
                strArr[j] = str + strNum + str2;
            }

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
            
            //Sorting the Car array with the Compare function
            Car safetyCar = new Car(string.Empty); //= temp for Car objects

            for(int j = 0; j < 10; j++)
                for(int i = 0; i < 9; i++)
                {
                    int c = string.Compare(carArray[i].Plate, carArray[i+1].Plate);

                    if(c > 0)
                    {
                        safetyCar = carArray[i];
                        carArray[i] = carArray[i+1];
                        carArray[i+1] = safetyCar;
                    }
                }
        
            //Check if carArray[] is sorted
            Console.WriteLine("Plates after sorting:");
            foreach(var v in carArray)
                Console.WriteLine(v.Plate);

        }
    }
}
