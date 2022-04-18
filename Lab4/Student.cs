using System.Collections.Generic;

namespace Lab4
{
    public class Student
    {
        public string givenTheoryQuestion;
        public string theoryQuestion;
        public string practQuestion;
        public string name;
        public string questionStatus;
        public Student(string name, string theoryQuestion, string practQuestion)
        {
            this.theoryQuestion = theoryQuestion;
            this.practQuestion = practQuestion;
            this.name = name;
            questionStatus = theoryQuestion;
        }
        public void ChangeQuestionStatus() => this.questionStatus = questionStatus.Equals(theoryQuestion) ? practQuestion : theoryQuestion ;
    }
}