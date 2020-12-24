using Ninject;
using System;
using VoteSystem.Data.Repositories;
using VoteSystem.Domain.Interfaces;
using VoteSystem.Domain.DefaultImplementations;
using VoteSystem.EF.Repositories;
using VoteSystem.Data.Entities.UserPolicyAggregate;

namespace VoteSystem.Cosnole
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            
            #region BindingOnly
            kernel.Bind<IPollRepository>().To<PollRepository>();
            kernel.Bind<IRegionRepository>().To<RegionRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IVoteRepository>().To<VoteRepository>();

            kernel.Bind<IManagePolicy>().To<ManagePolicy>();
            kernel.Bind<IPolicyChecker>().To<PolicyChecker>();
            kernel.Bind<IPollService>().To<PollService>();
            kernel.Bind<IRegistrationUserService>().To<RegistrationUserService>();
            kernel.Bind<IVoteService>().To<VoteService>();

            ContextRegistration contextRegistration = new ContextRegistration();
            UserRepository userRepository = new UserRepository();
            VoteRepository voteRepository = new VoteRepository();
            RegionRepository regionRepository = new RegionRepository();
            PollRepository pollRepository = new PollRepository();
            PollService pollService = new PollService(userRepository, regionRepository, pollRepository);
            var managePolicy = new ManagePolicy(userRepository);
            IRegistrationUserService registrationUserService = new RegistrationUserService(contextRegistration,
                                                                                           voteRepository,
                                                                                           regionRepository,
                                                                                           userRepository);
            #endregion

            while (true)
            {
                System.Console.WriteLine($"Hello, Person. Here's some service for you to make your own choice for the future of your country \n" +
                $"Please enter your passport data to verify your identity:");
                string passport = Console.ReadLine();
                Console.WriteLine("Now identification code:");
                int indefcode = Int32.Parse(Console.ReadLine());
                contextRegistration.SetPasswordInfo(passport, indefcode);
                bool response;
                try
                {
                    response = registrationUserService.ValidateUser(contextRegistration.GetPassportInfo().Item1,
                                              contextRegistration.GetPassportInfo().Item2);
                }
                catch (Exception)
                {
                    Console.WriteLine("We don't have information about you");
                    response = false;
                }
                if (response == false)
                {
                    Console.WriteLine("Sorry, but you are not allowed to vote");
                }
                else
                {
                    while (true) { 
                    Console.Clear();
                    Console.WriteLine("Welcome to our service!");
                    Console.WriteLine("Select option:\n" +
                        "1. Create Poll;" +
                        "2. Add Choice to Poll;" +
                        "3. Vote;" +
                        "4. Give Policy");
                    int answer = Int32.Parse(Console.ReadLine());
                        switch (answer)
                        {
                            #region Create Poll
                            case 1:
                                Console.WriteLine("Create your poll:\n Enter name: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Description:");
                                string desc = Console.ReadLine();
                                int ownerpollId = userRepository.GetUser(contextRegistration.GetPassportInfo().Item1,
                                                       contextRegistration.GetPassportInfo().Item2).Id;
                                Console.WriteLine("Enter Date of poll start (dd/MM/YYYY): ");
                                var start = Convert.ToDateTime(Console.ReadLine());
                                Console.WriteLine("Enter Date of poll end (dd/MM/YYYY): ");
                                var end = Convert.ToDateTime(Console.ReadLine());
                                Console.WriteLine("Allow multiple selection? (Y/N)");
                                bool multiple;
                                string temp_ans = Console.ReadKey().ToString();
                                Console.ReadLine();
                                if (temp_ans == "Y")
                                    multiple = true;
                                else
                                    multiple = false;
                                pollService.CreatePoll(name, desc, ownerpollId, start, end, multiple);
                                break;
                            #endregion

                            #region AddChoice
                            case 2:
                                Console.WriteLine("Enter Option Name: ");
                                string optionName = Console.ReadLine();
                                Console.WriteLine("Enter option description: ");
                                string descr = Console.ReadLine();
                                Console.WriteLine("Enter Poll Name: ");
                                int pollId = pollRepository.Get(Console.ReadLine()).Id;
                                pollService.AddChoiceToPoll(optionName, descr, pollId);
                                break;

                            #endregion

                            #region Vote
                            case 3:
                                Console.WriteLine("Available polles: ");
                                break;
                            #endregion
                            #region Policy
                            case 4:
                                Console.WriteLine("Enter name of admin: ");
                                string nameAdmin = Console.ReadLine();
                                Console.WriteLine("Enter poll name: ");
                                string pollName = Console.ReadLine();
                                int userId = userRepository.GetUserId(nameAdmin);
                                int pollid = pollRepository.Get(pollName).Id;
                                managePolicy.GivePolicyToUser(userId, pollid, (PolicyType)1);
                                break;
                                #endregion
                        }
                    }
                }
            }
        }
    }
}
