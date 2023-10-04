// Project Application
// Written by: Inna Maximova 1331169

    //Part B
    class Program
    {

        private static string password = "password";
        private static Computer[] inventory;
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my ElectricsComp program!");
            Console.Write("Enter the maximum number of the computers you would like to store: ");
            int n = Convert.ToInt32(Console.ReadLine());
            inventory = new Computer[n];
            char choice;
            do
            {
                MainMenu();
                choice = Convert.ToChar(Console.ReadLine());

                switch (choice)
                {
                    case '1':
                        choice1();
                        break;
                    case '2':
                        choice2();
                        break;
                    case '3':
                        choice3();
                        break;
                    case '4':
                        choice4();
                        break;
                    case '5':
                        choice5();
                        copyText();
                        break;
                    default:
                        Console.WriteLine("This is not a valid entry!");
                        break;
                }//end of swich



            } while (choice != '5');
        }// end of main
        public static void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("     1.  Enter new computers (password required)");
            Console.WriteLine("     2.  Change information of a computer (password required)");
            Console.WriteLine("     3.  Display all computers by a specific brand");
            Console.WriteLine("     4.  Display all computers under a certain price");
            Console.WriteLine("     5.  Quit");
            Console.Write("Please enter your choice: ");
        }//end of MainMenu
        public static void choice1()
        {
            if (!verPass())
            {
                return;
            }
            Console.Write("How many computers would you like to enter: ");
            int numOfCompWishToAdd = Convert.ToInt32(Console.ReadLine());

            int availableSpc = inventory.Length - Computer.findNumberOfCreatedComputers();
            if (numOfCompWishToAdd <= availableSpc)
            {
                for (int i = 0; i < numOfCompWishToAdd; i++)
                {
                    Console.WriteLine("Please provide the details for computer number " + (i + 1));
                    Console.Write("Computer Brand: ");
                    string brand = Console.ReadLine() ?? string.Empty;
                    Console.Write("Computer Model: ");
                    string model = Console.ReadLine();
                    Console.Write("Computer serial number: ");
                    long sn = Convert.ToInt64(Console.ReadLine());
                    Console.Write("Computer Price: ");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Computer c = new Computer(brand, model, sn, price);
                    inventory[Computer.findNumberOfCreatedComputers() - 1] = c;
                }
            }
            else
            {
                Console.WriteLine("You have " + availableSpc + " available space.");
            }
        }

        public static void choice2()
        {
            if (!verPass())
            {
                return;
            }
            //Console.WriteLine("Enter the number of the computer you want to change: ");
            Console.WriteLine("Here are the avalaible computers: ");
            int index = 0;
            //for (int i = 0; i < inventory.Length; i++)
            foreach (Computer i in inventory)
            {
                if (i == null) //|| inventory.Length == 0)
                {
                    break;
                }
                Console.WriteLine();
                Console.WriteLine("Number: " + index);
                Console.WriteLine("Brand: " + i.getBrand());
                Console.WriteLine("Model: " + i.getModel());
                Console.WriteLine("Serial number: " + i.getSN());
                Console.WriteLine("Price: " + i.getPrice());
                index++;
            }
            Console.WriteLine();
            Console.Write("Enter the number of the computer you want to change: ");
            int compWishToChange = Convert.ToInt32(Console.ReadLine());
            Computer computerToChange = inventory[compWishToChange];
            if (computerToChange == null)
            {
                Console.WriteLine("There is no computer number which you entered, what would you like to do?");
                Console.WriteLine("1. Update the other one");
                Console.WriteLine("2. Quit");
                char choiceupdate = Convert.ToChar(Console.ReadLine());
                switch (choiceupdate)
                {
                    case '1':
                        choice2();
                        break;
                    case '2':
                        return;

                }//end choiceupdate
            }//end if
            else
            {
                Console.WriteLine();
                Console.WriteLine("Computer number: " + compWishToChange);
                Console.WriteLine("Brand: " + computerToChange.getBrand());
                Console.WriteLine("Model: " + computerToChange.getModel());
                Console.WriteLine("SN: " + computerToChange.getSN());
                Console.WriteLine("Price: " + computerToChange.getPrice());
                char choiceupdate;
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("What information would you like to change?");
                    Console.WriteLine("1. Brand");
                    Console.WriteLine("2. Model");
                    Console.WriteLine("3. SN");
                    Console.WriteLine("4. Price");
                    Console.WriteLine("5. Quit");
                    Console.Write("Enter your choice: ");
                    choiceupdate = Convert.ToChar(Console.ReadLine());

                    switch (choiceupdate)
                    {
                        case '1':
                            Console.Write("Enter the new brand: ");
                            string newBrand = Console.ReadLine();
                            computerToChange.setBrand(newBrand);
                            break;
                        case '2':
                            Console.Write("Enter the new model: ");
                            string newModel = Console.ReadLine();
                            computerToChange.setModel(newModel);
                            break;
                        case '3':
                            Console.Write("Enter the new serial number: ");
                            long newSN = Convert.ToInt64(Console.ReadLine());
                            computerToChange.setSN(newSN);
                            break;
                        case '4':
                            Console.Write("Enter the new price: ");
                            double newPrice = Convert.ToDouble(Console.ReadLine());
                            computerToChange.setPrice(newPrice);
                            break;
                        case '5':
                            break;
                    }//end switch

                }//end do
                while (choiceupdate != '5');
                Console.WriteLine("Computer number: " + compWishToChange);
                Console.WriteLine("Brand: " + computerToChange.getBrand());
                Console.WriteLine("Model: " + computerToChange.getModel());
                Console.WriteLine("SN: " + computerToChange.getSN());
                Console.WriteLine("Price: " + computerToChange.getPrice());
            }//end else
        }//end choice2
        public static void choice3()
        {
            Console.WriteLine();
            Console.WriteLine("Which brand do you want to search: ");
            string brandChoice = Console.ReadLine();
            for (int i = 0; i < Computer.findNumberOfCreatedComputers(); i++)
            {
                Computer c = inventory[i];
                if (brandChoice == c.getBrand())
                {
                    c.showComputer();
                }
                else{
                    Console.WriteLine("Wrong entry!");
                }
            }
        }//end choice3
        public static void choice4()
        {
            Console.WriteLine("What is the maximum price to limit the search: ");
            double priceChoice = Convert.ToDouble(Console.ReadLine());
            for (int i = 0; i < Computer.findNumberOfCreatedComputers(); i++)
            {
                Computer c = inventory[i];
                if (priceChoice > c.getPrice())
                {
                    c.showComputer();
                }
                else{
                    Console.WriteLine("We don't have any computers with this price!");
                }
            }
        }//end choice4
        public static void choice5()
        {
            Console.WriteLine();
            Console.WriteLine("You choose to quit. Bye!");
        }
        public static bool verPass()
        {
            Console.WriteLine();
            Console.Write("Please enter your password: ");
            for (int i = 0; i < 3; i++)
            {
                String pass = Console.ReadLine();
                if (pass.Equals(password))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Wrong password!");
                }
            }
            return false;
        }
        public static void copyText(){
            string compList = @"D:\Session 2\C#\Project\List.txt";
            try{
                using (StreamWriter cList = new StreamWriter(compList)) {
                    for (int i = 0; i < inventory.Length; i++)
                    {
                       if(inventory[i] != null){
                        cList.WriteLine("Computer number " + (i+1) + " has: ");
                        cList.WriteLine("Brand - " + inventory[i].getBrand());
                        cList.WriteLine("Model -  " + inventory[i].getModel());
                        cList.WriteLine("Serial Number -  " + inventory[i].getSN());
                        cList.WriteLine("Price - " + inventory[i].getPrice());
                        cList.WriteLine();
                       } 
                    }
                }
            }catch(Exception ex){
                Console.Write(ex.Message);
            }
            string[] file = System.IO.File.ReadAllLines(@"D:\Session 2\C#\Project\List.txt");
            System.Console.WriteLine();
            System.Console.WriteLine("File content: ");
            foreach (string item in file)
            {
                Console.WriteLine(item);
            }
        }


    }





