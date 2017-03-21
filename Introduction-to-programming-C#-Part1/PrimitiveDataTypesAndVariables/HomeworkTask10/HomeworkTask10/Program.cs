using System;

namespace HomeworkTask10 {
    class AppStart {
        static void Main() {

            string firstName = "Boyan";
            string lastName = "Hristov";
            byte age = 17;
            char gender = 'm';
            int idNumber = 47238;
            long uniqueEmployeeNumber = 90748123984347453;
            string shownGender;

            if (gender == 'm') {
                shownGender = "male";
            }
            else if (gender == 'f') {
                shownGender = "female";
            }
                else {
                    shownGender = "of uknown gender";
                }

            Console.WriteLine("I am {0} {1}, a {2} year old {3} with id {4} and unique employee number {5}!",
                firstName, lastName, age, shownGender, idNumber, uniqueEmployeeNumber);

        }
    }
}
