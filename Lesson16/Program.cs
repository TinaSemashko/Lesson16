using System;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, bool> ResultsOfVoters = new Dictionary<string, bool>();
        Console.WriteLine("Insert topic for voting");
        string topic = Console.ReadLine();
        Voting voting = new Voting(topic, ResultsOfVoters);

        bool isNum = false;
        int voters = 0;
        do
        {
            Console.WriteLine("Insert number of voters ");
            string str = Console.ReadLine();
            isNum = int.TryParse(str, out voters);

            if (!isNum)
            {
                Console.WriteLine("Invalid input");
            }

        } while (!isNum);


        for (int i = 0; i < voters; i++)
        {
            Console.WriteLine("Insert your name");
            string name = Console.ReadLine();
            int num; 
            bool cond;
            do
            {
                Console.WriteLine("Insert your vote. Type 1 or 0");
                string str = Console.ReadLine();
                isNum = int.TryParse(str, out num);
                cond = isNum && (num == 1 || num == 0);

                if (!cond)
                {
                    Console.WriteLine("Invalid input");
                }

            } while (!cond);

            bool vote = false;
            if (num == 1) vote = true;
            voting.AddVote(name, vote);
        }

        voting.PrintResults();
    }

    class Voting
    {
        string topic;
        Dictionary<string, bool> ResultsOfVoters { get; set; }

        public Voting(string topic, Dictionary<string, bool> resultsOfVoters)
        {
            this.topic = topic;
            ResultsOfVoters = resultsOfVoters;
        }

        public void AddVote(string voter, bool vote)
        {
            ResultsOfVoters.Add(voter, vote);
        }

        public void PrintResults()
        {
            int yes = 0;
            int no = 0;
            Dictionary<string, bool>.ValueCollection valueColl = ResultsOfVoters.Values;

            foreach (bool vote in valueColl)
            {
                if(vote) yes++;
                else no++;
            }
            Console.WriteLine($"For topic {topic} pro {yes} votes and contra {no} votes");
        }
    }


}
