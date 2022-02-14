﻿


//Task
//You are given an array a of positive integers a. You may choose some integer X and update a several times, where to update means to perform the following operations:

//pick a contiguous subarray of length not greater than the given k;
//replace all elements in the picked subarray with the chosen X.
//What is the minimum number of updates required to make all the elements of the array the same?

//Example
//For a = [1, 2, 2, 1, 2, 1, 2, 2, 2, 1, 1, 1] and k = 2, the output should be 4.

//Here's how a will look like after each update:

//[1, 2, 2, 1, 2, 1, 2, 2, 2, 1, 1, 1] ->
//[1, 1, 1, 1, 2, 1, 2, 2, 2, 1, 1, 1] ->
//[1, 1, 1, 1, 1, 1, 2, 2, 2, 1, 1, 1] ->
//[1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1] ->
//[1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
//Input / Output
//[input] integer array a
//An array of positive integers.

//Constraints:

//10 ≤ a.length ≤ 50,

//1 ≤ a[i] ≤ 10.

//[input] integer k
//A positive integer, the maximum length of a subarray.

//Constraints: 2 ≤ k ≤ 9.

//[output] an integer
//The minimum number of updates.



namespace myjinxin
{
    public class Kata
    {
        public int ArrayEqualization(int[] array, int k)
        {
            bool[] visitedNumbers = new bool[11];

            foreach (int number in array)
            {
                if (!visitedNumbers[number])
                {
                    visitedNumbers[number] = true;
                }
            }

            int changeCount = int.MaxValue;

            for (int number = 1; number < visitedNumbers.Length; number++)
            {
                if (!visitedNumbers[number])
                {
                    continue;
                }

                int currentChangeCount = GetChangeCount(array, number, k);

                if (currentChangeCount < changeCount)
                {
                    changeCount = currentChangeCount;
                }
            }

            return changeCount;
        }

        private static int GetChangeCount(int[] array, int targetNumber, int changeLength)
        {
            int changeCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != targetNumber)
                {
                    i += changeLength - 1;
                    changeCount++;
                }
            }

            return changeCount;
        }
    }
}