using System;

namespace ConsoleAppSvu
{
    class Program
    {

        static void Main(string[] args)
        {
            //section 1******************************************************************************
            
            int numQues = 0;
            //Ask user how many times he want to answer
            Console.WriteLine("Please enter the maximum number of questions?");
            numQues = int.Parse(Console.ReadLine());
            //check of value numQues if valid or not
            while (numQues <= 0)
            {
                Console.WriteLine("Error: this value not valid, Please!!! enter the maximum number of questions greater than 0?");
                numQues = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("===============================");

            //-----------------------------------------------------------------


            //Arrays for.....
            int[] userAnswers = new int[numQues];
            int[] correctAnswers = new int[numQues];
            string[] strQues = new string[numQues];
            string[] arrTypeForAllQues = new string[numQues];
            int[] rateAnswers = new int[numQues];
            //-----------------------------------------------


            //for loop to ask questions
            for (int i = 0; i < numQues; i++)
            {
                int length = 0;
                //Ask user how many length string he want to answer
                Console.WriteLine("Please enter an integer value between 3 and 100 (the number of characters from which to certain (Odd/Even/Primary) number == Degree of difficulty");
                length = int.Parse(Console.ReadLine());

                //Check the user answer if the condition is not met. Repeat...
                while (length < 3 || length > 100)
                {
                    Console.WriteLine("please!!! inter number between 3 and 100");
                    length = int.Parse(Console.ReadLine());
                    Console.WriteLine("===============================");
                }
                //----------------------------------------------------------------------------------------------------------------------------------------------------------------------



                //Arrays for....
                //string[] arr = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
                string[] typeRandomChar = { "number", "letter" };
                int[] numbers = new int[length];
                //--------------------------------------------------------------------------------------------------------------------------------------------------


                Random random = new Random();
                int num = 0;
                //for loop to generate random string with user input length
                string randomString = "";
                for (int j = 0; j < length; j++)
                {
                    num = random.Next(0, 9);
                    int randomTypeIndex = random.Next(0, typeRandomChar.Length);
                    switch (typeRandomChar[randomTypeIndex])
                    {
                        case "number":
                            //add to numbers array
                            numbers[j] = num;
                            randomString += num.ToString();
                            break;

                        case "letter":
                            num = random.Next(65, 85);
                            randomString += (char)num;
                            break;
                    }
                }
                //store string in array strQues
                strQues[i] = randomString;
                //Print string (randomString)
                Console.WriteLine(randomString);
                //----------------------------------------------------------------------------------------------------


                //Array containing question types
                string[] typQues = { "odd", "even", "prime" };
                int index = random.Next(0, typQues.Length);
                string randomType = typQues[index];
                arrTypeForAllQues[i] = randomType;


                ////function clucate correct answer and store in correctAnswers array   
                //checkNumbers(correctAnswers, i, length, numbers, randomType, randomString);
                //switch statement case odd, even, prime
                switch (randomType)
                {
                    //case odd
                    //check how many odd number in array numbers
                    case "odd":
                        int count = 0;
                        for (int j = 0; j < length; j++)
                        {
                            if (randomString[j] >= '0' && randomString[j] < '9')
                            {
                                Convert.ToInt32(randomString[j]);
                                if (randomString[j] % 2 != 0)
                                {
                                    count++;
                                }
                            }

                        }
                        //store the correct answer in array
                        correctAnswers[i] = count;
                        break;
                    //case even
                    //check how many even number in array numbers
                    case "even":
                        int count2 = 0;
                        for (int j = 0; j < length; j++)
                        {

                            if (randomString[j] >= '0' && randomString[j] < '9')
                            {
                                Convert.ToInt32(randomString[j]);
                                if (randomString[j] % 2 == 0)
                                {
                                    count2++;
                                }
                            }
                        }
                        //store the correct answer in array
                        correctAnswers[i] = count2;
                        break;
                    //case prime
                    //check how many prime number in array numbers
                    case "prime":
                        int count3 = 0;
                        for (int j = 0; j < length; j++)
                        {
                            if (randomString[j] >= '0' && randomString[j] < '9')
                            {
                                Convert.ToInt32(randomString[j]);
                                if (randomString[j] > 1 && (randomString[j] == 2 || randomString[j] % 2 != 0))
                                {
                                    count3++;
                                }
                            }

                        }
                        //store the correct answer in array
                        correctAnswers[i] = count3;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
                //-----------------------------------------------------------

                //Ask the user how many numbers of the randomType
                Console.WriteLine($"how many times number {randomType} in this string if you want skip this question input (ignore) to ");

                //string answer
                string userAnsStr = Console.ReadLine().ToLower();
                Console.WriteLine("===============================");
                //if answer is ignore store 0 in rateAnswers then skip the question and go to next question
                if (userAnsStr == "ignore")
                {
                    rateAnswers[i] = 0;
                    continue;
                }
                int userAnsNum = int.Parse(userAnsStr); //convert string answer to number 
                userAnswers[i] = userAnsNum;//store user answer in array

                //compare beetween ans user and correct answer then store the rate in rateAnswers array
                int testAns = userAnsNum == correctAnswers[i] ? rateAnswers[i] = 1 : rateAnswers[i] = 0;
            }
            //-----------------------------------------------



            //section 2******************************************************************************
            //do while loob to ask user he want see countFalse or countTrue or printAllQues
            bool exitFromApp = false;
            do
            {
                Console.WriteLine("To get the number of right answers, type 1:");
                Console.WriteLine("To get the number of worng answers, type 2:");
                Console.WriteLine("To view all  the questions with correct and answered responses, type 3:");
                Console.WriteLine("To exit, type exit");
                string selectedMethod = Console.ReadLine().ToLower();

                switch (selectedMethod)
                {
                    case "1":
                        CountRightAnswers(rateAnswers);
                        break;
                    case "2":

                        CountWrongAnswers(rateAnswers);
                        break;
                    case "3":
                        PrintAllQues(strQues, userAnswers, correctAnswers, arrTypeForAllQues);
                        break;
                    case "exit":
                        exitFromApp = true;
                        break;
                    default:
                        Console.WriteLine("Sorry, that's not a valid option.");
                        break;
                }

                Console.WriteLine();
            }
            while (!exitFromApp);
            //-----------------------------------------------
        }


        //Functions**************************************************************************
        
        //method to print length of false values in array rateAnswers
        public static void CountWrongAnswers(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    count++;
                }
            }
            Console.WriteLine($"The number of worng answers is: {count}");

        }
        //method to print length of true values in array rateAnswers
        public static void CountRightAnswers(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 1)
                {
                    count++;
                }
            }
            Console.WriteLine($"The number of right answers is: {count}");

        }

        //method to print all  questions with correct answer and user answer
        public static void PrintAllQues(string[] strQues, int[] answer, int[] correctAnswers, string[] arrTypeForAllQues)
        {
            Console.WriteLine("strQues    type Question    user answer    correctAnswers");
            Console.WriteLine("===============================");
            for (int i = 0; i < strQues.Length; i++)
            {
                Console.WriteLine($"{strQues[i]}     {arrTypeForAllQues[i]}     {answer[i]}     {correctAnswers[i]}");
            }
        }
    }
}
