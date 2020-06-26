using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace linqPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "I love dogs";
            string[] dogNames = { "Moti", "Kalu", "Samba", "Bingo", "Loki", "Tommy" };
            int[] numbers = { 5, 6, 3, 2, 1, 5, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

            List<Warrior> warriors = new List<Warrior>()
            {
                new Warrior(){Height = 100},
                new Warrior(){Height = 80},

                new Warrior(){Height = 100},

                new Warrior(){Height = 70},

                new Warrior(){Height = 50},

            };



            var shortWarrior = warriors.
                                Where
                                (wh => wh.Height == 100);
            var height = warriors.
                         Select(wh => (wh.Height));

           

            //select all numbers
            var getTheNumbers = from number in numbers
                                select number;
            //get the > 5 numbers in array
            var getTheNumbers1 = from number in numbers
                                 where number > 5
                                 select number;

            var dogsWithA = from dog in dogNames
                            where dog.Contains("a")
                            select dog;

            var dogsWithA1 = from dog in dogNames
                             where dog.Contains("a") && (dog.Length > 5)
                             select dog;
            var getTheNumbers2 = from number in numbers
                                 where number > 5
                                 && number < 10
                                 select number;
            //sorted
            var getTheNumbers3 = from number in numbers
                                 where number > 5
                                 && number < 10
                                 orderby number
                                 select number;
            //sorted descending
            var getTheNumbers4 = from number in numbers
                                 where number > 5
                                 && number < 10
                                 orderby number descending
                                 select number;



            var oddnumbers = from n in numbers
                             where n % 2 == 1
                             select n;
            //same as above but with lamda expression
            var oddnumbers1 = numbers.Where(x => (x%2==1));


            System.Console.WriteLine(string.Join(", ", oddnumbers1));

            System.Console.WriteLine(string.Join(", ", oddnumbers));

            System.Console.WriteLine(string.Join(", ", getTheNumbers3));
            System.Console.WriteLine(string.Join(", ", getTheNumbers4));
            System.Console.WriteLine(string.Join(", ", getTheNumbers2));
            System.Console.WriteLine(string.Join(", ", getTheNumbers));
            System.Console.WriteLine(string.Join(", ", getTheNumbers1));
            System.Console.WriteLine(string.Join(", ", dogsWithA));
            System.Console.WriteLine(string.Join(", ", dogsWithA1));
           
            
            
            
            // Console.ReadLine();

            //linq with objects

            List<Person> people = new List<Person>()
            {
                new Person("Kinza",54,59,Gender.Female),
                new Person("Anum",54,69,Gender.Female),
                new Person("Saba",59,70,Gender.Female),
                new Person("Sahar",60,100,Gender.Female),
                new Person("Noor",50,40,Gender.Female),
                new Person("Mushkbar",53,60,Gender.Female)

             };


            //select all people where length is 4
            var fourCharPeople = from p in people
                                 where (p.Name.Length == 4)
                                 select p;
            //order by wieght
            var OrderByWeight = from p in people
                                where (p.Name.Length == 4)
                                orderby p.Weight
                                orderby p.Name
                                orderby p.Height

                                select p;

            //give the count
            var OrderByWeight1 = (from p in people
                                 //where (p.Name.Length == 4)
                                 //orderby p.Weight
                                 //orderby p.Name
                                 //orderby p.Height

                                 select p).Count();

            foreach (var item in fourCharPeople)
            {
                System.Console.WriteLine(item.Name);
        
            }
            foreach (var item in OrderByWeight)
            {
                System.Console.WriteLine($"Name: {item.Name}, Weight: {item.Weight}");

            }
            System.Console.WriteLine(OrderByWeight1);
            Console.ReadLine();




        }



        private static int[] StringToIntArray(string array)
        {
            int[] arrayFromString = array.Split(' ')
                                    .Select(e => int.Parse(e))
                                    .ToArray();
            return arrayFromString;
        }
        internal class Warrior
        {
            public int Height { get; set; }
        }
        internal class Person
        {
            private string name;
            private int height;
            private int weight;
            private Gender gender;


            public string Name
            {
                get
                {
                    return this.name;
                }
                set
                {
                    this.name = value;
                }
            }
            public int Height
            {
                get
                {
                    return this.height;
                }
                set
                {
                    this.height = value;
                }
            }

            public int Weight
            {
                get
                {
                    return this.weight;
                }
                set
                {
                    this.weight = value;
                }
            }
            public Gender Gender { get; set; }

            public Person(string name, int height, int weight, Gender gender)
            {
                this.Name = name;
                this.Height = height;
                this.Weight = weight;
                this.Gender = gender;
            }
        }
        internal enum Gender
        {
            Male,
            Female
        }



    }
    
}
