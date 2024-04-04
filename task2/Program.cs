namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    abstract class AllDepartments
    {
        private protected int _budget { get; set; }
        private protected int _numOfWorkers { get; set; }
        
        public Random rnd = new Random(DateTime.Now.Millisecond);

        public void Hire(IWorker worker)
        {
            _numOfWorkers++;
        }
        public void Fire(IWorker worker)
        {
            if (_numOfWorkers > 0)
                _numOfWorkers--;
            else
                _numOfWorkers = 0;   //nobody left to fire!
        }
    }

    class FishingDepartment : AllDepartments
    {
        private int _numOfBoats; //{ get; set; }
        private int _numOfDamagedBoats; //{ get; set; }
        public FishingDepartment()
        {
            _budget = rnd.Next(5000, 10001);
            _numOfBoats = rnd.Next(5, 11);
            _numOfDamagedBoats = rnd.Next(1, 3);
        }

        public void FixBoat(int cost)
        {
            if (_numOfDamagedBoats > 0)
            {
                _numOfBoats++;
                _numOfDamagedBoats--;
                _budget -= cost;
            }
        }
    }

    class BusinessDepartment : AllDepartments
    {
        private int _monthlyIncome { get; set; }
        
        public void PayTaxes(int money)
        {
            _budget -= money;
        }

        public BusinessDepartment()
        {
            _budget = rnd.Next(5000, 10000);
            _monthlyIncome = rnd.Next(1000, 5000);
        }
    }


    interface IWorker
    {
        public string _name { get; }
        protected int _salaryindex { get; }  //per hour
        protected int _money { get; }
        public void Work(int hours);
    }

    class Fisher : IWorker
    {
        public enum Specialty { Fishing, Loading, Driving };

        private Specialty _specialty { get; }
        public string _name { get; }
        public int _salaryindex { get; }
        public int _money { get; private set; }

        public Fisher(string name, Specialty specialty)
        {
            _name = name;
            _specialty = specialty;

            if (_specialty == Specialty.Fishing)
                _salaryindex = 2;
            else if (_specialty == Specialty.Loading)
                _salaryindex = 3;
            else
                _salaryindex = 4;
        }
        public void Work(int hours)
        {
            _money += hours * _salaryindex;
        }
    }

    class BusinessAnalyst : IWorker
    {
        public enum Team { Income, Taxing };

        private Team _team { get; }
        public string _name { get; }
        public int _salaryindex { get; }
        public int _money { get; private set; }

        public BusinessAnalyst(string name, Team team)
        {
            _name = name;
            _team = team;

            if (_team == Team.Income)
                _salaryindex = 4;
            else
                _salaryindex = 2;
        }
        public void Work(int hours)
        {
            _money += hours * _salaryindex;
        }

    }
}
