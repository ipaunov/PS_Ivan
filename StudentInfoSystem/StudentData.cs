using System.Collections.Generic;

namespace StudentInfoSystem
{
    internal class StudentData
    {
        private static List<Student> _testStudents;

        public static List<Student> TestStudents
        {
            get
            {
                ResetTestStudentsData();
                return _testStudents;
            }
            set { }
        }

        private static void ResetTestStudentsData()
        {
            if (_testStudents == null)
            {
                _testStudents = new List<Student>(1);
                _testStudents.Add(new Student());
                _testStudents[0].name = "Vanko";
                _testStudents[0].middleName = "The";
                _testStudents[0].familyName = "One";
                _testStudents[0].faculty = "FKST";
                _testStudents[0].specialty = "Neshto s komputri";
                _testStudents[0].educationalDegree = "Bachelor";
                _testStudents[0].status = "Active";
                _testStudents[0].facultyNumber = "501219034";
                _testStudents[0].course = 3;
                _testStudents[0].flow = 9;
                _testStudents[0].group = 36;
            }
        }



    }
}
