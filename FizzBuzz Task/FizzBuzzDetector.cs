using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz_Task
{
    public class FizzBuzzDetector
    {

        class Overlapping
        {
            public int Start_index { get; set; }
            public int End_index { get; set; }
            public int Word_order { get; set; }
        }

       

        public FizzBuzzResult getOverlappings(string Input)
        {


            // validations 
            if (Input == null)
                throw new ArgumentNullException(nameof(Input));

            if (Input.Length < 7 || Input.Length > 100)
                throw new ArgumentException("Input length must be between 7 and 100 characters.");



            List<Overlapping> overlappings = new List<Overlapping>();
            bool is_Start = true;
            int start_ind = 0;
            int end_ind = 0;
            int word_order = 0;

            for (int i = 0; i < Input.Length; i++)
            {
                if (is_Start)
                {
                    if (char.IsLetterOrDigit(Input[i]))
                    {
                        start_ind = i;
                        is_Start = false;
                    }
                }
                else if (!is_Start)
                {
                    if (!char.IsLetterOrDigit(Input[i]))
                    {
                        end_ind = i - 1;
                        word_order++;
                        overlappings.Add(new Overlapping { Start_index = start_ind, End_index = end_ind, Word_order = word_order });
                        is_Start = true;
                    }
                }

               
            }

            if (!is_Start)
            {
                end_ind = Input.Length - 1;
                word_order++;

                overlappings.Add(new Overlapping
                {
                    Start_index = start_ind,
                    End_index = end_ind,
                    Word_order = word_order
                });
            }

            return ResultBuilder(overlappings, Input);

        }

        private FizzBuzzResult ResultBuilder(List<Overlapping> overlappings, string Input)
        {
            StringBuilder result = new StringBuilder();
            int _Count = 0;
            int currentIndex = 0;

            foreach (var word in overlappings)
            {
                // Append characters before the current word
                result.Append(Input.Substring(
                    currentIndex,
                    word.Start_index - currentIndex));

                // Detect Fizzbuzz based on the word order
                if (word.Word_order % 15 == 0)
                {
                    result.Append("FizzBuzz");
                    _Count++;
                }
                else if (word.Word_order % 3 == 0)
                {
                    result.Append("Fizz");
                    _Count++;
                }
                else if (word.Word_order % 5 == 0)
                {
                    result.Append("Buzz");
                    _Count++;
                }
                else
                {
                    result.Append(Input.Substring(
                        word.Start_index,
                        word.End_index - word.Start_index + 1));
                }

                currentIndex = word.End_index + 1;
            }

            // Append remaining characters after the last word
            result.Append(Input.Substring(currentIndex));

            return new FizzBuzzResult
            {
                Result = result.ToString(),
                Count = _Count
            };

        }

    }
}
