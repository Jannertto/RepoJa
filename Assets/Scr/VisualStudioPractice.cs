using UnityEngine;
using UnityEngine.UI;

//Remember to change this to YOUR OWN NAMESPACE
//So namespace your_student_ID

namespace AA1762
{
    public class VisualStudioPracticeScript : MonoBehaviour
    {
        private int numOne = 2;
        private int numTwo = 5;

        //This is a single-line comment, useful for writing comments!
        /*
         * This is a multi-line comment, useful for writing out even more comments!
         * You can also comment out code with either single- or multi-line comments like this:
         * private int commentedVariable = 9001;
         */
        //Or like this:
        //private int anotherCommentedVariable = 9002;


        public int checkAnswer()
        {
            //EXERCISE: Change the name of this variable to better represent its use. 
            //How could you rename all of the instances at once?
            int RInt = 0;
            RInt = numOne + numOne * numTwo;
            return RInt;
        }

        //EXERCISE: Move the code below to the correct place, and uncomment it.
        //How could you move it the most efficiently?
        //qwa = numOne + numOne* numTwo;
    }
}
