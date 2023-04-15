using System;

namespace Loim
{
    internal class QuestionClass
    {
        private int difficulty;
        private string question;
        private string a;
        private string b;
        private string c;
        private string d;
        private char answer;
        private string category;

        public int Difficulty
        {
            get { return difficulty; }
            set
            {
                if (value < 1 || value > 16)
                {
                    throw new Exception("The value cannot be less than 1 and greater the 16!");
                }
                difficulty = value;
            }
        }

        public string Question
        {
            get { return question; }
            set
            {
                if (value == "")
                {
                    throw new Exception("The value cannot be empty!");
                }
                question = value;
            }
        }

        public string A
        {
            get { return a; }
            set
            {
                if (value == "")
                {
                    throw new Exception("The value cannot be empty!");
                }
                a = value;
            }
        }

        public string B
        {
            get { return b; }
            set
            {
                if (value == "")
                {
                    throw new Exception("The value cannot be empty!");
                }
                b = value;
            }
        }

        public string C
        {
            get { return c; }
            set
            {
                if (value == "")
                {
                    throw new Exception("The value cannot be empty!");
                }
                c = value;
            }
        }

        public string D
        {
            get { return d; }
            set
            {
                if (value == "")
                {
                    throw new Exception("The value cannot be empty!");
                }
                d = value;
            }
        }

        public char Answer
        {
            get { return answer; }
            set
            {
                if (value != 'A' && value != 'B' && value != 'C' && value != 'D')
                {
                    throw new Exception("The value can only be A, B, C or D!");
                }
                answer = value;
            }
        }

        public string Category
        {
            get { return category; }
            set
            {
                if (value == "")
                {
                    throw new Exception("The value cannot be empty!");
                }
                category = value;
            }
        }

        public QuestionClass(string dataline)
        {
            string[] data = dataline.Split(';');
            Difficulty = int.Parse(data[0]);
            Question = data[1];
            A = data[2];
            B = data[3];
            C = data[4];
            D = data[5];
            Answer = char.Parse(data[6]);
            Category = data[7];
        }
    }
}
