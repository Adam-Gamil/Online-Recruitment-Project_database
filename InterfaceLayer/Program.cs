using System;
using System.Data;
using BuisnessLayer;
using BusinessLayer;

namespace Online_Recuritment_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Online Recruitment System =====");
                Console.WriteLine("1. Jobseeker Menu");
                Console.WriteLine("2. Employer Menu");
                Console.WriteLine("3. Shared Functions");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowJobseekerMenu();
                        break;
                    case "2":
                        ShowEmployerMenu();
                        break;
                    case "3":
                        ShowSharedFunctionsMenu();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ShowJobseekerMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Jobseeker Menu =====");
                Console.WriteLine("1. Find JobSeeker by ID");
                Console.WriteLine("2. Add New JobSeeker");
                Console.WriteLine("3. Update Existing JobSeeker");
                Console.WriteLine("4. Apply for Job");
                Console.WriteLine("5. Show Applied Jobs");
                Console.WriteLine("6. Delete Applied Job");
                Console.WriteLine("7. Save Vacancy");
                Console.WriteLine("8. Delete Saved Vacancy");
                Console.WriteLine("9. Show Saved Jobs");
                Console.WriteLine("10. Show All Job Seekers");
                Console.WriteLine("0. Back to Main Menu");
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
                        ApplyForJob();
                        break;
                    case "5":
                        ShowAppliedJobs();
                        break;
                    case "6":
                        DeleteAppliedJob();
                        break;
                    case "7":
                        SaveJob();
                        break;
                    case "8":
                        DeleteSavedJob();
                        break;
                    case "9":
                        ShowSavedJobs();
                        break;
                    case "10":
                        ShowAllJobSeekers();
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

        static void ShowEmployerMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Employer Menu =====");
                Console.WriteLine("1. Find Employer by ID");
                Console.WriteLine("2. Add New Employer");
                Console.WriteLine("3. Update Existing Employer");
                Console.WriteLine("4. Add New Vacancy");
                Console.WriteLine("5. Show Added Jobs by Employer");
                Console.WriteLine("6. Show All Employers");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        FindEmployerByID();
                        break;
                    case "2":
                        AddEmployer();
                        break;
                    case "3":
                        UpdateEmployer();
                        break;
                    case "4":
                        AddVacancy();
                        break;
                    case "5":
                        ShowAddedJobsByEmployer();
                        break;
                    case "6":
                        ShowAllEmployers();
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

        static void ShowSharedFunctionsMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Shared Functions =====");
                Console.WriteLine("1. Add a phone number for a user");
                Console.WriteLine("2. Search for phone number/s of a user");
                Console.WriteLine("3. Show all vacancies");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPhoneNumber();
                        break;
                    case "2":
                        FindPhoneNumbersForUser();
                        break;
                    case "3":
                        ShowAllVacancies();
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

            Console.Write("Company Location: ");
            employer.companyLocation = Console.ReadLine();

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


            Console.Write($"Current Company Location: {employer.companyLocation}, New: ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                employer.companyLocation = input;

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

            if(clsApplying.CheckIfApplied(vacancyID, jobSeekerID))
            {
                Console.WriteLine("You have already applied for this job.");
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

        static void AddVacancy()
        {
            var vacancy = new clsVacancies();

            Console.Write("Enter Employer ID: ");
            int id = int.Parse(Console.ReadLine());
            var employer = clsEmployer.FindEmployerByID(id);
            if (employer == null)
            {
                Console.WriteLine("Employer not found.");
                return;
            }
            vacancy.employer = employer;
            Console.WriteLine($"Name: {employer.user.firstName} {employer.user.lastName}");
            Console.WriteLine($"Company Name: {employer.companyName}");

            Console.WriteLine("Enter Vacancy Info:");
            Console.Write("Industry: ");
            vacancy.industry = Console.ReadLine();

            Console.Write("Job Title: ");
            vacancy.jobTitle = Console.ReadLine();

            Console.Write("Description: ");
            vacancy.description = Console.ReadLine();

            Console.Write("Location: ");
            vacancy.location = Console.ReadLine();

            Console.Write("Job Status: ");
            vacancy.jobStatus = Console.ReadLine();

            Console.Write("Required Experience: ");
            vacancy.requiredExperience = Console.ReadLine();

            Console.Write("salary: ");
            vacancy.salary = double.Parse(Console.ReadLine());

            if (vacancy.Save())
                Console.WriteLine("Vacancy added successfully!");
            else
                Console.WriteLine("Failed to add Vacancy.");
        }
        static void SaveJob()
        {
            Console.Write("Enter JobSeeker ID: ");
            if (!int.TryParse(Console.ReadLine(), out int jobSeekerID))
            {
                Console.WriteLine("Invalid JobSeeker ID.");
                return;
            }

            Console.Write("Enter Vacancy ID to save it: ");
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

            if(clsSavingVacancy.CheckIfSaved(vacancyID, jobSeekerID))
            {
                Console.WriteLine("You have already saved this job.");
                return;
            }

            string result = clsSavingVacancy.Save(vacancyID, jobSeekerID);
            Console.WriteLine(result);
        }
        static void DeleteSavedJob()
        {
            Console.Write("Enter JobSeeker ID: ");
            if (!int.TryParse(Console.ReadLine(), out int jobSeekerID))
            {
                Console.WriteLine("Invalid JobSeeker ID.");
                return;
            }

            Console.Write("Enter Saved ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int savingID))
            {
                Console.WriteLine("Invalid saved ID.");
                return;
            }


            var jobSeeker = clsJobSeeker.FindJobSeekerByID(jobSeekerID);
            if (jobSeeker == null)
            {
                Console.WriteLine("JobSeeker not found.");
                return;
            }

            string result = clsSavingVacancy.DeleteSavedJob(savingID, jobSeekerID);
            Console.WriteLine(result);
        }

        static void AddPhoneNumber()
        {
            Console.WriteLine("Enter User ID to add a phone number for:");
            int userID = int.Parse(Console.ReadLine());
            var user = clsUser.findUser(userID);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }
            Console.WriteLine("Enter Phone Number:");

            string phoneNumber = Console.ReadLine();

            var phoneNumberObj = new clsPhoneNumber();
            phoneNumberObj.userID = userID;
            phoneNumberObj.phoneNumber = phoneNumber;


            if (phoneNumberObj._AddNewUserPhoneNumber())
            {
                Console.WriteLine("Phone number added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add phone number.");
            }
        }

        static void FindPhoneNumbersForUser()
        {
            Console.WriteLine("Enter User ID to find phone numbers for:");
            int userID = int.Parse(Console.ReadLine());
            var user = clsUser.findUser(userID);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            DataTable dataTable = clsPhoneNumber.findUserPhoneNumber(userID);
            if (dataTable != null) 
            {
                if (dataTable.Rows.Count == 0)
                {
                    Console.WriteLine("No phone numbers found for this user.");
                    return;
                }
               
            }
            Console.WriteLine($"Phone numbers for User ID {userID}:");

            int cnt = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"Phone Number {cnt++}:");
                Console.WriteLine($"Phone Number ID: {row["phoneNumberID"]}");
                Console.WriteLine($"Phone Number: {row["phoneNumber"]}");
                Console.WriteLine($"User Name: " + user.firstName + user.lastName);
                Console.WriteLine();
            }
           
        }

        static void ShowAllJobSeekers()
        {
            DataTable dt = clsJobSeeker.getAllJobSeekers();
            if (dt == null || dt.Rows.Count == 0)
            {
                Console.WriteLine("No Job Seekers found.");
                return;
            }
            Console.WriteLine("All Job Seekers:");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine($"User ID        : {row["userID"]}");
                Console.WriteLine($"Name           : {row["firstName"]} {row["lastName"]}");
                Console.WriteLine($"Gender         : {row["gender"]}");
                Console.WriteLine($"Birth Date     : {Convert.ToDateTime(row["birthDate"]).ToShortDateString()}");
                Console.WriteLine($"Email          : {row["email"]}");
                Console.WriteLine($"JobSeeker ID   : {row["jobSeekerID"]}");
                Console.WriteLine($"CV             : {row["cv"]}");
                Console.WriteLine($"Address        : {row["address"]}");
                Console.WriteLine($"Education      : {row["educationLevel"]}");
                Console.WriteLine($"Nationality    : {row["nationality"]}");
                Console.WriteLine($"Fav. Workplace : {row["favouriteWorkPlace"]}");
                Console.WriteLine($"Experience     : {row["experience"]}");
                Console.WriteLine("=====================================\n");
            }

        }

        static void ShowAllEmployers()
        {
            DataTable dt = clsEmployer.getAllEmployers();
            if (dt == null || dt.Rows.Count == 0)
            {
                Console.WriteLine("No Employers found.");
                return;
            }

            Console.WriteLine("All Employers:");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine($"User ID           : {row["userID"]}");
                Console.WriteLine($"Name              : {row["firstName"]} {row["lastName"]}");
                Console.WriteLine($"Gender            : {row["gender"]}");
                Console.WriteLine($"Birth Date        : {Convert.ToDateTime(row["birthDate"]).ToShortDateString()}");
                Console.WriteLine($"Email             : {row["email"]}");
                Console.WriteLine($"Employer ID       : {row["employerID"]}");
                Console.WriteLine($"Company Name      : {row["companyName"]}");
                Console.WriteLine($"Company Location  : {row["companyLocation"]}");
                Console.WriteLine("=====================================\n");
            }
        }

        static void ShowAllVacancies() {
            Console.Clear();
            DataTable dt = clsVacancies.getAllVacancies();
            if (dt == null || dt.Rows.Count == 0)
            {
                Console.WriteLine("No vacancies found.");
                return;
            }
            Console.WriteLine("All Vacancies:");
            foreach(DataRow row in dt.Rows)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("Vacancy ID       : " + row["vacancyID"]);
                Console.WriteLine("Job Title        : " + row["jobTitle"]);
                Console.WriteLine("Industry         : " + row["industry"]);
                Console.WriteLine("Description      : " + row["description"]);
                Console.WriteLine("Location         : " + row["location"]);
                Console.WriteLine("Job Status       : " + row["jobStatus"]);
                Console.WriteLine("Post Date        : " + Convert.ToDateTime(row["postDate"]).ToShortDateString());
                Console.WriteLine("Required Experience: " + row["requiredExperience"]);
                Console.WriteLine("Salary           : " + row["salary"]);
                Console.WriteLine("Employer ID      : " + row["employerID"]);
                Console.WriteLine("=====================================\n");
            }
        }

        static void ShowSavedJobs()
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

            DataTable savedJobs = clsSavingVacancy.ShowSavedJobs(jobSeekerID);

            if (savedJobs == null || savedJobs.Rows.Count == 0) {
                Console.WriteLine("No Saved jobs found.");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Job seeker Name: " + jobSeeker.user.firstName + " " + jobSeeker.user.lastName);
            Console.WriteLine();
            string result = "Saved Jobs:\n";
            foreach (DataRow row in savedJobs.Rows)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("Saving Job ID  : " + row["savingID"]);
                Console.WriteLine("Vacancy Title  : " + row["jobTitle"]);
                Console.WriteLine("Saved Date     : " + Convert.ToDateTime(row["date"]).ToShortDateString());
                Console.WriteLine("=====================================\n");
            }

           
        }

        static void ShowAddedJobsByEmployer()
        {
            Console.Write("Enter Employer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int employerID))
            {
                Console.WriteLine("Invalid Employer ID.");
                return;
            }
            var employer = clsEmployer.FindEmployerByID(employerID);
            if (employer == null)
            {
                Console.WriteLine("Employer not found.");
                return;
            }
            DataTable addedJobs = clsVacancies.getVacanciesByEmployerID(employerID);
            if (addedJobs == null || addedJobs.Rows.Count == 0)
            {
                Console.WriteLine("No added jobs found.");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Employer Name: " + employer.user.firstName + " " + employer.user.lastName);
            Console.WriteLine("Company Name: " + employer.companyName);
            Console.WriteLine();
            string result = "Added Jobs:\n";
            foreach (DataRow row in addedJobs.Rows)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("Vacancy ID     : " + row["vacancyID"]);
                Console.WriteLine("Job Title      : " + row["jobTitle"]);
                Console.WriteLine("Post Date      : " + Convert.ToDateTime(row["postDate"]).ToShortDateString());
                Console.WriteLine("Industry       : " + row["industry"]);
                Console.WriteLine("Description    : " + row["description"]);
                Console.WriteLine("Location       : " + row["location"]);
                Console.WriteLine("Job Status     : " + row["jobStatus"]);
                Console.WriteLine("Required Experience: " + row["requiredExperience"]);
                Console.WriteLine("Salary         : " + row["salary"]);
                Console.WriteLine("=====================================\n");
            }
        }
    }
}
