using BuisnessLayer;
using BusinessLayer;
using System;

namespace Online_Recuritment_Project
{
    internal class Program
    {
        static void Main(string[] args)

        /*
         * 
         * 1- add vacancies -> which employer will add it ?
         * 
                                                                                                                                         * 2- add job seekers (done)
                                                                                                                                         * 
                                                                                                                                         * 3- add employers (done)
                                                                                                                                         * 
                                                                                                                                         * 4- update employers (done)
                                                                                                                                         * 
                                                                                                                                         * 5- update job seekers (done)
         * 
         * 6- apply for jobs -> which job seeker will apply for which job 
         * 
         * 7- save jobs -> which job seeker will save which job
         * 
         * 8- show applied jobs for a speciic user -> enter job seeker id and then show the applied jobs
         * 
         * 9- show saved jobs for a specific user -> enter job seeker id and then show the saved jobs
         * 
         * 10- show added jobs for a specific Employer -> enter employer id and then show the added jobs
         * 
         * 11- show all jobs
         * 
         * 12- delete applied job -> ask for job seeker id and appliedJob id and delete the job
         * 
         * 13- delete saved job -> ask for job seeker id and savedJob id and delete the job
         * 
         *
         *
         * (1, 7, 13) -> First
         * 
         * (6, 8, 12) -> Second
         * 
         * (10, 11) -> Third
         *
         */



        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Online Recruitment Testing =====");
                Console.WriteLine("1. Find JobSeeker by ID");
                Console.WriteLine("2. Add New JobSeeker");
                Console.WriteLine("3. Update Existing JobSeeker");
                Console.WriteLine("4. Find Employer by ID");
                Console.WriteLine("5. Add New Employer");
                Console.WriteLine("6. Update Existing Employer");
                Console.WriteLine("7. Apply for Job");
                Console.WriteLine("8. Show Applied Jobs");
                Console.WriteLine("9. Delete Applied Job");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        FindJobSeekerByID();
                        break;
                    case "2":
                        AddJobSeeker();
                        break;
                    case "3":
                        UpdateJobSeeker();
                        break;
                    case "4":
                        FindEmployerByID();
                        break;
                    case "5":
                        AddEmployer();
                        break;
                    case "6":
                        UpdateEmployer();
                        break;
                    case "7":
                        ApplyForJob();
                        break;
                    case "8":
                        ShowAppliedJobs();
                        break;
                    case "9":
                        DeleteAppliedJob();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void FindJobSeekerByID()
        {
            Console.Write("Enter JobSeeker ID: ");
            int id = int.Parse(Console.ReadLine());

            var jobSeeker = clsJobSeeker.FindJobSeekerByID(id);
            if (jobSeeker == null)
            {
                Console.WriteLine("JobSeeker not found.");
                return;
            }

            Console.WriteLine($"JobSeeker ID: {jobSeeker.jobSeekerID}");
            Console.WriteLine($"Name: {jobSeeker.user.firstName} {jobSeeker.user.lastName}");
            Console.WriteLine($"Email: {jobSeeker.user.email}");
            Console.WriteLine($"Education Level: {jobSeeker.educationLevel}");
            Console.WriteLine($"Experience: {jobSeeker.experience}");
        }

        static void AddJobSeeker()
        {
            var jobSeeker = new clsJobSeeker();

            Console.WriteLine("Enter User Info:");
            Console.Write("First Name: ");
            jobSeeker.user.firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            jobSeeker.user.lastName = Console.ReadLine();

            Console.Write("Gender: ");
            jobSeeker.user.gender = Console.ReadLine();

            Console.Write("Birth Date (yyyy-mm-dd): ");
            jobSeeker.user.birthDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Email: ");
            jobSeeker.user.email = Console.ReadLine();

            Console.WriteLine("Enter JobSeeker Info:");
            Console.Write("CV: ");
            jobSeeker.cv = Console.ReadLine();

            Console.Write("Address: ");
            jobSeeker.address = Console.ReadLine();

            Console.Write("Education Level: ");
            jobSeeker.educationLevel = Console.ReadLine();

            Console.Write("Nationality: ");
            jobSeeker.nationality = Console.ReadLine();

            Console.Write("Favourite Work Place: ");
            jobSeeker.favouriteWorkPlace = Console.ReadLine();

            Console.Write("Experience: ");
            jobSeeker.experience = Console.ReadLine();

            if (jobSeeker.Save())
                Console.WriteLine("JobSeeker added successfully!");
            else
                Console.WriteLine("Failed to add JobSeeker.");
        }


        static void UpdateJobSeeker()
        {
            Console.Write("Enter JobSeeker ID to update: ");
            int id = int.Parse(Console.ReadLine());

            var jobSeeker = clsJobSeeker.FindJobSeekerByID(id);
            if (jobSeeker == null)
            {
                Console.WriteLine("JobSeeker not found.");
                return;
            }

            Console.WriteLine("Leave blank to keep current value.");
            Console.Write($"Current First Name: {jobSeeker.user.firstName}, New: ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                jobSeeker.user.firstName = input;

            Console.Write($"Current Last Name: {jobSeeker.user.lastName}, New: ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                jobSeeker.user.lastName = input;

            Console.Write($"Current Gender: {jobSeeker.user.gender}, New: ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                jobSeeker.user.gender = input;

            Console.Write($"Current BirthDate: {jobSeeker.user.birthDate.ToShortDateString()}, New (yyyy-mm-dd): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                jobSeeker.user.birthDate = DateTime.Parse(input);

            Console.Write($"Current Email: {jobSeeker.user.email}, New: ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                jobSeeker.user.email = input;

            Console.Write($"Current Education Level: {jobSeeker.educationLevel}, New: ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                jobSeeker.educationLevel = input;

            if (jobSeeker.Save())
                Console.WriteLine("JobSeeker updated successfully!");
            else
                Console.WriteLine("Failed to update JobSeeker.");
        }


        static void FindEmployerByID()
        {
            Console.Write("Enter Employer ID: ");
            int id = int.Parse(Console.ReadLine());

            var employer = clsEmployer.FindEmployerByID(id);
            if (employer == null)
            {
                Console.WriteLine("Employer not found.");
                return;
            }

            Console.WriteLine($"Employer ID: {employer.employerID}");
            Console.WriteLine($"Name: {employer.user.firstName} {employer.user.lastName}");
            Console.WriteLine($"Email: {employer.user.email}");
            Console.WriteLine($"Company Name: {employer.companyName}");
        }

        static void AddEmployer()
        {
            var employer = new clsEmployer();

            Console.WriteLine("Enter User Info:");
            Console.Write("First Name: ");
            employer.user.firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            employer.user.lastName = Console.ReadLine();

            Console.Write("Gender: ");
            employer.user.gender = Console.ReadLine();

            Console.Write("Birth Date (yyyy-mm-dd): ");
            employer.user.birthDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Email: ");
            employer.user.email = Console.ReadLine();

            Console.Write("Company Name: ");
            employer.companyName = Console.ReadLine();

            if (employer.Save())
                Console.WriteLine("Employer added successfully!");
            else
                Console.WriteLine("Failed to add Employer.");
        }


        static void UpdateEmployer()
        {
            Console.Write("Enter Employer ID to update: ");
            int id = int.Parse(Console.ReadLine());

            var employer = clsEmployer.FindEmployerByID(id);
            if (employer == null)
            {
                Console.WriteLine("Employer not found.");
                return;
            }

            Console.WriteLine("Leave blank to keep current value.");

            // User fields
            Console.Write($"Current First Name: {employer.user.firstName}, New: ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                employer.user.firstName = input;

            Console.Write($"Current Last Name: {employer.user.lastName}, New: ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                employer.user.lastName = input;

            Console.Write($"Current Gender: {employer.user.gender}, New: ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                employer.user.gender = input;

            Console.Write($"Current BirthDate: {employer.user.birthDate.ToShortDateString()}, New (yyyy-mm-dd): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                employer.user.birthDate = DateTime.Parse(input);

            Console.Write($"Current Email: {employer.user.email}, New: ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                employer.user.email = input;

            // Employer-specific field
            Console.Write($"Current Company Name: {employer.companyName}, New: ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                employer.companyName = input;

            if (employer.Save())
                Console.WriteLine("Employer updated successfully!");
            else
                Console.WriteLine("Failed to update Employer.");
        }

        // Apply part
        static void ApplyForJob()
        {
            Console.Write("Enter JobSeeker ID: ");
            if (!int.TryParse(Console.ReadLine(), out int jobSeekerID))
            {
                Console.WriteLine("Invalid JobSeeker ID.");
                return;
            }

            Console.Write("Enter Vacancy ID to apply for: ");
            if (!int.TryParse(Console.ReadLine(), out int vacancyID))
            {
                Console.WriteLine("Invalid Vacancy ID.");
                return;
            }

            
            var jobSeeker = clsJobSeeker.FindJobSeekerByID(jobSeekerID);
            if (jobSeeker == null)
            {
                Console.WriteLine("JobSeeker not found.");
                return;
            }

            string result = clsApplying.Apply(vacancyID, jobSeekerID);
            Console.WriteLine(result);
        }

        static void ShowAppliedJobs()
        {
            Console.Write("Enter JobSeeker ID: ");
            if (!int.TryParse(Console.ReadLine(), out int jobSeekerID))
            {
                Console.WriteLine("Invalid JobSeeker ID.");
                return;
            }

            
            var jobSeeker = clsJobSeeker.FindJobSeekerByID(jobSeekerID);
            if (jobSeeker == null)
            {
                Console.WriteLine("JobSeeker not found.");
                return;
            }

            string appliedJobs = clsApplying.ShowAppliedJobs(jobSeekerID);
            Console.WriteLine(appliedJobs);
        }

        static void DeleteAppliedJob()
        {
            Console.Write("Enter JobSeeker ID: ");
            if (!int.TryParse(Console.ReadLine(), out int jobSeekerID))
            {
                Console.WriteLine("Invalid JobSeeker ID.");
                return;
            }

            Console.Write("Enter Applying ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int applyingID))
            {
                Console.WriteLine("Invalid Applying ID.");
                return;
            }

            
            var jobSeeker = clsJobSeeker.FindJobSeekerByID(jobSeekerID);
            if (jobSeeker == null)
            {
                Console.WriteLine("JobSeeker not found.");
                return;
            }

            string result = clsApplying.DeleteAppliedJob(applyingID, jobSeekerID);
            Console.WriteLine(result);
        }




    }
}
