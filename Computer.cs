class Computer
    {
        private string brand;
        private string model;
        private long SN;
        private double price;
        private static int numOfCom = 0;


        public Computer(string br, string md, long sn, double pr)
        {
            // Console.WriteLine("My object is created.");
            brand = br;
            model = md;
            SN = sn;
            price = pr;
            numOfCom++;
        }
        public string getBrand()
        {
            return brand;
        }
        public void setBrand(string br)
        {
            brand = br;
        }
        public string getModel()
        {
            return model;
        }
        public void setModel(string md)
        {
            model = md;
        }
        public long getSN()
        {
            return SN;
        }
        public void setSN(long sn)
        {
            if (sn < 0 && sn < 999999)
            {
                SN = sn;
            }
            else
            {
                Console.WriteLine("The serial number you have entered is not valide!");
            }

        }
        public double getPrice()
        {
            return price;
        }
        public void setPrice(double pr)
        {
            if (pr < 0 && pr < 10000)
            {
                price = pr;
            }
            else
            {
                Console.WriteLine("It is not a correct price!");
            }
        }
        public static int findNumberOfCreatedComputers()
        {
            return numOfCom;
        }
        public Boolean equals(Computer c)
        {
            if (brand == c.brand && model == c.model && price == c.price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void showComputer()
        {
            Console.WriteLine("This computer has " + brand + " brand name.");
            Console.WriteLine("This computer has " + model + " model.");
            Console.WriteLine("This computer has " + SN + " serial number.");
            Console.WriteLine("This computer cost " + price + "$.");
        }


    }