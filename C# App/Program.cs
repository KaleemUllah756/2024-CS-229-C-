using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Train_Ticketing_System
{
    class Program
    {
        static List<User> users = new List<User>();
        static List<Train> trains = new List<Train>();
        static string usersFile = "users.txt";
        static string trainsFile = "trains.txt";

        static void Main()
        {
            LoadData();
            while (true)
            {
                Console.WriteLine("1. Sign Up \n2. Sign In \n3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if (choice == "1") SignUp();
                else if (choice == "2") SignIn();
                else if (choice == "3") break;
                else Console.WriteLine("Invalid Option!\n");
            }
        }

        static void SignUp()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter Role (admin/user): ");
            string role = Console.ReadLine().ToLower();

            users.Add(new User(username, password, role));
            SaveUsers();
            Console.WriteLine("Sign-Up Successful!");
        }

        static void SignIn()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    Console.WriteLine($"Welcome, {user.Username}!");
                    if (user.Role == "admin") AdminMenu();
                    else UserMenu();
                    return;
                }
            }
            Console.WriteLine("Invalid Username or Password!");
        }

        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("Admin Menu:\n1. Add Train\n2. View Trains\n3. Update Train\n4. Delete Train\n5. Logout");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if (choice == "1") AddTrain();
                else if (choice == "2") ViewTrains();
                else if (choice == "3") UpdateTrain();
                else if (choice == "4") DeleteTrain();
                else if (choice == "5") break;
                else Console.WriteLine("Invalid Option!\n");
            }
        }

        static void UserMenu()
        {
            Console.WriteLine("Available Trains:");
            if (trains.Count == 0)
            {
                Console.WriteLine("No trains available.");
            }
            else
            {
                ViewTrains();
            }
        }

        static void AddTrain()
        {
            Console.Write("Enter Train ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Train Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Route: ");
            string route = Console.ReadLine();

            trains.Add(new Train(id, name, route));
            SaveTrains();
            Console.WriteLine("Train Added Successfully!");
        }

        static void ViewTrains()
        {
            if (trains.Count == 0)
            {
                Console.WriteLine("No trains available.");
            }
            else
            {
                foreach (Train train in trains)
                {
                    Console.WriteLine($"ID: {train.Id}, Name: {train.Name}, Route: {train.Route}");
                }
            }
        }

        static void UpdateTrain()
        {
            Console.Write("Enter Train ID to Update: ");
            int id = int.Parse(Console.ReadLine());
            Train train = trains.Find(t => t.Id == id);

            if (train != null)
            {
                Console.Write("Enter New Name: ");
                train.Name = Console.ReadLine();
                Console.Write("Enter New Route: ");
                train.Route = Console.ReadLine();
                SaveTrains();
                Console.WriteLine("Train Updated Successfully!");
            }
            else
                Console.WriteLine("Train Not Found!");
        }

        static void DeleteTrain()
        {
            Console.Write("Enter Train ID to Delete: ");
            int id = int.Parse(Console.ReadLine());
            Train train = trains.Find(t => t.Id == id);

            if (train != null)
            {
                trains.Remove(train);
                SaveTrains();
                Console.WriteLine("Train Deleted Successfully!");
            }
            else
                Console.WriteLine("Train Not Found!");
        }

        static void SaveUsers()
        {
            using (StreamWriter sw = new StreamWriter(usersFile))
            {
                foreach (User user in users)
                {
                    sw.WriteLine($"{user.Username},{user.Password},{user.Role}");
                }
            }
        }

        static void SaveTrains()
        {
            using (StreamWriter sw = new StreamWriter(trainsFile))
            {
                foreach (Train train in trains)
                {
                    sw.WriteLine($"{train.Id},{train.Name},{train.Route}");
                }
            }
        }

        static void LoadData()
        {
            if (File.Exists(usersFile))
            {
                foreach (string line in File.ReadAllLines(usersFile))
                {
                    string[] data = line.Split(',');
                    users.Add(new User(data[0], data[1], data[2]));
                }
            }

            if (File.Exists(trainsFile))
            {
                foreach (string line in File.ReadAllLines(trainsFile))
                {
                    string[] data = line.Split(',');
                    trains.Add(new Train(int.Parse(data[0]), data[1], data[2]));
                }
            }
        }
    }
}
